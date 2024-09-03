using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Services
{
    public interface IDoadoresService
    {
        void Create(DoadoresViewModel doador);
        void Delete(long id);
        IList<Doadores> Get();
        void Update(long id, DoadoresViewModel doadores);
    }
}
