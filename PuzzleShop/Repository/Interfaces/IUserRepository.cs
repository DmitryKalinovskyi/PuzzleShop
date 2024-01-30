using PuzzleShop.Models;

namespace PuzzleShop.Repository.Interfaces
{
    public interface IUserRepository: IRepository
    {
        User? GetUserByLogin(string login);
    }
}
