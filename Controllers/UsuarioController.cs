using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  private readonly UsuarioServices _usuarioService;

  public UsuarioController(UsuarioServices usuarioService)
  {
    _usuarioService = usuarioService;
  }

  [HttpPost("cadastro")]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
  {
    await _usuarioService.Cadastra(dto);
    return Ok("Usuário Cadastrado!");
  }

  [HttpPost("login")]
  public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
  {
    var token = await _usuarioService.Login(dto);
    return Ok(token);
  }
}
