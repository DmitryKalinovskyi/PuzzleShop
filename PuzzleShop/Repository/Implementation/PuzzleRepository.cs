﻿using PuzzleShop.Data;
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
        /// <param name="page">page value from 0 to infinity</param>
        /// <returns></returns>
        public ICollection<Puzzle> Search(string? search, int page = 0)
        {
            if(page < 0) throw new ArgumentOutOfRangeException(nameof(page));

            search = search?.Trim() ?? string.Empty;

            var query = _context.Puzzles.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query.Where(entity => entity.Name.Contains(search));
            }

            return query
                    .Skip(page * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
        }
    }
}
