using PuzzleShop.Data;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class PuzzleRepository : RepositoryBase, IPuzzleRepository
    {
        public PuzzleRepository(PuzzleShopContext context) : base(context) { }
    }
}
