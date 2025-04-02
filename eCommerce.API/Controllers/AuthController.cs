using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]  //api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // check for invalid request
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }
        
        // user service to handle request
        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || !authenticationResponse.Success)
        {
            return BadRequest(authenticationResponse);
        }
        return Ok(authenticationResponse);
    }
    
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // check for invalid request
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }
        
        // user service to handle request
        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || !authenticationResponse.Success)
        {
            return Unauthorized(authenticationResponse);
        }
        return Ok(authenticationResponse);
    }
}