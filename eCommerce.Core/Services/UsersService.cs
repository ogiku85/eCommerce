using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
        
      //  return new AuthenticationResponse(user.UserID, user.Email, user.PersonName,
      //      user.Gender, "token", true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Email = request.Email,
            Gender = request.Gender.ToString(),
            PersonName = request.PersonName,
            Password = request.Password
        };
       ApplicationUser? registeredUser =  await _userRepository.AddUser(user);

       if (registeredUser == null)
       {
           return null;
       }
       
       return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
     //  return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName,
       //    registeredUser.Gender.ToString(), "token", true);
    }
}