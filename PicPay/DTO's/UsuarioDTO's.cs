namespace PicPay.DTO_s;

public record AddUsuarioDTO(string Nome, string CpfCnpj, string Email, string Senha);

public record ResponseUsuarioDto(string Nome, long Id);
