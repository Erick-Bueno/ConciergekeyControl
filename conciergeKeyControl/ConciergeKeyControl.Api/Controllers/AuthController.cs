using Microsoft.AspNetCore.Mvc;

[Route("Api/[Controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuhtService _AuthService;
    public AuthController(IAuhtService authService)
    {
        _AuthService = authService;
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto){
        var response = await _AuthService.Register(userRegisterDto);
        return this.RegisterUserResponse(response);
    }
}