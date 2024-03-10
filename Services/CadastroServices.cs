
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi;

public class UsuarioServices
{
  private readonly IMapper _mapper;
  private readonly UserManager<Usuario> _userManager;
  private readonly SignInManager<Usuario> _signInManager;

  public UsuarioServices(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
  {
    _mapper = mapper;
    _userManager = userManager;
    _signInManager = signInManager;
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

  public async Task Login(LoginUsuarioDto dto)
  {
    var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

    if (!result.Succeeded)
    {
      throw new ApplicationException("Usuário não atenticado");
    }
  }
}