using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.DataLayer;

namespace UserManagementSystemAPI.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private RepositoryDbContext DbContext { get; set; }
        public GenericRepository(RepositoryDbContext context)
        {
            DbContext = context;
        }



        public virtual IQueryable<T> FindAll()
        {
            return DbContext.Set<T>();
        }

        public async virtual Task<T> FindFirstAsync()
        {
            return await DbContext.Set<T>().FirstAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression);
        }

        public async virtual Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().AnyAsync(expression);
        }

        public async virtual Task<T> CreateAsync(T entity)
        {
            return (await DbContext.Set<T>().AddAsync(entity)).Entity;
        }

        public async virtual Task CreateAllAsync(List<T> entity)
        {
            await DbContext.Set<T>().AddRangeAsync(entity);
        }

        public virtual T Update(T entity)
        {
            return DbContext.Set<T>().Update(entity).Entity;
        }

        public virtual void UpdateAll(IEnumerable<T> entity)
        {
            DbContext.Set<T>().UpdateRange(entity);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void DeleteAll(List<T> entity)
        {
            DbContext.Set<T>().RemoveRange(entity);
        }
    }
}
