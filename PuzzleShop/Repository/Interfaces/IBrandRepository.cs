using PuzzleShop.Models;

namespace PuzzleShop.Repository.Interfaces
{
    public interface IBrandRepository: IRepository
    {
        public ICollection<Puzzle> GetBrandPuzzles(int id);
    }
}
