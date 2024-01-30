using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Dto
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Login { get; set; }

        DateTime CreatedTime { get; set; }
    }
}
