using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly AuthService _authService;

  public AuthController(AuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(UserRegisterDto dto)
  {
    var result = await _authService.RegisterUser(dto);

    if (!result.Success) return BadRequest(new { error = result.Error });

    var data = result.Data!;

    return Created($@"/api/auth/{data.Id}", new
    {
      message = "Usuario registrado!",
      user = new
      {
        id = data.Id,
        username = data.Username,
      }
    });
  }
}