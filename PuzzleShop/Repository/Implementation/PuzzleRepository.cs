using PuzzleShop.Data;
using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class PuzzleRepository : RepositoryBase, IPuzzleRepository
    {
        public PuzzleRepository(PuzzleShopContext context) : base(context) { }


        const int PAGE_SIZE = 12;

        /// <summary>
        /// Search function with pagination
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page">page value from 1 to infinity</param>
        /// <returns></returns>
        public ICollection<Puzzle> Search(string? search, int page = 0)
        {
            // first page values from 0..PAGE_SIZE-1
            // second page values from PAGE_SIZE..2*PAGE_SIZE-1

            if (search == null || search == "")
            {
                return _context.Puzzles
                    .Skip(page * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
            }

            // filter
            return _context.Puzzles
                .Where(entity => entity.Name.Contains(search))
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }
    }
}
