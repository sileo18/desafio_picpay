using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PicPay.Entidades;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private set; }
    public string Nome { get; set; }
    
    public string CpfCnpj { get; private set; }
    
    public string Email { get; set; }
    
    public string Senha { get; set; }
    
    public Carteira Carteira { get; set; }
    
    private TiposUsuario TipoUsuario { get; set; }

    public Usuario()
    {
        
    }

    public Usuario(string nome, string cpfCnpj, string email, string senha, TiposUsuario tipoUsuario)
    {
        Nome = nome;
        CpfCnpj = cpfCnpj;
        Email = email;
        Senha = senha;
        TipoUsuario = tipoUsuario;
    }
}