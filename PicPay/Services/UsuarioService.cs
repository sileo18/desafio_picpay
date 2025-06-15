using PicPay.DTO_s;
using PicPay.Entidades;
using PicPay.Mappers;
using PicPay.Repositories;

namespace PicPay.Services;

public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }


    public async Task<Usuario> CreateUsuario(AddUsuarioDTO usuarioDto)
    {
        var existeUsuarioCpfCnpj  = await _repository.FindByCpfCnpj(usuarioDto.CpfCnpj);

        var existeUsuarioEmail = await _repository.FindByEmail(usuarioDto.Email);
        
        if (existeUsuarioCpfCnpj != null)
        {
            throw new ArgumentException("CPF/CNPJ já cadastrado!");
        }
        
        if (existeUsuarioEmail != null)
        {
            throw new ArgumentException("Email já cadastrado!");
        }
        
        UsuarioMapper mapper = new UsuarioMapper();

        Usuario usuario = mapper.AddUsuarioDtoToUsuario(usuarioDto);

        Usuario response = await _repository.AddAsync(usuario);

        return response;

    }

    public Task<Usuario?> GetUsuarioById(long usuarioId)
    {
        return _repository.GetById(usuarioId);
        
    }
}