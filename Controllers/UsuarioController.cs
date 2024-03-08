using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  [HttpPost]
  public IActionResult CadastraUsuario(CreateUsuarioDto dto)
  {
    throw new NotImplementedException();
  }
}
