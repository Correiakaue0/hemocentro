using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.ViewModel
{
    public class DoadoresReturnViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TipoSanguineo { get; set; }
        public int Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public string Peso { get; set; }
        public bool IsAdmin { get; set; }

        public DoadoresReturnViewModel(string name, string email, string tipoSanguineo, int telefone, DateTime dataNasc, string peso, bool isAdmin = false)
        {
            Name = name;
            Email = email;
            TipoSanguineo = tipoSanguineo;
            Telefone = telefone;
            DataNasc = dataNasc;
            Peso = peso;
            IsAdmin = isAdmin;
        }
    }
}
