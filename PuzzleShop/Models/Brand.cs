using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        // Reference navigation

        public ICollection<Puzzle> Puzzles { get; set; }
    }
}
