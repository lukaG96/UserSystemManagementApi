using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;

namespace UserManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public StatusController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<StatusResponseDto>> Get() =>
          Ok(_serviceManager.StatusService.RetrieveStatuses());


        [HttpPost]
        public async Task<ActionResult<StatusResponseDto>> PostUser(StatusRequestDto statusRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _serviceManager.StatusService.CreteStatus(statusRequest));
        }

    }
}
