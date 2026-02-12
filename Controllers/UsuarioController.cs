using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VHBurguer.Applications.Services;
using VHBurguer.DTOs;
using VHBurguer.Exceptions;


namespace VHBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        // GET -> lista informações
        [HttpGet] 
        public ActionResult<List<LerUsuarioDto>> Listar()
        {
            List<LerUsuarioDto> usuarios = _service.Listar();

            // retorna a lista de usuários, a partir da DTO de Services
            return Ok(usuarios); // OK - 200 - DEU CERTO
        }

        [HttpGet("{id}")]
        public ActionResult<LerUsuarioDto> ObterPorId(int id)
        {
            LerUsuarioDto usuario = _service.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound(); // NÃO ENCONTRADO - StatusCode 404
            }

            return Ok(usuario);
        }

        [HttpGet("email/{email}")] 
        public ActionResult<LerUsuarioDto> ObterPorEmail(string email)
        {
            LerUsuarioDto usuario = _service.ObterPorEmail(email);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST - Envia dados 
        [HttpPost] 
        public ActionResult<LerUsuarioDto> Adicionar(CriarUsuarioDto usuarioDto)
        {
            try
            {
                LerUsuarioDto usuarioCriado = _service.Adicionar(usuarioDto);

                return StatusCode(201, usuarioCriado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Realiza alterações de todos os dados
        [HttpPut("{id}")]
        public ActionResult<LerUsuarioDto> Atualizar(int id, CriarUsuarioDto usuarioDto)
        {
            try
            {
                LerUsuarioDto usuarioAtualizado = _service.Atualizar(id, usuarioDto);

                return StatusCode(200, usuarioAtualizado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Remove os dados
        // no nosso banco o delete vai inativar o usuário
        // por conta da trigger (processo chamado de soft delete)
        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
