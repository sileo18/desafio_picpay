using System.ComponentModel.DataAnnotations;

namespace PicPay.DTO_s;

public record CreateTransferenciaRequestDto
{
    [Required] 
    public long IdCredor { get; init; }

    [Required]
    public long IdTomador { get; init; }

    [Required]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")] 
    public decimal Valor { get; init; }
}