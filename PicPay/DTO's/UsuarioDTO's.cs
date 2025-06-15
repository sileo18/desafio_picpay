using PicPay.Entidades;

namespace PicPay.DTO_s;

public record AddUsuarioDTO(string Nome, string CpfCnpj, string Email, string Senha, TiposUsuario TiposUsuario);

public record ResponseUsuarioDto(string Nome, long Id);
