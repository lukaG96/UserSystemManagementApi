using AutoMapper;
using UserManagementSystemAPI.DataLayer.DTOs;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;
using UserManagementSystemAPI.DataLayer.Models;

namespace UserManagementSystemAPI.Services.Mappings;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        CreateMap<UserRequestDto, User>();
        CreateMap<User, UserResponseDto>();

        CreateMap<StatusRequestDto, Status>();
        CreateMap<Status, StatusResponseDto>();

        CreateMap<UpdateUserRequestDto, User>()
           .ForAllMembers(x => x.Condition(
               (src, dest, prop) =>
               {           
                   if (prop == null) return false;
                   if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;                
                   //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                   return true;
               }
           ));
    }
}

