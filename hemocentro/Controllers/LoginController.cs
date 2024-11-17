using Domain.Interfaces.Services;
using Domain.ViewModels.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var token =_loginService.Login(loginViewModel);
                return Ok(new
                {
                    UserId = token.Item1,
                    Token = token.Item2,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
