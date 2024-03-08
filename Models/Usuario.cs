using Microsoft.AspNetCore.Identity;

namespace UsuariosApi;

public class Usuario : IdentityUser
{
  public DateTime DataNascimento { get; set; }
  public Usuario() : base() { }
}
