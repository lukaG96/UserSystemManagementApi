using Microsoft.EntityFrameworkCore;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.DataLayer;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;
using UserManagementSystemAPI.DataLayer.Models;
using UserManagementSystemAPI.Shared.Utils;

namespace UserManagementSystemAPI.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public UserRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public PagedList<User> RetrieveUsers(UserParametersDto userParameters) =>
            PagedList<User>.ToPagedList(_dbContext.User.OrderBy($"{userParameters.SortColumnName} {userParameters.SortTypeStr}").AsQueryable(),
                userParameters.PageNumber,
                userParameters.PageSize);
        public async Task<User?> RetrieveUser(string userName, CancellationToken cancellationToken = default) =>
            await _dbContext.User.AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserName.Equals(userName), cancellationToken);
        public async Task<bool> UserExist(string username) =>
            await _dbContext.User.AnyAsync(x => x.UserName.Equals(username));
    }
}
