using domain.Entities;
using domain.Interfaces.Services;
using domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hemocentro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class EstoqueSangueController : ControllerBase
    {
        private readonly IEstoqueSangueService _estoquesangueService;

        public EstoqueSangueController(IEstoqueSangueService estoquesangueService)
        {
            _estoquesangueService = estoquesangueService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var estoquesangue = _estoquesangueService.Get();
                return Ok(estoquesangue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] EstoqueSangueViewModel estoquesangue)
        {
            try
            {
                _estoquesangueService.Create(estoquesangue);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] EstoqueSangueViewModel estoquesangue)
        {
            try
            {
                _estoquesangueService.Update(id, estoquesangue);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _estoquesangueService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
