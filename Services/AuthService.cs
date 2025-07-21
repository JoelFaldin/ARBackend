using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
  private readonly DBContext _context;
  private readonly IConfiguration _config;

  public AuthService(DBContext context, IConfiguration config)
  {
    _context = context;
    _config = config;
  }

  public async Task<Result<User>> RegisterUser(UserRegisterDto dto)
  {
    if (_context.Users.Any(u => u.Username == dto.Username))
    {
      throw new AppException("El usuario ya existe en la base de datos!", 400);
    }

    var hashed = BCrypt.Net.BCrypt.HashPassword(dto.Password);
    var user = new User { Username = dto.Username, Password = hashed };
    _context.Users.Add(user);

    await _context.SaveChangesAsync();
    return Result<User>.Ok(user);
  }

  public async Task<Result<LoginResultDto>> Login(UserLoginDto dto)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

    if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
    {
      throw new AppException("Credenciales incorrectas.", 400);
    }

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_config["Jwt:key"]!);

    var tokenDesc = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[] {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
      }),
      Expires = DateTime.UtcNow.AddDays(1),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
    };

    var token = tokenHandler.CreateToken(tokenDesc);

    var result = new LoginResultDto
    {
      Token = tokenHandler.WriteToken(token),
      User = new UserDto
      {
        Id = user.Id,
        Username = user.Username,
      }
    };

    return Result<LoginResultDto>.Ok(result);
  }
}