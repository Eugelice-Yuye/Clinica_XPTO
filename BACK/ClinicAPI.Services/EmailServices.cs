using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Interfaces.Services;

namespace ClinicAPI.Services
{
    public class EmailServices : IEmailServices
    {
        public void Enviar(string para, string assunto, string corpo)
        {
            var remetente = "clinicaxpto2025@gmail.com";
            var senha = "icwi pbsd yqnf oqyx";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(remetente, senha),
                EnableSsl = true,
            };

            var mensagem = new MailMessage(remetente, para, assunto, corpo);
            smtpClient.Send(mensagem);
        }
    }
}
