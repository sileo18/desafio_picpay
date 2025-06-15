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
        usuario.TipoUsuario = usuarioDto.TiposUsuario;
        return usuario;
    }

    public ResponseUsuarioDto UsuarioToReponseUsuarioDto(Usuario usuario)
    {
        if (usuario == null)
        {
            return null; 
        }
        
        ResponseUsuarioDto response = new ResponseUsuarioDto(usuario.Nome, usuario.Id);

        return response;
    }
}