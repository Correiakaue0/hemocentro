using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Services
{
    public interface IConsultaService
    {
        void Agendar(ConsultaViewModel ConsultaViewModel);
        void AtualizarConsulta(int id, AtualizarConsultaViewModel consultaViewModel);
        void CancelarConsulta(int id);
        IList<ConsultaReturnViewModel> Get();
    }
}
