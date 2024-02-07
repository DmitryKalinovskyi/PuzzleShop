using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Models;

namespace PuzzleShop.Providers.Interfaces
{
    public interface IOrderProvider
    {
        public Order MakeOrder(User user, CreateOrderBody body);

        public void UpdateOrder(User user, Order order, UpdateOrderBody body);

        public void CancelOrder(User user, Order order);
    }
}
