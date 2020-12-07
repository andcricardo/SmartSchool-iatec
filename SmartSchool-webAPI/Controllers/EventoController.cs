
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_webAPI.Data;
using SmartSchool_webAPI.Models;

namespace SmartSchool_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IRepository _repo;
        public EventoController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllEventoAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var possuiEvento = _repo.GetEventosAsyncByDataExclusivo(model.dataevento);

                if (possuiEvento.Result != null) return Ok("Evento Exclusivo para essa Data já Cadastrado!");

                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
            return BadRequest("Erro na Gravação dos dados!");
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId);

                if (evento == null) return NotFound("Evento não Encontrado!");

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
            return BadRequest("Erro na Atualização dos dados!");
        }

        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId);

                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Evento Excluído!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
            return BadRequest("Erro ao Excluir registro!");
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> GetEventoId(int eventoId)
        {
            try
            {
                var result = await _repo.GetEventoAsyncById(eventoId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
        }
    }
}