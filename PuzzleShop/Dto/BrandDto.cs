using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Dto
{
    public class BrandDto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }

        public int OwnerId { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
