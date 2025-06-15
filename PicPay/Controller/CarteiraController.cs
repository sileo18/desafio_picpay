using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PicPay.DTO_s;
using PicPay.Entidades;
using PicPay.Mappers;
using PicPay.Services;

namespace PicPay.Controller;

[Route("/api/carteira")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CarteiraController : ControllerBase
{

    private readonly ICarteiraService _service;

    private readonly CarteiraMapper _mapper;

    public CarteiraController(ICarteiraService service, CarteiraMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("create/{titularId}")]
    public async Task<ActionResult<Carteira>> CreateCarteira(long titularId)
    {
        try
        {
            Carteira carteira = await _service.AddAsync(titularId);

            ResponseCarteiraDto response = _mapper.CarteiraToResponseDto(carteira);

            return CreatedAtRoute(nameof(GetCarteiraById), new {titularId = carteira.TitularId}, response);
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

    [HttpGet("/{titularId:long}",Name = nameof(GetCarteiraById))]
    public async Task<ActionResult<Carteira?>> GetCarteiraById(long titularId)
    {
        try
        {
            var carteira = await _service.GetCarteiraByTitularId(titularId);

            if (carteira == null)
            {
                return NotFound(new { message = $"Carteira com id {titularId} não enontrada." });
            }

            return Ok(carteira);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servidor." });
        }
    }
    
}