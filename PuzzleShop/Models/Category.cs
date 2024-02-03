using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
