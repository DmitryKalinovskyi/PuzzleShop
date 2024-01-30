using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Surname { get; set; }

        [StringLength(320)]
        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string PasswordHash { get; set; }

        public string Adress { get; set; }

        DateTime CreatedTime { get; set; }

        public bool IsAdmin { get; set; }
    }
}
