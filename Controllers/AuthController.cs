using Microsoft.AspNetCore.Mvc;
using NotificacaoColetaApi.Services.Interfaces;

namespace NotificacaoColetaApi.Controllers
{
    [Route("api/Authorization")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetToken()
        {
            var token = _authService.GenerateJWTToken();

            return Ok(token);
        }
    }
}