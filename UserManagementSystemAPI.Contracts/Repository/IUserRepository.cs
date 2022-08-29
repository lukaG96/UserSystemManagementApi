using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.Models;
using UserManagementSystemAPI.Shared.Utils;

namespace UserManagementSystemAPI.Contracts.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        PagedList<User> RetrieveUsers(UserParametersDto userParameters);
        Task<bool> UserExist(string username);
        Task<User?> RetrieveUser(string userName, CancellationToken cancellationToken = default);
    }
}
