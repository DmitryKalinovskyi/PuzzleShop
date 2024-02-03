using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }

        public int OwnerId { get; set; }

        public bool IsConfirmed { get; set; }

        // Reference navigation

        public ICollection<Puzzle> Puzzles { get; set; }

        public User Owner { get; set; }
    }
}
