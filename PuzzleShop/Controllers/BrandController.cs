using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Dto;
using PuzzleShop.Models;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepository,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
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
    }
}
