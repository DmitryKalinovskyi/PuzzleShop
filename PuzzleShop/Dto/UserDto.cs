using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Dto
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Surname { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [NotNull]
        public string? Login { get; set; }

        DateTime CreatedTime { get; set; }
    }
}
