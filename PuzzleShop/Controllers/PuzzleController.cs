using Microsoft.AspNetCore.Mvc;
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

        public PuzzleController(ILogger<PuzzleController> logger,
            IPuzzleRepository puzzleRepository)
        {
            _logger = logger;
            _puzzleRepository = puzzleRepository;
        }

        [HttpGet(Name = "GetRandomPuzzle")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Requested all puzzles");

            return Ok(
                    _puzzleRepository.GetAll<Puzzle>()
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Puzzle))]
        [ProducesResponseType(404)]
        public IActionResult GetPuzzle(int id)
        {
            Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(id);

            if (puzzle == null)
                return NotFound();

            return Ok(puzzle);
        }
    }
}