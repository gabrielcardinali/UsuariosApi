using System.ComponentModel.DataAnnotations;

namespace UsuariosApi;

public class LoginUsuarioDto
{
  [Required]
  public string UserName { get; set; }
  [Required]
  public string Password { get; set; }
}
