using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.Contracts.Repository;

namespace UserManagementSystemAPI.Repositories.Repositories
{
    public class TokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenRepository(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
    }
}
