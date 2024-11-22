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
        void CreateDoadorAdmin(DoadoresViewModel doadorViewModel);
        void Delete(long id);
        IList<Doadores> Get();
        DoadoresReturnViewModel GetById(int id);
        void Update(long id, DoadoresViewModel doadores);
    }
}
