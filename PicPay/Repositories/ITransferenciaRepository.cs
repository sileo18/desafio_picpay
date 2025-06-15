using PicPay.Entidades;

namespace PicPay.Repositories;

public interface ITransferenciaRepository
{
    Task<Transferencia> AddAsync(Transferencia transferencia);

    Task<Transferencia?> GetById(Guid id);

    Task Save();
}