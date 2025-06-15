using PicPay.Entidades;

namespace PicPay.Services;

public interface ICarteiraService
{
    Task<Carteira> AddAsync(long titularId);

    Task<Carteira?> GetCarteiraByTitularId(long titularId);

    Task<Carteira> CreditSaldo(decimal valor, long titularId);

    Task<bool> DebitSaldo(decimal valor, long titularId);
}