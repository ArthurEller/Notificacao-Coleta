using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificacaoColetaApi.Services.Interfaces;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _coletaService;
        private readonly ILogger<ColetaController> _logger;

        public ColetaController(IColetaService coletaService, ILogger<ColetaController> logger)
        {
            _coletaService = coletaService;
            _logger = logger;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AtualizarColeta(int id, [FromBody] ColetaViewModel coletaViewModel)
        {
            if (id != coletaViewModel.ColetaId)
            {
                return BadRequest("O ID da coleta não corresponde ao ID da URL.");
            }

            try
            {
                var coletaAtualizada = await _coletaService.AtualizarColetaAsync(coletaViewModel);
                if (coletaAtualizada == null)
                {
                    return NotFound();
                }

                return Ok(coletaAtualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar coleta: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
            }
        }

        [HttpPost("criar")]
        [Authorize]
        public async Task<IActionResult> CriarColeta([FromBody] ColetaViewModel coletaViewModel)
        {
            try
            {
                var coleta = await _coletaService.CriarColetaAsync(coletaViewModel);

                return Ok(coleta);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar coleta: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
            }
        }
    }
}