using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.Contracts.Services
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IUserService UserService { get; }
        IStatusService StatusService { get; }
    }
}
