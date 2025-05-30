namespace PicPay.Entidades;

public class Usuario
{
    public long Id { get; private set; }
    public string Nome { get; set; }
    
    public string Cpf { get; private set; }
    
    public string Email { get; set; }
    
    public string Senha { get; set; }
    
    private TiposUsuario TipoUsuario { get; set; }

    public Usuario()
    {
        
    }

    public Usuario(string nome, string cpf, string email, string senha, TiposUsuario tipoUsuario)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Senha = senha;
        TipoUsuario = tipoUsuario;
    }
}