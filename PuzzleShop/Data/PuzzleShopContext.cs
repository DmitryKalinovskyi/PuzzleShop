using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PuzzleShop.Models;
using System.Reflection.Metadata;

namespace PuzzleShop.Data
{
    public class PuzzleShopContext: DbContext
    {
        public DbSet<Puzzle> Puzzles { get; set; }

        public PuzzleShopContext(DbContextOptions<PuzzleShopContext> optionsBuilder): base(optionsBuilder)
        {
        }
    }
}
