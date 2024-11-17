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
    public class ConsultaServices : IConsultaService
    {
        private readonly IConsultaRepositorio _consultaRepositorio;

        public ConsultaServices(IConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }

        public IList<ConsultaReturnViewModel> Get()
        {
            return _consultaRepositorio.Get();
        }

        public void Agendar(ConsultaViewModel consultaViewModel)
        {

            var doador = _consultaRepositorio.GetAgendamento(consultaViewModel.AgendamentoId);
            if (doador == null) throw new Exception("Agendamento não encotrado.");

            var consulta_db = new Consulta
            {
                AgendamentoId = consultaViewModel.AgendamentoId,
                DataConsulta = consultaViewModel.DataConsulta,
                Status = consultaViewModel.Status,
                Observacoes = consultaViewModel.Observacoes,
                DuracaoMinutos = consultaViewModel.DuracaoMinutos,
                TipoConsulta = consultaViewModel.TipoConsulta,
                DataCriacao = DateTime.Now,
            };

            _consultaRepositorio.Create(consulta_db);
        }

        public void AtualizarConsulta(int id, AtualizarConsultaViewModel consultaViewModel)
        {
            var consultaById = _consultaRepositorio.GetById(id);
            if (consultaById == null) throw new Exception("Consulta não encontrado.");

            _consultaRepositorio.Update(consultaById);
        }

        public void CancelarConsulta(int id)
        {
            var doadores = _consultaRepositorio.GetById(id);
            if (doadores == null) throw new Exception("Consulta não encontrado.");

            _consultaRepositorio.Delete(doadores);
        }
    }
}