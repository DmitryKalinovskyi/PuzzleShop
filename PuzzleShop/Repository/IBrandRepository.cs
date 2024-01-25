using PuzzleShop.Models;

namespace PuzzleShop.Repository
{
    public interface IBrandRepository
    {
        public ICollection<Puzzle> GetBrandPuzzles(int id);
    }
}
