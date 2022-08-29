using UserManagementSystemAPI.DataLayer.DTOs;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;

namespace UserManagementSystemAPI.Contracts.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreteUser(UserRequestDto userRequest);
        Task<UserResponseDto> RetrieveUser(Guid userId);
        IEnumerable<UserResponseDto> RetrieveUsers(UserParametersDto userParameters);
        Task UpdateUser(Guid userID, UpdateUserRequestDto updateUser);
        Task DeleteUser(Guid userID);
    }
}
