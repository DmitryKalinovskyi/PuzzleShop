using PuzzleShop.Models;

namespace PuzzleShop.Repository.Interfaces
{
    public interface IUserRepository: IRepository
    {
        User? GetByUserName(string userName);
    }
}
