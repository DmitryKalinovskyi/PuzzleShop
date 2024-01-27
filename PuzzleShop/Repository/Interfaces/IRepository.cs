namespace PuzzleShop.Repository.Interfaces
{
    
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


    // Strong type implementation
    /// <summary>
    /// Interface defines the basic CRUD operations 
    /// </summary>
    //public interface IRepository<TEntity, TKeyType> where TEntity : class where TKeyType : struct 
    //{
    //    TEntity? GetById(TKeyType key);
    //    ICollection<TEntity> GetAll();

    //    void Insert(TEntity entity);
    //    void Update(TEntity entity);
    //    void Delete(TEntity entity);

    //    Task<TEntity?> GetByIdAsync(TKeyType key);
    //    Task<ICollection<TEntity>> GetAllAsync();

    //    Task InsertAsync(TEntity entity);

    //    void Save();
    //}

}
