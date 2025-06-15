using PicPay.DTO_s;
using PicPay.Entidades;

namespace PicPay.Mappers;

public class UsuarioMapper
{


    public Usuario AddUsuarioDtoToUsuario(AddUsuarioDTO usuarioDto)
    {
        Usuario usuario = new Usuario();

        usuario.CpfCnpj = usuarioDto.CpfCnpj;
        usuario.Email = usuarioDto.Email;
        usuario.Nome = usuarioDto.Nome;
        usuario.Senha = usuarioDto.Senha;

        return usuario;
    }
}