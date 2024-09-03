using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class EstoqueSangue
    {
        public long Id { get; set; }
        public string CodigoIdentificacao { get; set; }
        public string TipoSanguineo { get; set; }
        public DateTime DataDaColeta { get; set; }
        public decimal Volume { get; set; }
        public long DoadorId { get; set; }

        [JsonIgnore]
        public Doadores Doador { get; set; }
    }
}
