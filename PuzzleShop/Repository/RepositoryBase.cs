using Microsoft.EntityFrameworkCore;
using PuzzleShop.Data;
using PuzzleShop.Models;

namespace PuzzleShop.Repository
{
    public class RepositoryBase : IRepository
    {
        protected PuzzleShopContext _context;
        public RepositoryBase(PuzzleShopContext context)
        {
            _context = context;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
        }

        public ICollection<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity? GetById<TEntity, TKeyType>(TKeyType key) where TEntity : class
        {
            return _context.Find<TEntity>(key);
        }

        public async Task<TEntity?> GetByIdAsync<TEntity, TKeyType>(TKeyType key) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Add(entity);
        }

        public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.AddAsync(entity);
        }

        public void Save()
        {
            _context.SaveChanges(); 
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
