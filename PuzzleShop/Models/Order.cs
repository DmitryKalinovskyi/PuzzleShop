using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Models
{
    public enum OrderStatus
    {
        Created = 1,
        InDeliver,
        Delivered, 

        // just store in the history
        Completed, 
        Canceled, // client decided to break the order
        Failed, // failed due to accident

        Confirmed // the state before delivering
    }

    [Index(nameof(Status), IsUnique = false)]
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

        public string DestinationPlace { get; set; }

        public int? UserMakedId { get; set; }
    }
}
