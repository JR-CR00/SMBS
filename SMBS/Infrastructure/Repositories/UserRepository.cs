using Application.DTOs.Users.Requests;
using Application.DTOs.Users.Responses;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    public readonly AppContext _db;
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public UserRepository(AppContext db,
            ITokenService tokenService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper
            )
    {
        _db = db;
        _tokenService = tokenService;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;

    }
    public ApplicationUser? GetUser(string id)
    {
        return _db.Users.FirstOrDefault(u => u.Id == id);
    }

    public bool IsUniqueEmail(string email)
    {
        return !_db.Users.Any(u => u.Email != null && u.Email.Trim().ToLower() == email.Trim().ToLower());
    }

    public Task<ApplicationUser?> Register(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserLoginResponseDto?> Login(UserLoginDto request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return new UserLoginResponseDto()
            {
                Message = "Email and password are required.",
                Token = string.Empty,
                User = null
            };
        }



        var user = await _db.ApplicationUsers.FirstOrDefaultAsync<ApplicationUser>(u => u.Email != null && u.Email.ToLower().Trim() == request.Email.ToLower().Trim());

        if (user is null)
        {
            return new UserLoginResponseDto()
            {
                Message = "Invalid credentials.",
                Token = string.Empty,
                User = null,
                StatusCode = 401
            };
        }

        bool isValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isValid)
        {
            return new UserLoginResponseDto()
            {
                Message = "Invalid Credentials.",
                Token = string.Empty,
                User = null,
                StatusCode = 401
            };
        }

        var roles = await _userManager.GetRolesAsync(user);

        var roleSelected = roles.FirstOrDefault();

        if (string.IsNullOrEmpty(roleSelected))
        {
            return new UserLoginResponseDto()
            {
                Message = "User has no role assigned.",
                Token = string.Empty,
                User = null,
                StatusCode = 403
            };
        }

        var token = _tokenService.CreateToken(user, roleSelected);

        return new UserLoginResponseDto()
        {
            Message = "Login successful.",
            Token = token,
            User = _mapper.Map<UserDto>(user),
            StatusCode = 200
        };


    }
}