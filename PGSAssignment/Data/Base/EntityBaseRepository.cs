using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PGSAssignment.Data.Paging;

namespace PGSAssignment.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync(int pageSize,int? pageNumber)
        {
            var AllItems = await _context.Set<T>().ToListAsync();

            // Paging
            if (pageNumber!=null && pageNumber!=null)
            {
                AllItems = PaginatedList<T>.Create(AllItems.AsQueryable(), pageNumber ?? 1, pageSize);
            }

            return AllItems;
        }


        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
