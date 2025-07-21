public class AuthService
{
  private readonly DBContext _context;

  public AuthService(DBContext context)
  {
    _context = context;
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
}