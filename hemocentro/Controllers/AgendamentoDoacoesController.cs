using domain.Interfaces.Services;
using domain.Services;
using domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hemocentro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "doador, admin")]
    public class AgendamentoDoacoesController : ControllerBase
    {
        private readonly IAgendamentoDoacoesService _agendamentoDoacoesService;

        public AgendamentoDoacoesController(IAgendamentoDoacoesService agendamentoDoacoesService)
        {
            _agendamentoDoacoesService = agendamentoDoacoesService;
        }

        [HttpGet]
        [Authorize()]
        public IActionResult Get()
        {
            try
            {
                var agendamentoDoacoes = _agendamentoDoacoesService.Get();
                return Ok(agendamentoDoacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Agendar([FromBody] AgendamentoDoacoesViewModel agendamentoDoacoesViewModel)
        {
            try
            {
                _agendamentoDoacoesService.Agendar(agendamentoDoacoesViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarAgendamento(long id, [FromBody] AtualizarAgendamentoDoacoesViewModel agendamentoDoacoesViewModel)
        {
            try
            {
                _agendamentoDoacoesService.AtualizarAgendamento(id, agendamentoDoacoesViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult CancelarAgendamento(long id)
        {
            try
            {
                _agendamentoDoacoesService.CancelarAgendamento(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
