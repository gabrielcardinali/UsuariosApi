using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  private readonly CadastroServices _cadastroService;

  public UsuarioController(CadastroServices cadastroService)
  {
    _cadastroService = cadastroService;
  }

  [HttpPost("cadastro")]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
  {
    await _cadastroService.Cadastra(dto);
    return Ok("Usuário Cadastrado!");
  }
}
