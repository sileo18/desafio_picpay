using Microsoft.AspNetCore.Mvc;
using PicPay.DTO_s;
using PicPay.Entidades;
using PicPay.Services;

namespace PicPay.Controller;

[Route("/api/transferencia")]
[ApiController]
public class TransferenciaController : ControllerBase
{
    private readonly ITransferenciaService _service;

    public TransferenciaController(ITransferenciaService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Transferencia>> CreateTransferencia([FromBody] CreateTransferenciaRequestDto request)
    {
        try
        {
            Transferencia transferencia = await _service.CreateTransferencia(
                request.IdCredor,
                request.IdTomador,
                request.Valor
            );

            return Ok(transferencia);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servido." });
        }
    }
}