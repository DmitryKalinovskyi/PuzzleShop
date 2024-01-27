namespace PuzzleShop.Repository.Interfaces
{
    /// <summary>
    /// Interface defines the basic CRUD operations 
    /// </summary>
    public interface IRepository
    {
        TEntity? GetById<TEntity, TKeyType> (TKeyType key) where TEntity : class;
        ICollection<TEntity> GetAll<TEntity>() where TEntity : class;

        void Insert<TEntity>(TEntity entity) where TEntity : class; 
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        Task<TEntity?> GetByIdAsync<TEntity, TKeyType>(TKeyType key) where TEntity : class;
        Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        Task InsertAsync<TEntity>(TEntity entity)where TEntity : class;

        void Save();
    }
}
