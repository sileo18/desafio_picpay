using Microsoft.EntityFrameworkCore;
using PicPay.Entidades;
using PicPay.Infra;

namespace PicPay.Repositories;

public class TransferenciaRepository : ITransferenciaRepository
{
    private readonly ApplicationDbContext _context;

    public TransferenciaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Transferencia> AddAsync(Transferencia transferencia)
    {
        await _context.AddAsync(transferencia);
        await _context.SaveChangesAsync();
        return transferencia;
    }

    public async Task<Transferencia?> GetById(Guid idTransferencia)
    {
        return await _context.Transferencias
            .FirstOrDefaultAsync(t => t.IdTransferencia == idTransferencia);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}