using Microsoft.EntityFrameworkCore;
using PuzzleShop.Data;
using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class BrandRepository : RepositoryBase, IBrandRepository
    {
        public BrandRepository(PuzzleShopContext context) : base(context) { }

        public const int PAGE_SIZE = 12;

        public ICollection<Brand> Search(string? search, int page = 0)
        {
            // trim spaces
            search = search?.Trim() ?? string.Empty;

            if (search == "")
            {
                return _context.Brands
                    .Skip(page * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
            }

            // filter
            return _context.Brands
                .Where(entity => entity.Name.Contains(search))
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }

        public ICollection<Puzzle> SearchBrandPuzzle(int brandId, string? search, int page = 0)
        {
            // trim spaces
            search = search?.Trim() ?? string.Empty;

            if (search == "")
            {
                return _context.Puzzles
                    .Where(entity => entity.BrandId == brandId)
                    .Skip(page * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
            }

            // filter
            return _context.Puzzles
                .Where(entity => entity.Name.Contains(search) && entity.BrandId == brandId)
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }
    }
}
