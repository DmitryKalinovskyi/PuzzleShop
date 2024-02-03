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

        public ICollection<Brand> Search(string? search, int page = 0, bool onlyConfirmed = true)
        {
            if (page < 0) throw new ArgumentOutOfRangeException(nameof(page));

            // trim spaces
            search = search?.Trim() ?? string.Empty;

            var query = _context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(entity => entity.Name.Contains(search));
            }

            if(onlyConfirmed)
            {
                query = query.Where(entity => entity.IsConfirmed);
            }

            // filter
            return query
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }

        public ICollection<Puzzle> SearchBrandPuzzle(int brandId, string? search, int page = 0)
        {
            if (page < 0) throw new ArgumentOutOfRangeException(nameof(page));

            // trim spaces
            search = search?.Trim() ?? string.Empty;

            var query = _context.Puzzles.Where(entity => entity.BrandId == brandId);


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(entity => entity.Name.Contains(search));
            }

            return query
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
        }

        public Brand? GetBrandByName(string name)
        {
            return _context.Brands
                .Where(entity => entity.Name == name)
                .FirstOrDefault();
        }
    }
}
