using PuzzleShop.Models;

namespace PuzzleShop.Controllers.RequestBodies
{
    public class UpdateOrderBody
    {
        public string DestinationPlace { get; set; }

        public LoginBody Login { get; set; }
    }
}
