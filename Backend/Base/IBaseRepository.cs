using System.Linq.Expressions;

namespace BlogOnline.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(Guid id);

        public Task<IEnumerable<T>> GetAllAsync();

        public  Task<T> AddAsync(T entity);


        public Task<T> UpdateAsync(T entity);

        public  Task<Guid> RemoveAsync(T entity);


        public Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);
    }
}
