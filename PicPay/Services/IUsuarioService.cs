using PicPay.DTO_s;
using PicPay.Entidades;

namespace PicPay.Services;

public interface IUsuarioService
{
    Task<Usuario> CreateUsuario(AddUsuarioDTO usuarioDto);

    Task<Usuario?> GetUsuarioById(long usuarioId);
}