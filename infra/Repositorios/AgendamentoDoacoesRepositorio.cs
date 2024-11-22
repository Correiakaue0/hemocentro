using domain.Entities;
using domain.Interfaces.Repositorios;
using domain.ViewModel;
using infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repositorios
{
    public class AgendamentoDoacoesRepositorio : IAgendamentoDoacoesRepositorio
    {
        public readonly Contexto _context;

        public AgendamentoDoacoesRepositorio(Contexto context)
        {
            _context = context;
        }

        public void Create(AgendamentoDoacoes entity)
        {
            _context.Set<AgendamentoDoacoes>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(AgendamentoDoacoes entity)
        {
            _context.Set<AgendamentoDoacoes>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(AgendamentoDoacoes entity)
        {
            _context.Set<AgendamentoDoacoes>().Remove(entity);
            _context.SaveChanges();
        }

        public AgendamentoDoacoes? GetById(long id)
        {
            return _context.Set<AgendamentoDoacoes>().Find(id);
        }

        public IList<AgendamentoDoacoesReturnViewModel> Get()
        {
            return (from i in _context.AgendamentoDoacoes
                    join doadores in _context.Doadores
                on i.DoadorId equals doadores.Id
                    select new AgendamentoDoacoesReturnViewModel
                    {
                        Id = i.Id,
                        Codigo = i.Codigo,
                        DataAgendamento = i.DataAgendamento,
                        Local = i.Local,
                        DoadorNome = doadores.Name
                    }).ToList();
        }

        public IList<AgendamentoDoacoesReturnViewModel> GetAgendamentoByDoadorId(long doadorId)
        {
            return (from i in _context.AgendamentoDoacoes
                    join doadores in _context.Doadores on i.DoadorId equals doadores.Id
                    where doadores.Id == doadorId
                    select new AgendamentoDoacoesReturnViewModel
                    {
                        Id = i.Id,
                        Codigo = i.Codigo,
                        DataAgendamento = i.DataAgendamento,
                        Local = i.Local,
                        DoadorNome = doadores.Name
                    }).ToList();
        }

        public IList<AgendamentoDoacoes> getAgendamentoByDate(DateTime dataAgendamento)
        {
            var intervaloDeConsulta = dataAgendamento.AddMinutes(-15);
            return (from i in _context.AgendamentoDoacoes
                    where i.DataAgendamento > intervaloDeConsulta && i.DataAgendamento < dataAgendamento
                    select i).ToList();
        }

        public Doadores? GetDoador(long doadorId)
        {
            return (from i in _context.Doadores
                    where i.Id == doadorId
                    select i).FirstOrDefault();
        }
    }
}
