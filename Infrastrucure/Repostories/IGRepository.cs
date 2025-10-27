using System.Linq.Expressions;
using Infrastrucure.Helpers;

namespace Infrastrucure.Repostories
{
    public interface IGRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task RemoveRange(ICollection<T> entities);
        Task SaveChangesAsync();
        IQueryable<T> GetAllNoTracking();
        IQueryable<T> GetAllAsTracking();
        IQueryable<T> GetAllAsTracking(Expression<Func<T, bool>> where);
        IQueryable<T> GetAllAsTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref ResponsePagination responseDto);
        IQueryable<T> GetAllAsTracking(int pageNumber, int pageSize, ref ResponsePagination responseDto);
        IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> where);
        IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref ResponsePagination responseDto);
        IQueryable<T> GetAllAsNoTracking(int pageNumber, int pageSize, ref ResponsePagination responseDto);
    }
}
