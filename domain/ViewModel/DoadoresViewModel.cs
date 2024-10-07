﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.ViewModel
{
    public class DoadoresViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Telafone { get; set; }
        public string TipoSanguineo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Peso { get; set; }
    }
}
