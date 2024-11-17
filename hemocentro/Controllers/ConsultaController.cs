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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        [Authorize()]
        public IActionResult Get()
        {
            try
            {
                var consulta = _consultaService.Get();
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Agendar([FromBody] ConsultaViewModel consultaViewModel)
        {
            try
            {
                _consultaService.Agendar(consultaViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarConsulta(int id, [FromBody] AtualizarConsultaViewModel consultaViewModel)
        {
            try
            {
                _consultaService.AtualizarConsulta(id, consultaViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult CancelarConsulta(int id)
        {
            try
            {
                _consultaService.CancelarConsulta(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
