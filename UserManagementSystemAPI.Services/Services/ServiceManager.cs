using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.Contracts.Services;

namespace UserManagementSystemAPI.Services.Services
{
    /// <summary>
    /// ServiceManager - wrapper for other services
    /// </summary>
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _lazyAuthService;
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IStatusService> _lazyStatusService;


        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(repositoryManager));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _lazyStatusService = new Lazy<IStatusService>(() => new StatusService(repositoryManager, mapper));
     
          
        }

        public IAuthService AuthService => _lazyAuthService.Value;
        public IUserService UserService => _lazyUserService.Value;
        public IStatusService StatusService => _lazyStatusService.Value;

 
    }
}
