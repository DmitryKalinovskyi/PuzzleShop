using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PuzzleShop.Dto;
using PuzzleShop.Models;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Services;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly ILogger<PuzzleController> _logger;
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _auth;
        private readonly IBrandRepository _brandRepository;

        public PuzzleController(ILogger<PuzzleController> logger,
            IPuzzleRepository puzzleRepository,
            IMapper mapper,
            IAuthenticationService authenticationService,
            IBrandRepository brandRepository)
        {
            _logger = logger;
            _puzzleRepository = puzzleRepository;
            _mapper = mapper;
            _auth = authenticationService;
            _brandRepository = brandRepository;
        }

        [HttpGet("result")]
        [ProducesResponseType(200, Type = typeof(List<PuzzleDto>))]
        public IActionResult SearchPuzzles(string? search, int? page)
        {
            return Ok(
                _mapper.Map<List<PuzzleDto>>(
                    _puzzleRepository.Search(search, page??0)
                    ));
        }

        [HttpGet("{puzzleId}")]
        [ProducesResponseType(200, Type = typeof(PuzzleDto))]
        [ProducesResponseType(404)]
        public IActionResult GetPuzzle(int puzzleId)
        {
            Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(puzzleId);

            if (puzzle == null)
                return NotFound();

            return Ok(_mapper.Map<PuzzleDto>(puzzle));
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult CreatePuzzle(
            string name,
            string description,
            string image_url,
            double price,
            int amount,
            int brand_id,

            string email,
            string password
            )
        {
            var user = _auth.Login(email, password);
            if (user == null)
                return Unauthorized("Login information is invalid");

            var brand = _brandRepository.GetById<Brand, int>(brand_id);
            if (brand == null)
                return NotFound("Specified brand is not found");

            if (brand.OwnerId != user.Id)
                return Unauthorized("You don't have access to publish this puzzle by this brand name");

            var puzzle = new Puzzle()
            {
                Name=name,
                Description=description,
                ImageUrl=image_url,
                Price=price,
                Amount=amount,
                BrandId=brand_id,
            };

            _puzzleRepository.Insert(puzzle);
            _puzzleRepository.Save();

            return Ok();
        }

        [HttpPost("{puzzleId}/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult UpdatePuzzle(
            int puzzleId,
            string name,
            string description,
            string image_url,
            double price,
            int amount,
            int brand_id,

            string email,
            string password
            )
        {
            var user = _auth.Login(email, password);
            if (user == null)
                return Unauthorized("Login information is invalid.");

            var puzzle = _puzzleRepository.GetById<Puzzle, int>(puzzleId);

            if (puzzle == null)
                return NotFound("Such puzzle not founded.");

            var brandFrom = _brandRepository.GetById<Brand, int>(puzzle.BrandId);
            var brandTo = _brandRepository.GetById<Brand, int>(brand_id);

            if (brandFrom == null)
                throw new NullReferenceException("Puzzle should have relation with Brand entity");

            if (brandTo == null)
                return NotFound("Newly specified brand is not founded");

            // check access
            if (brandFrom.OwnerId != user.Id)
                return Unauthorized("You don't have right to manage this puzzle.");

            if (brandTo.OwnerId != user.Id)
                return Unauthorized("You don't have right to push this puzzle into another brand.");

            puzzle.Name = name;
            puzzle.Description = description;
            puzzle.ImageUrl = image_url;
            puzzle.Price = price;
            puzzle.Amount = amount;
            puzzle.BrandId = brand_id;

            _puzzleRepository.Save();

            return Ok();
        }
    }
}