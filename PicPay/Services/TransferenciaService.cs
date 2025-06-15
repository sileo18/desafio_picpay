using PicPay.Entidades;
using PicPay.Repositories;

namespace PicPay.Services;

public class TransferenciaService : ITransferenciaService
{
    private readonly ITransferenciaRepository _transferenciaRepository;

    private readonly ICarteiraService _carteiraService;
    
    private readonly IUsuarioRepository _repositoryUsuario;

    public TransferenciaService(ITransferenciaRepository transferenciaRepository, ICarteiraService carteiraService,IUsuarioRepository repositoryUsuario)
    {
        _transferenciaRepository = transferenciaRepository;
        _carteiraService = carteiraService;
        _repositoryUsuario = repositoryUsuario;
    }

    public async Task<Transferencia> CreateTransferencia(long idCredor, long idTomador, decimal valor)
    {
        var credor = await _repositoryUsuario.GetById(idCredor);
        
        if (credor == null)
        {
            throw new ArgumentException($"O credor {idCredor} não existe.");
        }

        var carteiraCredor = await _carteiraService.GetCarteiraByTitularId(credor.Id);
        
        if (carteiraCredor == null)
        {
            throw new ArgumentException($"O credor não possuí uma carteira.");
        }
        
        var tomador = await _repositoryUsuario.GetById(idTomador);
        
        if (tomador == null)
        {
            throw new ArgumentException($"O credor {idTomador} não existe.");
        }

        var carteiraTomador = await _carteiraService.GetCarteiraByTitularId(tomador.Id);
        
        if (carteiraTomador == null)
        {
            throw new ArgumentException($"O tomador não possuí uma carteira.");
        }
        
        if (credor.TipoUsuario == TiposUsuario.Lojista)
        {
            throw new InvalidOperationException("Lojistas não podem realizar transferências.");
        }
            
        if (idCredor == idTomador)
        {
            throw new ArgumentException("Não é possível transferir para si mesmo.");
        }
        
        if (valor <= 0)
        {
            throw new ArgumentException("O valor da transferência deve ser maior que zero.");
        }

        try
        {
            await _carteiraService.DebitSaldo(valor, idCredor);

            await _carteiraService.CreditSaldo(valor, idTomador);
        }
        catch (InvalidOperationException ex)
        {
            throw;
        }
        catch (ArgumentException ex)
        {
            throw;
        }
        
        Transferencia transferencia = new Transferencia(credor, tomador, valor);

        await _transferenciaRepository.AddAsync(transferencia);
        
        await _transferenciaRepository.Save();

        return transferencia;

    }
    
    public Task<Transferencia?> GetTransferenciaById(Guid idTransferencia)
    {
        throw new NotImplementedException();
    }
}