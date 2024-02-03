using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Models;

namespace PuzzleShop.Providers.Interfaces
{
    public interface IOrderProvider
    {
        public bool ValidateOrderBody(OrderBody body);

        public Order MakeOrder(User user, List<OrderItem> puzzles);
    }
}
