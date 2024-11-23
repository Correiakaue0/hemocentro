using domain.Interfaces.Services;
using domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hemocentro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RelatoriosController : ControllerBase
    {
        private readonly IAgendamentoDoacoesService _agendamentoDoacoesService;
        private readonly IEstoqueSangueService _estoquesangueService;
        private readonly IDoadoresService _doadoresService;
        private readonly IConsultaService _consultaService;

        public RelatoriosController(IAgendamentoDoacoesService agendamentoDoacoesService, IEstoqueSangueService estoquesangueService, IDoadoresService doadoresService, IConsultaService consultaService)
        {
            _agendamentoDoacoesService = agendamentoDoacoesService;
            _estoquesangueService = estoquesangueService;
            _doadoresService = doadoresService;
            _consultaService = consultaService;
        }

        [HttpGet("agendamentos")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAgendamentos()
        {
            try
            {
                return Ok(_agendamentoDoacoesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("estoque")]
        [Authorize(Roles = "admin")]
        public IActionResult GetEstoque()
        {
            try
            {
                return Ok(_estoquesangueService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("doadores")]
        [Authorize(Roles = "admin")]
        public IActionResult GetDoadores()
        {
            try
            {
                return Ok(_doadoresService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("consultas")]
        [Authorize(Roles = "admin")]
        public IActionResult GetConsultas()
        {
            try
            {
                return Ok(_consultaService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
