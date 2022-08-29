using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.DataLayer;

namespace UserManagementSystemAPI.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _dbContext;

        public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Save new changes async in Db
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);


    }
}
