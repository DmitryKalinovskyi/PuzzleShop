using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Models;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly ILogger<GraphQLController> _logger;

        public GraphQLController(ILogger<GraphQLController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetRandomPuzzle")]
        public IEnumerable<Puzzle> Get()
        {
            _logger.LogInformation("Requested info");

            return Enumerable.Range(1, 5).Select(index => new Puzzle
            {
                Id=index,
                Name=$"puzzle {index}",
                Description=$"desc {index}",
            })
            .ToArray();
        }
    }
}