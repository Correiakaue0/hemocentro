using domain.Entities;
using domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces.Services
{
    public interface IEstoqueSangueService
    {
        string ConsultaNecessidades(string tipoSanguineo);
        void Create(EstoqueSangueViewModel doador);
        void Delete(long id);
        IList<EstoqueSangue> Get();
        List<string> GetTipoSanguineos();
        void Update(long id, EstoqueSangueViewModel estoquesangue);
    }
}
