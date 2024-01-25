using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Models
{
    public class Puzzle
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// Images are splited by separator |
        /// Example
        /// https://link1|https://link2|https://link3
        /// </summary>
        //public string? ImagesUrl { get; set; }

        
        public string? ImageUrl { get; set; }
        
        public double Price { get; set; }

        public int Amount { get; set; }


        // Reference navigation properties

        [NotNull]
        public Brand Brand { get; set; }
    }
}
