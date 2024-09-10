﻿using domain.Entities;
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
    public class DoadoresServices : IDoadoresService
    {
        private readonly IDoadoresRepositorio _doadoresRepositorio;

        public DoadoresServices(IDoadoresRepositorio doadoresRepositorio)
        {
            _doadoresRepositorio = doadoresRepositorio;
        }

        public IList<Doadores> Get()
        {
            return _doadoresRepositorio.Get();
        }

        public void Create(DoadoresViewModel doadorViewModel)
        {
            var idade = (DateTime.Now.Year - doadorViewModel.DataNasc.Year);
            if (idade < 18 || idade > 69) throw new Exception("Doador não pode ser menor que 18 anos ou maior que 69.");

            var doador_db = new Doadores
            {
                Name = doadorViewModel.Name,
                Role = "doador",
                Email = doadorViewModel.Email,
                Password = doadorViewModel.Password,
                TipoSanguineo = doadorViewModel.TipoSanguineo,
                DataNasc = doadorViewModel.DataNasc,
                Peso = doadorViewModel.Peso,
            };

            _doadoresRepositorio.Create(doador_db);
        }

        public void Update(long id, DoadoresViewModel doadorViewModel)
        {
            var doadoresById = _doadoresRepositorio.GetById(id);
            if (doadoresById == null) throw new Exception("Doador não encontrado.");

            doadoresById.Peso = doadorViewModel.Peso;

            _doadoresRepositorio.Update(doadoresById);
        }

        public void Delete(long id)
        {
            var doadores = _doadoresRepositorio.GetById(id);
            if (doadores == null) throw new Exception("Doador não encontrado.");

            _doadoresRepositorio.Delete(doadores);
        }
    }
}