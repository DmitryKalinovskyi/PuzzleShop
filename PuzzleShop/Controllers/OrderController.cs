using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Dto;
using PuzzleShop.Providers.Interfaces;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Services;

namespace PuzzleShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult CreateOrder(OrderBody body)
        {
            var user = _auth.Login(body.email, body.password);

            if (user == null)
                return Unauthorized("Invalid login information");

            // retrive information about ordered items
            if (_orderProvider.ValidateOrderBody(body) == false)
                return BadRequest();

            _orderProvider.MakeOrder(user, body.OrderItems);

            return Ok();
        }
    }
}
