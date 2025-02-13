﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PuzzleShop.Models;
using System.Reflection.Metadata;

namespace PuzzleShop.Data
{
    public class PuzzleShopContext: DbContext
    {
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPuzzle> OrderPuzzles { get; set; }

        public PuzzleShopContext(DbContextOptions<PuzzleShopContext> optionsBuilder): base(optionsBuilder)
        {
        }
    }
}
