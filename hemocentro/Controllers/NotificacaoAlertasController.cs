using domain.Interfaces.Services;
using domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hemocentro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "doador, admin")]
    public class NotificacaoAlertasController : ControllerBase
    {
        private readonly INotificacaoAlertasService _notificacaoAlertasService;

        public NotificacaoAlertasController(INotificacaoAlertasService notificacaoAlertasService)
        {
            _notificacaoAlertasService = notificacaoAlertasService;
        }

        [HttpPost("EnviarNotificacoesAlertas/{tipoSanguineo}")]
        [Authorize(Roles = "admin")]
        public IActionResult EnviarNotificacoesAlertas(string tipoSanguineo)
        {
            try
            {
                _notificacaoAlertasService.EnviarNotificacoesAlertas(tipoSanguineo);
                return Ok("Notificaçoes enviadas com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
