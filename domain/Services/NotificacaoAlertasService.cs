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
                Credentials = new NetworkCredential("seu-email@provedor.com", "sua-senha"),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("seu-email@provedor.com"),
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = true,
            };
            mail.To.Add(paraEmail);

            smtp.Send(mail);
        }

        public void EnviarSMS(int numero, string mensagem)
        {
            const string accountSid = "SEU_ACCOUNT_SID";
            const string authToken = "SEU_AUTH_TOKEN";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: mensagem,
                from: new PhoneNumber("SeuNumeroTwilio"),
                to: new PhoneNumber(numero.ToString())
            );
        }

        public void EnviarWhatsApp(int numero, string mensagem)
        {
            const string accountSid = "SEU_ACCOUNT_SID";
            const string authToken = "SEU_AUTH_TOKEN";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: mensagem,
                from: new PhoneNumber("whatsapp:+SeuNumeroTwilio"),
                to: new PhoneNumber("whatsapp:" + numero)
            );
        }
    }
}
