using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Models;

namespace PuzzleShop.Providers.Interfaces
{
    public interface IOrderProvider
    {
        public Order MakeOrder(User user, OrderBody body);
    }
}
