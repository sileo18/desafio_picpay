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

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ResponseUsuarioDto>> CreateUsuario(AddUsuarioDTO request)
    {
        try
        {
            Usuario usuario = await _usuarioService.CreateUsuario(request);

            UsuarioMapper mapper = new UsuarioMapper();

            ResponseUsuarioDto response = mapper.UsuarioToReponseUsuarioDto(usuario);

            return Created("", response);

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
    
}