using System.Text.Json.Serialization;

namespace domain.Entities
{
    public class AgendamentoDoacoes
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Local { get; set; }
        public long DoadorId { get; set; }

        [JsonIgnore]
        public Doadores Doador { get; set; }
    }
}