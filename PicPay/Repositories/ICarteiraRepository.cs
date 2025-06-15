using PicPay.Entidades;

namespace PicPay.Repositories;

public interface ICarteiraRepository
{
    Task<Carteira> AddAsync(Carteira carteira);
    Task<Carteira?> GetById(long titularId);

    void Save();
}