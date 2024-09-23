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
    public class EstoqueSangueRepositorio : IEstoqueSangueRepositorio
    {
        public readonly Contexto _context;

        public EstoqueSangueRepositorio(Contexto context)
        {
            _context = context;
        }

        public void Create(EstoqueSangue entity)
        {
            _context.Set<EstoqueSangue>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(EstoqueSangue entity)
        {
            _context.Set<EstoqueSangue>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(EstoqueSangue entity)
        {
            _context.Set<EstoqueSangue>().Remove(entity);
            _context.SaveChanges();
        }

        public EstoqueSangue? GetById(long id)
        {
            return _context.Set<EstoqueSangue>().Find(id);
        }

        public IList<EstoqueSangue> Get()
        {
            return _context.Set<EstoqueSangue>().ToList();
        }

        public IList<EstoqueSangue> ConsultaNecessidades(string tipoSanguineo)
        {
            return (from i in _context.EstoqueSangue
                    where i.TipoSanguineo == tipoSanguineo
                    select i).ToList();
        }
    }
}
