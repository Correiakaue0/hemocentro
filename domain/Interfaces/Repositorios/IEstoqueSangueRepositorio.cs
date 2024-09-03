using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Repositorios
{
    public interface IEstoqueSangueRepositorio
    {
        void Create(EstoqueSangue entity);
        void Delete(EstoqueSangue entity);
        IList<EstoqueSangue> Get();
        EstoqueSangue? GetById(long id);
        void Update(EstoqueSangue entity);
    }
}
