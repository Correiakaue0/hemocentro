using Domain.ViewModels.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface ILoginService
    {
        string Login(LoginViewModel loginViewModel);
    }
}
