using domain.Entities;
using domain.Interfaces.Repositorios;
using domain.ViewModel;
using infra.Context;
using infra.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        public readonly Contexto _context;

        public ConsultaRepositorio(Contexto context)
        {
            _context = context;
        }

        public void Create(Consulta entity)
        {
            _context.Set<Consulta>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Consulta entity)
        {
            _context.Set<Consulta>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Consulta entity)
        {
            _context.Set<Consulta>().Remove(entity);
            _context.SaveChanges();
        }

        public Consulta? GetById(int id)
        {
            return _context.Set<Consulta>().Find(id);
        }

        public IList<ConsultaReturnViewModel> Get()
        {
            return (from i in _context.Consultas
                    join agendamento in _context.AgendamentoDoacoes on i.AgendamentoId equals agendamento.Id
                    join doadores in _context.Doadores on agendamento.DoadorId equals doadores.Id
                    select new ConsultaReturnViewModel
                    {
                        Id = i.Id,
                        DoadorName = doadores.Name,
                        DataAgendamento = agendamento.DataAgendamento,
                        DataConsulta = i.DataConsulta,
                        Status = i.Status,
                        Observacoes = i.Observacoes,
                        Local = agendamento.Local,
                        DuracaoMinutos = i.DuracaoMinutos,
                        TipoConsulta = i.TipoConsulta,
                        DataCriacao = i.DataCriacao
                    }).ToList();
        }

        public IList<ConsultaReturnViewModel> GetConsultaByDoadorId(long doadorId)
        {
            return (from i in _context.Consultas
                    join agendamento in _context.AgendamentoDoacoes on i.AgendamentoId equals agendamento.Id
                    join doadores in _context.Doadores on agendamento.DoadorId equals doadores.Id
                    where doadores.Id == doadorId
                    select new ConsultaReturnViewModel
                    {
                        Id = i.Id,
                        DoadorName = doadores.Name,
                        DataAgendamento = agendamento.DataAgendamento,
                        DataConsulta = i.DataConsulta,
                        Status = i.Status,
                        Observacoes = i.Observacoes,
                        Local = agendamento.Local,
                        DuracaoMinutos = i.DuracaoMinutos,
                        TipoConsulta = i.TipoConsulta,
                        DataCriacao = i.DataCriacao
                    }).ToList();
        }


        public IList<Consulta> getConsultaByDate(DateTime dataConsulta)
        {
            var intervaloDeConsulta = dataConsulta.AddMinutes(-15);
            return (from i in _context.Consultas
                    where i.DataConsulta > intervaloDeConsulta && i.DataConsulta < dataConsulta
                    select i).ToList();
        }

        public AgendamentoDoacoes? GetAgendamento(long agendamentoId)
        {
            return (from i in _context.AgendamentoDoacoes
                    where i.Id == agendamentoId
                    select i).FirstOrDefault();
        }
    }
}
