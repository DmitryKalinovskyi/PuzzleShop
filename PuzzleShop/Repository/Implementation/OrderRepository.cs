using AutoMapper.Internal;
using PuzzleShop.Data;
using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(PuzzleShopContext context) : base(context) { }
    }
}
