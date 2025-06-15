using Microsoft.AspNetCore.Http.HttpResults;
using PicPay.Entidades;
using PicPay.Infra;
using PicPay.Repositories;

namespace PicPay.Services;

public class CarteiraService : ICarteiraService
{

    private readonly ICarteiraRepository _repositoryCarteira;

    private readonly IUsuarioRepository _repositoryUsuario;

    public CarteiraService(ICarteiraRepository repositoryCarteira, IUsuarioRepository repositoryUsuario)
    {
        _repositoryCarteira = repositoryCarteira;
        _repositoryUsuario = repositoryUsuario;
    }

    public async Task<Carteira> AddAsync(long titularId)
    {
       var usuario = await _repositoryUsuario.GetById(titularId);

       if (usuario == null)
       {
           throw new ArgumentException($"Usuario com id {titularId} não existe");
       }
       
       var carteiraExistente = await _repositoryCarteira.GetByTitularIdAsync(titularId);
       
       if (carteiraExistente != null)
       {
           throw new InvalidOperationException($"Usuário com id {titularId} já possui uma carteira.");
       }

       Carteira carteira = new Carteira(usuario);

       var response = await _repositoryCarteira.AddAsync(carteira);

       return response;
    }

    public async Task<Carteira?> GetCarteiraByTitularId(long titularId)
    {
        return await _repositoryCarteira.GetById(titularId);
    }

    public async Task<Carteira> CreditSaldo(decimal valor, long titularId)
    {
            var carteira = await _repositoryCarteira.GetByTitularIdAsync(titularId);

            if (carteira == null)
            {
                throw new ArgumentException($"Carteira com id {titularId} não existe");
            }

            if (valor <= 0)
            {
                throw new ArgumentException("O valor deve ser maior que zero.");
            }
        
            carteira.AdicionarSaldo(valor);
        
            //await _repositoryCarteira.Save();
        
            return carteira;
    }

    public async Task<bool> DebitSaldo(decimal valor, long titularId)
    {
        var carteira = await _repositoryCarteira.GetByTitularIdAsync(titularId);

        if (carteira == null)
        {
            throw new ArgumentException($"Carteira com id {titularId} não existe");
        }
        
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do débito deve ser maior que zero.");
        }
        
        bool debitoRealizado = carteira.RetirarSaldo(valor);

        if (!debitoRealizado)
        {
            throw new InvalidOperationException("Saldo insuficiente para realizar o débito.");
        }
         
        //await _repositoryCarteira.Save();

        return debitoRealizado;
    }
}