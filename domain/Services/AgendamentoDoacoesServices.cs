using domain.Entities;
using domain.Interfaces.Repositorios;
using domain.Interfaces.Services;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Services
{
    public class AgendamentoDoacoesServices : IAgendamentoDoacoesService
    {
        private readonly IAgendamentoDoacoesRepositorio _agendamentoDoacoesRepositorio;

        public AgendamentoDoacoesServices(IAgendamentoDoacoesRepositorio agendamentoDoacoesRepositorio)
        {
            _agendamentoDoacoesRepositorio = agendamentoDoacoesRepositorio;
        }

        public IList<AgendamentoDoacoesReturnViewModel> Get()
        {
            return _agendamentoDoacoesRepositorio.Get();
        }

        public void Agendar(AgendamentoDoacoesViewModel agendamentoDoacoesViewModel)
        {
            var getAgendamentoByDate = _agendamentoDoacoesRepositorio.getAgendamentoByDate(agendamentoDoacoesViewModel.DataAgendamento);
            if (getAgendamentoByDate.Count > 0) throw new Exception("horario indisponivel.");

            var doador = _agendamentoDoacoesRepositorio.GetDoador(agendamentoDoacoesViewModel.DoadorId);
            if (doador == null) throw new Exception("Doador não encotrado.");

            var agendamentoDoacoes_db = new AgendamentoDoacoes
            {
                Codigo = agendamentoDoacoesViewModel.Codigo,
                DataAgendamento = agendamentoDoacoesViewModel.DataAgendamento,
                Local = agendamentoDoacoesViewModel.Local,
                DoadorId = agendamentoDoacoesViewModel.DoadorId,
            };

            _agendamentoDoacoesRepositorio.Create(agendamentoDoacoes_db);
        }

        public void AtualizarAgendamento(long id, AtualizarAgendamentoDoacoesViewModel agendamentoDoacoesViewModel)
        {
            var agendamentoDoacoesById = _agendamentoDoacoesRepositorio.GetById(id);
            if (agendamentoDoacoesById == null) throw new Exception("Agendamento não encontrado.");

            var getAgendamentoByDate = _agendamentoDoacoesRepositorio.getAgendamentoByDate(agendamentoDoacoesViewModel.DataAgendamento);
            if (getAgendamentoByDate.Count > 0) throw new Exception("horario indisponivel.");

            agendamentoDoacoesById.DataAgendamento = agendamentoDoacoesViewModel.DataAgendamento;
            agendamentoDoacoesById.Local = agendamentoDoacoesViewModel.Local;

            _agendamentoDoacoesRepositorio.Update(agendamentoDoacoesById);
        }

        public void CancelarAgendamento(long id)
        {
            var doadores = _agendamentoDoacoesRepositorio.GetById(id);
            if (doadores == null) throw new Exception("Agendamento não encontrado.");

            _agendamentoDoacoesRepositorio.Delete(doadores);
        }
    }
}