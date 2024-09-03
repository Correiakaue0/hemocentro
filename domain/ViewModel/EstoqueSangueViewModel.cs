using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.ViewModel
{
    public class EstoqueSangueViewModel
    {
        public string CodigoIdentificacao { get; set; }
        public string TipoSanguineo { get; set; }
        public DateTime DataDaColeta { get; set; }
        public decimal Volume { get; set; }
        public long DoadorId { get; set; }
    }
}
