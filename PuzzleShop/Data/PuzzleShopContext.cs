using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PuzzleShop.Models;
using System.Reflection.Metadata;

namespace PuzzleShop.Data
{
    public class PuzzleShopContext: IdentityDbContext<User>
    {
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users{ get; set; }

        public PuzzleShopContext(DbContextOptions<PuzzleShopContext> optionsBuilder): base(optionsBuilder)
        {
        }
    }
}
