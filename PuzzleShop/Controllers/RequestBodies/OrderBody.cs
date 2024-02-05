namespace PuzzleShop.Controllers.RequestBodies
{
    public class OrderItem 
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }

    public class OrderBody
    {
        public List<OrderItem> OrderItems { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
