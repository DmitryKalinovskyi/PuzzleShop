using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PuzzleShop.Dto;
using PuzzleShop.Models;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("id/{userId}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public IActionResult GetUser(int userId)
        {
            User? user = _userRepository.GetById<User, int>(userId);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("id/{userId}/private")]
        [ProducesResponseType(200, Type = typeof(UserPrivateDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Authorize]
        public IActionResult GetUserPrivate(int userId, string? email, string? password)
        {

            return BadRequest();
            //User? user = _userRepository.GetById<User, int>(userId);

            //if (user == null)
            //    return NotFound();

            //return Ok(_mapper.Map<UserPrivateDto>(user));
        }

        [HttpGet("login/{userLogin}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public IActionResult GetUserByLogin(string userLogin)
        {
            User? user = _userRepository.GetByUserName(userLogin);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("login/{userLogin}/private")]
        [ProducesResponseType(200, Type = typeof(UserPrivateDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Authorize]
        public IActionResult GetUserByLoginPrivate(string userLogin)
        {
            return BadRequest();

            //User? user = _userRepository.GetUserByLogin(userLogin);

            //if (user == null)
            //    return NotFound();

            //return Ok(_mapper.Map<UserPrivateDto>(user));
        }
    }
}