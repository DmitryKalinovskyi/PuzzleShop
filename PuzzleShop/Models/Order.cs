using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    //[Flags]
    public enum OrderStatus
    {
        Created = 1,
        InDeliver = 2,
        Delivered = 3, 

        // just store in the history
        Tooken = 4, 
        Canceled = 5, // client decided to break the order
        Failed = 6 // failed due to accident
    }

    [Index(nameof(OrderStatus), IsUnique = false)]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }


        /// <summary>
        /// This field are indexed, to speed up work with orders
        /// </summary>
        public OrderStatus Status { get; set; }

        [Precision(2)]
        public double TotalPrice { get; set; }
    }
}
