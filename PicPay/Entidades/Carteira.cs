using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PicPay.Entidades;

public class Carteira
{
    [Key]
    public long TitularId { get; private set; }
    
    public decimal Saldo { get; set; }
    
    [JsonIgnore]
    public Usuario Titular { get; set; }

    public Carteira()
    {
        
    }

    public Carteira(Usuario titular)
    {
        if (titular == null)
            throw new ArgumentNullException(nameof(titular));

        TitularId = titular.Id; 
        Titular = titular;
        Saldo = 500.86m;
    }

    public void AdicionarSaldo(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
        }
    }

    public bool RetirarSaldo(decimal valor)
    {
        if (valor > 0 && Saldo >= valor)
        {
            Saldo -= valor;
            return true;
        }

        return false;
    }
}