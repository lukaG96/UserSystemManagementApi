using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.DataLayer.Models;

namespace UserManagementSystemAPI.DataLayer
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Status> Status { get; set; }
    }
}
