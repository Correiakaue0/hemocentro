using System.Text.Json.Serialization;

namespace domain.Entities
{
    public class Consulta
    {
        // Identificador único da consulta
        public int Id { get; set; }

        // Cliente ou paciente relacionado à consulta
        //public string DoadorId { get; set; }
        public long AgendamentoId { get; set; }

        // Data e hora do agendamento da consulta
        //public DateTime DataAgendamento { get; set; }

        // Data e hora de realização da consulta
        public DateTime? DataConsulta { get; set; }

        // Status da consulta (e.g., Agendado, Concluído, Cancelado)
        public string Status { get; set; }

        // Observações gerais sobre a consulta
        public string Observacoes { get; set; }

        // Local ou sala onde a consulta será realizada
        //public string Local { get; set; }

        // Duração prevista da consulta em minutos
        public int DuracaoMinutos { get; set; }

        // Tipo de consulta (e.g., presencial, online)
        public string TipoConsulta { get; set; }

        // Data de criação do registro de consulta
        public DateTime DataCriacao { get; set; }

        [JsonIgnore]
        public AgendamentoDoacoes Agendamento { get; set; }
    }
}