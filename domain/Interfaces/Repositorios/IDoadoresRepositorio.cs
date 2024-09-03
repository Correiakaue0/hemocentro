using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Repositorios
{
    public interface IDoadoresRepositorio
    {
        void Create(Doadores entity);
        void Delete(Doadores entity);
        IList<Doadores> Get();
        Doadores? GetById(long id);
        void Update(Doadores entity);
    }
}
