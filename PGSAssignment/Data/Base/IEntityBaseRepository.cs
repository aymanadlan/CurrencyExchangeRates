namespace PGSAssignment.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync(int pageSize,int? pageNumber);

        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(int id ,T entity);
    }
}
