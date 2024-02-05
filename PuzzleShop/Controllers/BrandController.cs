using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Dto;
using PuzzleShop.Models;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Services;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _auth;

        public BrandController(IBrandRepository brandRepository,
            IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _auth = authenticationService;
        }

        [HttpGet("result")]
        [ProducesResponseType(200, Type = typeof(List<BrandDto>))]
        public IActionResult SearchBrands(string? search, int? page)
        {
            return Ok(
                _mapper.Map<List<BrandDto>>(
                    _brandRepository.Search(search, page ?? 0)
                    ));
        }

        [HttpGet("{brandId}/owned")]
        [ProducesResponseType(200, Type = typeof(List<BrandDto>))]
        public IActionResult SearchOwnedPuzzles(int brandId, string? search, int? page)
        {
            return Ok(
                _mapper.Map<List<PuzzleDto>>(
                    _brandRepository.SearchBrandPuzzle(brandId, search, page ?? 0)
                    ));
        }

        [HttpGet("{brandId}")]
        [ProducesResponseType(200, Type = typeof(List<BrandDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetBrand(int brandId)
        {
            Brand? brand = _brandRepository.GetById<Brand, int>(brandId);

            if (brand == null)
                return NotFound();

            return Ok(_mapper.Map<BrandDto>(brand));
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult CreateBrand(
            string name,
            string description,

            string email,
            string password
            )
        {
            var user = _auth.Login(email, password);
            if (user == null)
                return Unauthorized("Login information is invalid");

            var brand = _brandRepository.GetBrandByName(name);
            if (brand != null)
                return BadRequest("Brand with this name already present.");

            // create
            brand = new Brand()
            {
                Name = name,
                Description = description,
                OwnerId = user.Id,
                IsConfirmed = false,
            };

            _brandRepository.Insert(brand);
            _brandRepository.Save();

            return Ok();
        }

        [HttpPost("{brandId}/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBrand(
            int brandId,
            string name,
            string description,

            string email,
            string password
            )
        {
            var user = _auth.Login(email, password);
            if (user == null)
                return Unauthorized("Login information is invalid");

            var brand = _brandRepository.GetById<Brand, int>(brandId);

            if (brand == null)
                return NotFound("Brand with given brandId don't exist");

            if(!user.IsAdmin && user.Id != brand.OwnerId)
                return Unauthorized("You don't have access to update this brand.");

            if (brand.Name != name)
            {
                // name is updated, check is all ok or not
                var brandAnother = _brandRepository.GetBrandByName(name);

                if (brandAnother == null)
                    brand.Name = name;
                else
                    return BadRequest("You can't update name, because it taken by other brand");
            }

            brand.Description = description;
            _brandRepository.Save();

            return Ok();
        }

        [HttpDelete("{brandId}/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBrand(
            int brandId,

            string email,
            string password
            )
        {
            var user = _auth.Login(email, password);
            if (user == null)
                return Unauthorized("Login information is invalid");

            var brand = _brandRepository.GetById<Brand, int>(brandId);

            if (brand == null)
                return NotFound("Brand with given brandId don't exist");

            if(!user.IsAdmin && brand.OwnerId == user.Id)
                return Unauthorized("You don't have access to manage this brand.");

            // perform deletion
            _brandRepository.Delete(brand);
            _brandRepository.Save();

            return Ok();
        }
    }
}
