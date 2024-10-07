using domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infra.Context;
using domain.Entities;

namespace infra.Repositorios
{
    public class DoadoresRepositorio : IDoadoresRepositorio
    {
        public readonly Contexto _context;

        public DoadoresRepositorio(Contexto context)
        {
            _context = context;
        }

        public void Create(Doadores entity)
        {
            _context.Set<Doadores>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Doadores entity)
        {
            _context.Set<Doadores>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Doadores entity)
        {
            _context.Set<Doadores>().Remove(entity);
            _context.SaveChanges();
        }

        public Doadores? GetById(long id)
        {
            return _context.Set<Doadores>().Find(id);
        }

        public IList<Doadores> Get()
        {
            return _context.Set<Doadores>().ToList();
        }

        public IList<Doadores> ObterDoadoresPorTipoSanguineo(string tipoSanguineo)
        {
            return (from i in _context.Doadores
                    where i.TipoSanguineo == tipoSanguineo
                    select i).ToList();
        }
    }
}
