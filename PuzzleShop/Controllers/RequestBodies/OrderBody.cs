namespace PuzzleShop.Controllers.RequestBodies
{
    public class OrderItem 
    {
        public int Id;
        public int Amount;
    }

    public class OrderBody
    {
        public List<OrderItem> OrderItems;

        public string email;
        public string password;
    }
}
