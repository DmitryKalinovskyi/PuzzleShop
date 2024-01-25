using Microsoft.EntityFrameworkCore;
using PuzzleShop.Data;
using PuzzleShop.Models;

namespace PuzzleShop.Repository
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class BrandRepository : RepositoryBase, IBrandRepository
    {
        public BrandRepository(PuzzleShopContext context) : base(context) { }

        public ICollection<Puzzle> GetBrandPuzzles(int id)
        {
            return _context.Puzzles.Where(p => p.BrandId == id).ToList();
        }
    }
}
