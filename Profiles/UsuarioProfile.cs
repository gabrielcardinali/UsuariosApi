using AutoMapper;

namespace UsuariosApi;

public class UsuarioProfile : Profile
{
  public UsuarioProfile()
  {
    CreateMap<CreateUsuarioDto, Usuario>();
  }
}
