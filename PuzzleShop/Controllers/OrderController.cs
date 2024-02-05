using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Dto;
using PuzzleShop.Providers.Interfaces;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Services;

namespace PuzzleShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IOrderProvider _orderProvider;
        public readonly IUserRepository _userRepository;
        public readonly IAuthenticationService _auth;

        public OrderController(IOrderRepository orderRepository,
            IOrderProvider orderProvider,
            IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _orderRepository = orderRepository;
            _orderProvider = orderProvider;
            _userRepository = userRepository;
            _auth = authenticationService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody]OrderBody body)
        {
            var user = _auth.Login(body.Email, body.Password);

            if (user == null)
                return Unauthorized("Invalid login information");

            try
            {
                var order = _orderProvider.MakeOrder(user, body);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
