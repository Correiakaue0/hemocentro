using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Doadores : User
    {
        public string TipoSanguineo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Peso { get; set; }

        [JsonIgnore]
        public ICollection<EstoqueSangue> EstoquesSangue { get; set; }
    }
}
