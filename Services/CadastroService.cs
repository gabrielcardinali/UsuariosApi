
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi;

public class UsuarioService
{
  private readonly IMapper _mapper;
  private readonly UserManager<Usuario> _userManager;
  private readonly SignInManager<Usuario> _signInManager;
  private readonly TokenService _tokenService;

  public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
  {
    _mapper = mapper;
    _userManager = userManager;
    _signInManager = signInManager;
    _tokenService = tokenService;
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

  public async Task<string> Login(LoginUsuarioDto dto)
  {
    var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

    if (!result.Succeeded)
    {
      throw new ApplicationException("Usuário não atenticado");
    }

    var usuario = _signInManager
      .UserManager
      .Users
      .FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper());

    var token = _tokenService.GenerateToken(usuario);

    return token;
  }
}