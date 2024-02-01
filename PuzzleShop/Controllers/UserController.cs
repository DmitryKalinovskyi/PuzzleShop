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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserController(ILogger<UserController> logger,
            IUserRepository userRepository,
            IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
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
        public IActionResult GetUserPrivate(int userId, string email, string password)
        {
            User? user1 = _userRepository.GetById<User, int>(userId);
            if (user1 == null)
                return NotFound("User with given **userId** not founded!");

            User? user2 = _authenticationService.Login(email, password);

            if (user2 == null)
                return Unauthorized("Invalid login information");

            // user1 and user2 should be the same or user2 is admin
            if (user2.IsAdmin == false && user1.Id != user2.Id)
                return Unauthorized();

            return Ok(_mapper.Map<UserPrivateDto>(user1));
        }

        [HttpGet("login/{userLogin}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public IActionResult GetUserByLogin(string userLogin)
        {
            User? user = _userRepository.GetUserByLogin(userLogin);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("login/{userLogin}/private")]
        [ProducesResponseType(200, Type = typeof(UserPrivateDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public IActionResult GetUserByLoginPrivate(string userLogin, string email, string password)
        {
            User? user1 = _userRepository.GetUserByLogin(userLogin);
            if (user1 == null)
                return NotFound("User with given **userId** not founded!");

            User? user2 = _authenticationService.Login(email, password);

            if (user2 == null)
                return Unauthorized("Invalid login information");

            // user1 and user2 should be the same or user2 is admin
            if (user2.IsAdmin == false && user1.Id != user2.Id)
                return Unauthorized();

            return Ok(_mapper.Map<UserPrivateDto>(user1));
        }

        [HttpPost("id/{userId}/update_password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public IActionResult UpdateUserPassword(int userId, string new_password,
            string email,
            string password
            )
        {
            User? user1 = _userRepository.GetById<User, int>(userId);
            if (user1 == null)
                return NotFound("User with given **userId** not founded!");

            User? user2 = _authenticationService.Login(email, password);

            if (user2 == null)
                return Unauthorized("Invalid login information");

            // user1 and user2 should be the same or user2 is admin
            if (user2.IsAdmin == false && user1.Id != user2.Id)
                return Unauthorized();

            _authenticationService.UpdatePassword(user1, new_password);

            _userRepository.Save();

            return Ok();
        }

        [HttpPost("id/{userId}/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public IActionResult UpdateUserInfo(int userId,
            string name,
            string surname,
            string login,
            string address,

            string email,
            string password
            )
        {
            User? user1 = _userRepository.GetById<User, int>(userId);
            if (user1 == null)
                return NotFound("User with given **userId** not founded!");

            User? user2 = _authenticationService.Login(email, password);

            if (user2 == null)
                return Unauthorized("Invalid login information");

            // user1 and user2 should be the same or user2 is admin
            if (user2.IsAdmin == false && user1.Id != user2.Id)
                return Unauthorized();

            // update user data
            user1.Name = name;
            user1.Surname = surname;
            user1.Login = login;
            user1.Address = address;

            _userRepository.Save();

            return Ok();
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public IActionResult CreateUser(
            string name,
            string surname,
            string login,

            string email,
            string password
            )
        {
            // validate email and login
            if (_userRepository.GetUserByEmail(email) != null)
                return BadRequest("Someone already uses this email.");

            if(_userRepository.GetUserByLogin(login) != null)
                return BadRequest("Someone already uses this login.");

            User? user = new User()
            {
                Name = name,
                Surname = surname,
                Login = login,
                CreatedTime = DateTime.UtcNow,
                Email = email
            };

            _authenticationService.Register(user, password);

            _userRepository.Insert(user);

            _userRepository.Save();
            return Ok();
        }

    }
}