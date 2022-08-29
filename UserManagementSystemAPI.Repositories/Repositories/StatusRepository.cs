using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.DataLayer;
using UserManagementSystemAPI.DataLayer.Models;

namespace UserManagementSystemAPI.Repositories.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public StatusRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> StatusExist(string code) =>
           await _dbContext.Status.AnyAsync(x => x.Code.Equals(code));

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            var aa = await _dbContext.Status.ToListAsync();
            return null;

        }
         
    }
}
