using Microsoft.EntityFrameworkCore;

namespace PuzzleShop.Models
{
    [PrimaryKey(nameof(OrderId), nameof(PuzzleId))]
    public class OrderPuzzle
    {
        public int OrderId { get; set; }

        public int? PuzzleId { get; set; }

        /// <summary>
        /// Price at the moment of order
        /// </summary>
        [Precision(2)]
        public double FixedPrice { get; set; }

        public int Amount { get; set; }

        // reference navigation

        public Order Order { get; set; }

        public Puzzle? Puzzle { get; set; }
    }
}
