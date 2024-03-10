using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly UserManager<Usuario> _userManager;

  public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
  {
    _mapper = mapper;
    _userManager = userManager;
  }

  [HttpPost("cadastro")]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
  {
    Usuario usuario = _mapper.Map<Usuario>(dto);

    IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

    if (result.Succeeded)
    {
      return Ok("Usuário cadastrado!");
    }

    throw new ApplicationException("Falha ao cadastrar usuário");
  }
}
