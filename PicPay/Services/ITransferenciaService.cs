using PicPay.Entidades;

namespace PicPay.Services;

public interface ITransferenciaService
{
    Task<Transferencia> CreateTransferencia(long idCredor, long idTomador, decimal valor);

    Task<Transferencia?> GetTransferenciaById(Guid idTransferencia);
}