using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int OwnerId { get; set; }

        public bool IsConfirmed { get; set; }

        // Reference navigation

        public ICollection<Puzzle> Puzzles { get; set; }

        public User Owner { get; set; }
    }
}
