using PuzzleShop.Models;

namespace PuzzleShop.Repository.Interfaces
{
    public interface IPuzzleRepository: IRepository
    {
        public ICollection<Puzzle> Search(string? search, int page);
    }
}
