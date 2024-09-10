using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ViewModel;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(LoginViewModel loginViewModel)
        {
            var user = _userRepository.GetByEmail(loginViewModel.Email);
            if (user == null) throw new Exception("Email não existe.");

            if (!PasswordService.VerifyPassword(loginViewModel.Password, user.Password)) throw new Exception("Senha incorreta.");

            return TokenService.GerarToken(user);
        }
    }
}
