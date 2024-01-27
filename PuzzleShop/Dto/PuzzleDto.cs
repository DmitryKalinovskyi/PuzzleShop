using PuzzleShop.Models;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Dto
{
    public class PuzzleDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public int BrandId { get; set; }
    }
}
