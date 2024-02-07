namespace PuzzleShop.Controllers.RequestBodies
{
    public class OrderItem 
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }

    public class CreateOrderBody
    {
        public List<OrderItem> OrderItems { get; set; }

        public string Address { get; set; }
        
        public LoginBody Login { get; set; }
    }
}
