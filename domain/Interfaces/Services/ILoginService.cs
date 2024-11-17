using Domain.ViewModels.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface ILoginService
    {
        (long, string) Login(LoginViewModel loginViewModel);
    }
}
