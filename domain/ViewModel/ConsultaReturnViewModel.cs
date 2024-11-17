using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.ViewModel
{
    public class ConsultaReturnViewModel
    {
        public int Id { get; set; }
        public string DoadorName { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public string Local { get; set; }
        public int DuracaoMinutos { get; set; }
        public string TipoConsulta { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
