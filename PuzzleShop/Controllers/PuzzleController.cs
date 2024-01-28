using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
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
    }
}