using PuzzleShop.Data;
using PuzzleShop.Repository.Interfaces;

namespace PuzzleShop.Repository.Implementation
{
    /// <summary>
    /// Extends functionality for Repository Base class
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(PuzzleShopContext context) : base(context) { }
    }
}
