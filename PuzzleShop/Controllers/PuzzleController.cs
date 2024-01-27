using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Dto;
using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly ILogger<PuzzleController> _logger;
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;

        public PuzzleController(ILogger<PuzzleController> logger,
            IPuzzleRepository puzzleRepository,
            IMapper mapper)
        {
            _logger = logger;
            _puzzleRepository = puzzleRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRandomPuzzle")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Requested all puzzles");

            return Ok(
                _mapper.Map<List<PuzzleDto>>(_puzzleRepository.GetAll<Puzzle>())
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PuzzleDto))]
        [ProducesResponseType(404)]
        public IActionResult GetPuzzle(int id)
        {
            Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(id);

            if (puzzle == null)
                return NotFound();

            return Ok(_mapper.Map<PuzzleDto>(puzzle));
        }
    }
}