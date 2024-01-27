using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Dto
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
