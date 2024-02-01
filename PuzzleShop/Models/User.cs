using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Login), IsUnique = true)]
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

        [StringLength(50, MinimumLength = 3)]
        [NotNull]
        public string? Login { get; set; }

        [NotNull]
        public string PasswordHash { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
