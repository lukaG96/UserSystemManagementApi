using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;
using UserManagementSystemAPI.DataLayer.Models;
using UserManagementSystemAPI.Shared.Constants;
using UserManagementSystemAPI.Shared.Exceptions;
using UserManagementSystemAPI.Shared.Utils;

namespace UserManagementSystemAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> CreteUser(UserRequestDto userRequest)
        {
            if (userRequest.Password != userRequest.ConfirmPassword)
                throw new OperationFailedException(ErrorMessages.PasswordsDoNotMatch);


            if (await _repositoryManager.UserRepository.UserExist(userRequest.UserName))
                throw new OperationFailedException(ErrorMessages.UsernameAlreadyExists);

            string salt = PasswordUtils.GenerateSalt();
            userRequest.Password = PasswordUtils.GenerateSaltedHash(userRequest.Password, salt);

            User newUser = _mapper.Map<User>(userRequest);
            newUser.Salt = salt;

            await _repositoryManager.UserRepository.CreateAsync(newUser);

            if (await _repositoryManager.UnitOfWork.SaveChangesAsync() == 0)
                throw new OperationFailedException(ErrorMessages.Error);


            return _mapper.Map<UserResponseDto>(newUser);
        }
        public async Task<UserResponseDto> RetrieveUser(Guid userId) =>

            _mapper.Map<UserResponseDto>(await _repositoryManager.UserRepository.FindBy(x => x.Id == userId).FirstAsync());

        public IEnumerable<UserResponseDto> RetrieveUsers(UserParametersDto userParameters) =>
             _mapper.Map<IEnumerable<UserResponseDto>>(_repositoryManager.UserRepository.RetrieveUsers(userParameters));


        public async Task DeleteUser(Guid userID)
        {
            User dbUser = await _repositoryManager.UserRepository.FindBy(x => x.Id == userID).FirstAsync();
            _repositoryManager.UserRepository.Delete(dbUser);

            if (await _repositoryManager.UnitOfWork.SaveChangesAsync() == 0)
                throw new OperationFailedException(ErrorMessages.Error);
        }

        public async Task UpdateUser(Guid userID, UpdateUserRequestDto updateUser)
        {
            var dbUser = await _repositoryManager.UserRepository.FindBy(x => x.Id == userID).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new OperationFailedException(ErrorMessages.UserNotfound);

            _mapper.Map(updateUser,dbUser);
            _repositoryManager.UserRepository.Update(dbUser);

            if (await _repositoryManager.UnitOfWork.SaveChangesAsync() == 0)
                throw new OperationFailedException(ErrorMessages.Error);
        }

    }
}
