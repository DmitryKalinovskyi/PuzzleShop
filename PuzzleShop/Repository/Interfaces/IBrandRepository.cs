using PuzzleShop.Models;

namespace PuzzleShop.Repository.Interfaces
{
    public interface IBrandRepository: IRepository
    {
        public ICollection<Brand> Search(string? search, int page, bool onlyConfirmed = true);
        
        public ICollection<Puzzle> SearchBrandPuzzle(int brandId, string? search, int page);

        public Brand? GetBrandByName(string name);
    }
}
