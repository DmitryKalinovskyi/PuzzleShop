using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public bool IsAdmin { get; set; }
    }
}
