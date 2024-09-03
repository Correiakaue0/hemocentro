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
    public class EstoqueSangueServices : IEstoqueSangueService
    {
        private readonly IEstoqueSangueRepositorio _estoquesangueRepositorio;
        private readonly IDoadoresRepositorio _doadoresRepositorio;

        public EstoqueSangueServices(IEstoqueSangueRepositorio estoquesangueRepositorio, IDoadoresRepositorio doadoresRepositorio)
        {
            _estoquesangueRepositorio = estoquesangueRepositorio;
            _doadoresRepositorio = doadoresRepositorio;
        }

        public IList<EstoqueSangue> Get()
        {
            return _estoquesangueRepositorio.Get();
        }

        public void Create(EstoqueSangueViewModel estoquesangue)
        {
            var doador = _doadoresRepositorio.GetById(estoquesangue.DoadorId);
            if (doador == null) throw new Exception("Doador não encontrado.");

            var estoquesangue_db = new EstoqueSangue
            {
                CodigoIdentificacao = estoquesangue.CodigoIdentificacao,
                TipoSanguineo = estoquesangue.TipoSanguineo,
                DataDaColeta = estoquesangue.DataDaColeta,
                Volume = estoquesangue.Volume,
                DoadorId = estoquesangue.DoadorId,
            };

            _estoquesangueRepositorio.Create(estoquesangue_db);
        }

        public void Update(long id, EstoqueSangueViewModel estoquesangue)
        {
            var estoquesangueById = _estoquesangueRepositorio.GetById(id);
            if (estoquesangueById == null) throw new Exception("EstoqueSangue não encontrado.");

            _estoquesangueRepositorio.Update(estoquesangueById);
        }

        public void Delete(long id)
        {
            var estoquesangue = _estoquesangueRepositorio.GetById(id);
            if (estoquesangue == null) throw new Exception("EstoqueSangue não encontrado.");

            _estoquesangueRepositorio.Delete(estoquesangue);
        }
    }
}
