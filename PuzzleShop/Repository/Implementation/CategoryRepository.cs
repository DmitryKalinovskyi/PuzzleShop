using PuzzleShop.Data;
using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(PuzzleShopContext context) : base(context) { }
    }
}
