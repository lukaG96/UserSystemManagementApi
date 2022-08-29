using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs;

namespace UserManagementSystemAPI.Controllers;


/// <summary>
/// AuthController - for create JWT token
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    /// <summary>
    /// AuthController
    /// </summary>
    /// <param name="serviceManager"></param>
    public AuthController(IServiceManager serviceManager) =>
        _serviceManager = serviceManager;

    /// <summary>
    /// Get new JWT accessToken
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// accessToken, refreshToken
    /// </returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="PasswordException"></exception>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] TokenUserDto user, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(new
        {
            //access_token = await _serviceManager.AuthService.GetToken(user, Request, Response, cancellationToken)
        });
    }
}

