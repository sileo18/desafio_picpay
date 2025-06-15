using PicPay.Entidades;

namespace PicPay.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> AddAsync(Usuario usuario);

    Task<Usuario?> GetById(long usuarioId);
    
    Task<Usuario?> FindByEmail(string email);
    
    Task<Usuario?> FindByCpfCnpj(string cpfCnpj);
    
}