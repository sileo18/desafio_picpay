using Microsoft.EntityFrameworkCore;
using PicPay.Entidades;
using PicPay.Infra;

namespace PicPay.Repositories;

public class CarteiraRepository : ICarteiraRepository
{
    private readonly ApplicationDbContext _context;

    public CarteiraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Carteira> AddAsync(Carteira carteira)
    {
        _context.Add(carteira);
        await _context.SaveChangesAsync();

        return carteira;
    }

    public async Task<Carteira?> GetById(long titularId)
    {
        return await _context.Carteiras
            .Include(c => c.Titular)
            .FirstOrDefaultAsync(c => c.TitularId == titularId);
    }

    public async Task<Carteira?> GetByTitularIdAsync(long titularId)
    {
        return await _context.Carteiras
            .FirstOrDefaultAsync(c => c.TitularId == titularId);
    }

    public async Task Save()
    {
       await _context.SaveChangesAsync();
    }
}