using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;

namespace UserManagementSystemAPI.Contracts.Services
{

    public interface IStatusService
    {
        Task<IEnumerable<StatusResponseDto>> RetrieveStatuses();
        Task<StatusResponseDto> CreteStatus(StatusRequestDto statusRequest);
    }
}
