﻿using domain.Entities;
using domain.Interfaces.Services;
using domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace hemocentro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoadoresController : ControllerBase
    {
        private readonly IDoadoresService _doadoresService;

        public DoadoresController(IDoadoresService doadoresService)
        {
            _doadoresService = doadoresService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var doadores = _doadoresService.Get();
                return Ok(doadores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "doador, admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var doador = _doadoresService.GetById(id);
                return Ok(doador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DoadoresViewModel doadores)
        {
            try
            {
                _doadoresService.Create(doadores);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "doador, admin")]
        public IActionResult Update(long id, [FromBody] DoadoresViewModel doadores)
        {
            try
            {
                _doadoresService.Update(id, doadores);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "doador, admin")]
        public IActionResult Delete(long id)
        {
            try
            {
                _doadoresService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DoadorAdmin/{securityKey}")]
        public IActionResult CreateDoadorAdmin([FromBody] DoadoresViewModel doadores, string securityKey)
        {
            try
            {
                if (securityKey != "CadastroDeAdmin")
                    throw new Exception("Chave de segurança invalida!");

                _doadoresService.CreateDoadorAdmin(doadores);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
