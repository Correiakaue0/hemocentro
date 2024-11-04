using domain.Interfaces.Repositorios;
using domain.Interfaces.Services;
using System.Net.Mail;
using System.Net;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace domain.Services
{
    public class NotificacaoAlertasService : INotificacaoAlertasService
    {
        private readonly IDoadoresRepositorio _doadoresRepositorio;

        public NotificacaoAlertasService(IDoadoresRepositorio doadoresRepositorio)
        {
            _doadoresRepositorio = doadoresRepositorio;
        }

        public void EnviarNotificacoesAlertas(string tipoSanguineo)
        {
            var doadores = _doadoresRepositorio.ObterDoadoresPorTipoSanguineo(tipoSanguineo);

            if (doadores == null || !doadores.Any())
                throw new Exception("Nenhum doador encontrado com o tipo sanguíneo especificado.");
            

            foreach (var doador in doadores)
            {
                // Enviar E-mail
                EnviarEmail(doador.Email, "Necessidade de sangue", $"Precisamos de doações de sangue tipo {tipoSanguineo}.");

                // Enviar SMS
                EnviarSMS(doador.Telafone, $"Necessitamos de sangue tipo {tipoSanguineo}.");

                // Enviar WhatsApp
                EnviarWhatsApp(doador.Telafone, $"Por favor, considere doar sangue tipo {tipoSanguineo}.");
            }

        }

        public void EnviarEmail(string paraEmail, string assunto, string corpo)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("rafael@gmail.com", "h6yh6T5T54"),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("rafael@gmail.com"),
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = true,
            };
            mail.To.Add(paraEmail);

            smtp.Send(mail);
        }

        public void EnviarSMS(int numero, string mensagem)
        {
            const string accountSid = "HD66S56S5DH";
            const string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImthdWUiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MjgzNDM3MzAsImV4cCI6MTcyODM1MDkzMCwiaWF0IjoxNzI4MzQzNzMwfQ.hK0EYFnt835mgnFYPunflEzVqaMOLMR_OlMz-RVAw3Y";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: mensagem,
                from: new PhoneNumber("14998758463"),
                to: new PhoneNumber(numero.ToString())
            );
        }

        public void EnviarWhatsApp(int numero, string mensagem)
        {
            const string accountSid = "XASSZV34R4345";
            const string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImthdWUiLCJyb2xlIjoiZG9hZG9yIiwibmJmIjoxNzI4MzQzNTYwLCJleHAiOjE3MjgzNTA3NjAsImlhdCI6MTcyODM0MzU2MH0.WmwbpJryn47Frm5oP23914y1NoheqZOEHXi6WFJ_mL8";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: mensagem,
                from: new PhoneNumber("whatsapp:+5514998758463"),
                to: new PhoneNumber("whatsapp:" + numero)
            );
        }
    }
}
