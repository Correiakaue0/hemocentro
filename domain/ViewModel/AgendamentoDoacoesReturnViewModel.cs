using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.ViewModel
{
    public class AgendamentoDoacoesReturnViewModel
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Local { get; set; }
        public string DoadorNome { get; set; }
    }
}
