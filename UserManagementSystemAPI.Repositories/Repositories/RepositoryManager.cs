using Microsoft.Extensions.Configuration;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.DataLayer;
using UserManagementSystemAPI.Repositories.Repositories;

namespace UserManagementSystemAPI.Repositories
{
    /// <summary>
    /// RepositoryManager - wrapper for other repositories
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IStatusRepository> _lazyStatusRepository;


        public RepositoryManager(RepositoryDbContext dbContext, IConfiguration configuration)
        {
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyStatusRepository = new Lazy<IStatusRepository>(() => new StatusRepository(dbContext));

        }
        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IStatusRepository StatusRepository => _lazyStatusRepository.Value;

    }
}
