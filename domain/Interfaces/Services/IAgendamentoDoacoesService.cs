using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Services
{
    public interface IAgendamentoDoacoesService
    {
        void Agendar(AgendamentoDoacoesViewModel AgendamentoDoacoesViewModel);
        void AtualizarAgendamento(long id, AtualizarAgendamentoDoacoesViewModel agendamentoDoacoesViewModel);
        void CancelarAgendamento(long id);
        IList<AgendamentoDoacoesReturnViewModel> Get();
        IList<AgendamentoDoacoesReturnViewModel> GetAgendamentoByDoadorId(long doadorId);
    }
}
