using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Repositorios
{
    public interface IAgendamentoDoacoesRepositorio
    {
        void Create(AgendamentoDoacoes entity);
        void Delete(AgendamentoDoacoes entity);
        IList<AgendamentoDoacoesReturnViewModel> Get();
        IList<AgendamentoDoacoes> getAgendamentoByDate(DateTime dataAgendamento);
        AgendamentoDoacoes? GetById(long id);
        Doadores? GetDoador(long doadorId);
        void Update(AgendamentoDoacoes entity);
    }
}
