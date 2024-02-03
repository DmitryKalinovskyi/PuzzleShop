using Microsoft.EntityFrameworkCore;
using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Data;
using PuzzleShop.Models;
using PuzzleShop.Providers.Interfaces;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Providers.Implementation
{
    public class OrderProvider: IOrderProvider
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly PuzzleShopContext _context;

        public OrderProvider(PuzzleShopContext context, IPuzzleRepository puzzleRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _puzzleRepository = puzzleRepository;
            _orderRepository = orderRepository;
        }

        public bool ValidateOrderBody(OrderBody body)
        {
            return true;
        }

        // working on...
        public Order MakeOrder(User user, List<OrderItem> puzzlesAmount)
        {
            // at this point suppose the model is valid

            var order = new Order()
            {
                CreatedTime = DateTime.Now,
                DestinationPlace = user.Address,
                Status = OrderStatus.Created
            };

            double totalPrice = 0;

            foreach (var puzzleAmount in puzzlesAmount)
            {
                Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(puzzleAmount.Id);
                int amount = puzzleAmount.Amount;

                if (puzzle == null)
                    throw new ArgumentNullException($"Puzzle by id: {puzzleAmount.Id} not founded!");

                double fixedPrice = puzzle.Price * amount;

                var orderPuzzle = new OrderPuzzle()
                {
                    FixedPrice = fixedPrice,
                    Amount = amount,

                    Puzzle = puzzle,
                    Order = order
                };

                totalPrice += fixedPrice;
                puzzle.Amount -= amount;

                _context.Add(orderPuzzle);
            }

            order.TotalPrice = totalPrice;
            _context.Add(order);

            _context.SaveChanges();
            return order;
        }
    }
}
