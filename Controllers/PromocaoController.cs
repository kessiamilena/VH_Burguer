using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VHBurguer.Applications.Services;
using VHBurguer.DTOs.PromocaoDto;
using VHBurguer.Exceptions;

namespace VHBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoService _service;

        public PromocaoController(PromocaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerPromocaoDto>> Listar()
        {
            List<LerPromocaoDto> promocoes = _service.Listar();
            return Ok(promocoes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerPromocaoDto> ObterPorId(int id)
        {
            try
            {
                LerPromocaoDto promocao = _service.ObterPorId(id);
                return Ok(promocao);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adicionar(CriarPromocaoDto promoDto)
        {
            try
            {
                _service.Adicionar(promoDto);
                return StatusCode(201);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Atualizar(int id, CriarPromocaoDto promoDto)
        {
            try
            {
                _service.Atualizar(id, promoDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
                //return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
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
