using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs;

namespace UserManagementSystemAPI.Services.Services
{
    /// <summary>
    /// AuthService for user Authentication
    /// </summary>
    internal sealed class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AuthService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        /// <summary>
        /// Create new JWT token and refresh token for user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="PasswordException"></exception>
        public async Task<string> GetToken(TokenUserDto user, HttpRequest request, HttpResponse response, CancellationToken cancellationToken = default)
        {
            //var userDb = await Login(user.Username, user.Password, cancellationToken);

            //var token = await _repositoryManager.TokenRepository.CreateToken(user, userDb.Id, cancellationToken);
            //var (refreshToken, expirationTime) = _repositoryManager.TokenRepository.GenerateRefreshToken(request, response);

            //await _redisService.SetRecordAsync($"token:{user.UserUuid}", new RefreshTokenCacheItem(refreshToken, DateTime.Now.AddDays(expirationTime)));

            //return token;
            return null;
        }
        private async Task Login(string username, string password, CancellationToken cancellationToken = default)
        {
            //var userDb = await _repositoryManager.UserRepository.GetUserByUsernameForToken(username, cancellationToken);

            //if (userDb is null)
            //    throw new UserNotFoundException(username);

            //if (!VerifyPasswordHash(password, userDb.PasswordHash, userDb.PasswordSalt))
            //    throw new PasswordException(username);

            //return userDb;
        }
    }
}
