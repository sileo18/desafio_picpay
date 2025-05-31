using System.ComponentModel.DataAnnotations;

namespace PicPay.Entidades;

public class Transferencia
{
    [Key]
    public Guid IdTransferencia { get; private set; }
    
    public long CredorId { get; private set; }
    public Usuario Credor { get; private set; }
    
    public long TomadorId { get; private set; }
    public Usuario Tomador { get; private set; }
    
    public decimal Valor { get; private set; }

    public Transferencia()
    {
        
    }

    public Transferencia(Usuario credor, Usuario tomador, decimal valor)
    {
        IdTransferencia = Guid.NewGuid();
        CredorId = credor.Id;
        Credor = credor;
        TomadorId = tomador.Id;
        Tomador = tomador;
        Valor = valor;
    }
}