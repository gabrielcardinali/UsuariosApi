
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi;

public class CadastroServices
{
  private readonly IMapper _mapper;
  private readonly UserManager<Usuario> _userManager;

  public CadastroServices(IMapper mapper, UserManager<Usuario> userManager)
  {
    _mapper = mapper;
    _userManager = userManager;
  }

  public async Task Cadastra(CreateUsuarioDto dto)
  {
    Usuario usuario = _mapper.Map<Usuario>(dto);

    IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

    if (!result.Succeeded)
    {
      throw new ApplicationException("Falha ao cadastrar usuário");
    }
  }
}
