using Microsoft.EntityFrameworkCore;
using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Data;
using PuzzleShop.Exceptions;
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

        public void CancelOrder(User user, Order order)
        {
            if (user.IsAdmin == false && order.UserMakedId != user.Id)
                throw new UnauthorizedAccessException("User don't have access to this order.");

            switch (order.Status)
            {
                case OrderStatus.Completed:
                    {
                        throw new InvalidOperationException("Order is completed.");
                    }

                case OrderStatus.Canceled:
                    {
                        throw new InvalidOperationException("Order is already canceled.");
                    }

                case OrderStatus.Failed:
                    {
                        throw new InvalidOperationException("Order can't be canceled, because order is failed.");
                    }
                default:
                    {
                        order.Status = OrderStatus.Canceled;
                    }break;
            }
        }

        public Order MakeOrder(User user, CreateOrderBody body)
        {
            // is enought or not?
            foreach (var orderItem in body.OrderItems)
            {
                Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(orderItem.Id);
                int amount = orderItem.Amount;

                if (puzzle == null)
                    throw new ArgumentNullException($"Puzzle by id: {orderItem.Id} not founded!");

                if(puzzle.Amount < amount)
                    throw new InsuffienceProductAmountException();
            }

            // at this point suppose the model is valid

            var order = new Order()
            {
                CreatedTime = DateTime.Now,
                DestinationPlace = body.Address,
                Status = OrderStatus.Created
            };

            double totalPrice = 0;

            foreach (var orderItem in body.OrderItems)
            {
                Puzzle? puzzle = _puzzleRepository.GetById<Puzzle, int>(orderItem.Id);
                int amount = orderItem.Amount;
                
                if (puzzle == null)
                    throw new ArgumentNullException($"Puzzle by id: {orderItem.Id} not founded!");

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

        public void UpdateOrder(User user, Order order, UpdateOrderBody body)
        {
            if (user.IsAdmin == false && order.UserMakedId != user.Id)
                throw new UnauthorizedAccessException("User don't have access to this order.");

            if(body.DestinationPlace != order.DestinationPlace)
            {
                if(order.Status == OrderStatus.Created || order.Status == OrderStatus.Confirmed)
                {
                    order.DestinationPlace = body.DestinationPlace;
                }
                else
                {
                    throw new InvalidOperationException("You can't change address when delivering started.");
                }
            }
        }
    }
}
