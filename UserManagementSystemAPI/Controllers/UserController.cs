using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;


namespace UserManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser([FromRoute] Guid id) => Ok(await _serviceManager.UserService.RetrieveUser(id));

        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IEnumerable<UserResponseDto>> Get([FromQuery] UserParametersDto userParameters) =>
            Ok( _serviceManager.UserService.RetrieveUsers(userParameters));

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> PostUser(UserRequestDto userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _serviceManager.UserService.CreteUser(userRequest));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _serviceManager.UserService.DeleteUser(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateUserRequestDto model)
        {
            await _serviceManager.UserService.UpdateUser(id,model);
            return Ok(new { message = "User updated" });
        }
    }
}
