using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Dto;
using PuzzleShop.Models;
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
        public readonly IAuthenticationService _auth;

        public OrderController(IOrderRepository orderRepository,
            IOrderProvider orderProvider,
            IAuthenticationService authenticationService)
        {
            _orderRepository = orderRepository;
            _orderProvider = orderProvider;
            _auth = authenticationService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult CreateOrder([FromBody]CreateOrderBody body)
        {
            var user = _auth.Login(body.Login);

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

        [HttpPost("{orderId}/update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(int orderId, [FromBody] UpdateOrderBody body)
        {
            var user = _auth.Login(body.Login);

            if (user == null)
                return Unauthorized("Invalid login information");

            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{orderId}/cancel")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult CancelOrder(int orderId, [FromBody]LoginBody login)
        {
            var user = _auth.Login(login);

            if (user == null)
                return Unauthorized("Invalid login information");

            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
