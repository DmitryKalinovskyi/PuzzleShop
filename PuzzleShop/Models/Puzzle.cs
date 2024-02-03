using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Models
{
    [Index(nameof(Name), IsUnique = false)]
    public class Puzzle
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }

        /// <summary>
        /// Images are splited by separator |
        /// Example
        /// https://link1|https://link2|https://link3
        /// </summary>
        //public string? ImagesUrl { get; set; }
        
        public string? ImageUrl { get; set; }

        [Precision(2)]
        public double Price { get; set; }

        public int Amount { get; set; }

        public int BrandId { get; set; }
        // Reference navigation properties

        [NotNull]
        public Brand Brand { get; set; }
    }
}
