using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Repositorios
{
    public interface IConsultaRepositorio
    {
        void Create(Consulta entity);
        void Delete(Consulta entity);
        IList<ConsultaReturnViewModel> Get();
        IList<Consulta> getConsultaByDate(DateTime dataConsulta);
        Consulta? GetById(int id);
        void Update(Consulta entity);
        AgendamentoDoacoes? GetAgendamento(long agendamentoId);
        IList<ConsultaReturnViewModel> GetConsultaByDoadorId(long doadorId);
    }
}
