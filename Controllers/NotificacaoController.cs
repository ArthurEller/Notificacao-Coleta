using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificacaoColetaApi.Services.Interfaces;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly ILogger<NotificacaoController> _logger;
        private readonly INotificacaoService _notificacaoService;

        public NotificacaoController(INotificacaoService notificacaoService, ILogger<NotificacaoController> logger)
        {
            _notificacaoService = notificacaoService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("criar")]
        public async Task<IActionResult> CriarNotificacao([FromBody] NotificacaoViewModel notificacaoViewModel)
        {
            try
            {
                var notificacao = await _notificacaoService.CriarNotificacaoAsync(notificacaoViewModel);

                return Ok(notificacao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar notificação: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
            }
        }

        [HttpGet("healthcheck")]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                var healthCheck = await _notificacaoService.HealthCheck();

                return Ok(healthCheck);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao realizar healthcheck: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
            }
        }
    }
}