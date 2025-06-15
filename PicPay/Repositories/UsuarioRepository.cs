using Microsoft.EntityFrameworkCore;
using PicPay.Entidades;
using PicPay.Infra;

namespace PicPay.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Usuario> AddAsync(Usuario usuario)
    {
         _context.Usuarios.Add(usuario);
         await _context.SaveChangesAsync();

         return usuario;
    }

    public async Task<Usuario?> GetById(long usuarioId)
    {
       return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
    }

    public async Task<Usuario?> FindByEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario?> FindByCpfCnpj(string cpfCnpj)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.CpfCnpj == cpfCnpj);
    }
}