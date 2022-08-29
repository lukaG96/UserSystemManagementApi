using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.Contracts.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);
        Task<T> FindFirstAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task CreateAllAsync(List<T> entity);
        T Update(T entity);
        void UpdateAll(IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteAll(List<T> entity);
    }
}
