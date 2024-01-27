using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Models;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly ILogger<PuzzleController> _logger;

        public PuzzleController(ILogger<PuzzleController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRandomPuzzle")]
        public IEnumerable<Puzzle> Get()
        {
            _logger.LogInformation("Requested info");
            return Enumerable.Range(1, 5).Select(index => new Puzzle
            {
                Id = index,
                Name = $"puzzle {index}",
                Description = $"desc {index}",
            })
            .ToArray();
        }

        [HttpPost]
        public void PostPuzzle(Puzzle puzzle)
        {
            _logger.LogInformation(puzzle.Name);
        }
    }
}