
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_webAPI.Data;
using SmartSchool_webAPI.Models;

namespace SmartSchool_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repo;
        public UsuarioController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllUsuariosAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
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
        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> Put(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);

                if (usuario == null) return NotFound("Usuário não Encontrado!");

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

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> Delete(int usuarioId)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);

                if (usuario == null) return NotFound();

                _repo.Delete(usuario);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
            return BadRequest("Erro ao Excluir registro!");
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuarioId(int usuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioAsyncById(usuarioId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
        }
        [HttpGet("ByUsuario/{nome}")]
        public async Task<IActionResult> GetUsuarioNome(string nome)
        {
            try
            {
                var result = await _repo.GetUsuariosAsyncByNome(nome);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }
        }
    }
}
