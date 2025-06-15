using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PicPay.DTO_s;
using PicPay.Entidades;
using PicPay.Mappers;
using PicPay.Services;

namespace PicPay.Controller;

[Route("/api/user")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class UsuarioController : ControllerBase
{

    private readonly IUsuarioService _usuarioService;

    private UsuarioMapper _mapper;

    public UsuarioController(IUsuarioService usuarioService, UsuarioMapper mapper)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ResponseUsuarioDto>> CreateUsuario(AddUsuarioDTO request)
    {
        try
        {
            Usuario usuario = await _usuarioService.CreateUsuario(request);

            ResponseUsuarioDto response = _mapper.UsuarioToReponseUsuarioDto(usuario);

            return CreatedAtRoute(nameof(GetUsuarioById), new {usuarioId = response.Id}, response);

        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }

        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servido." });
        }
    }

    [HttpGet("{usuarioId:long}", Name = nameof(GetUsuarioById))]
    public async Task<ActionResult<ResponseUsuarioDto?>> GetUsuarioById(long usuarioId)
    {
        try
        {
            var usuario = await _usuarioService.GetUsuarioById(usuarioId);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            ResponseUsuarioDto response = _mapper.UsuarioToReponseUsuarioDto(usuario);

            return Ok(response);
        }

        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servido." });
        }
        
        
    }
    
}