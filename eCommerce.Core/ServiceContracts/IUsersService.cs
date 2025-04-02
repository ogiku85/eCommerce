using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    /// <summary>
    /// Method to handle user login case and return Authentication Response object
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest request);
    
    /// <summary>
    /// Method to handle user registartion case and return Authentication Response object
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest request);
}