using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Fiap.Autenticacao.Email
{
    public static class Function1
    {
    [FunctionName("Email")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [Sql("SELECT * FROM [dbo].[Autores]",
            "FiapNoticias")] IEnumerable<Autor> result)
        {
            if(result != null && result.Any())
            {
                await SendMailSendGrid("", "", result.First().Email, result.First().Nome, "Registro com sucesso", "Obrigado por se registrar", "<div>Obrigado por se registrar</div>");
            }

            return new OkObjectResult(result);
        }

        public static async Task<string> SendMailSendGrid(string fromEmail, string fromName, string toEmail, string toName,
            string subject, string plainTextContent, string htmlContent)
        {
            string apiKey = "";

            // Criar um novo cliente SendGrid
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail, toName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Enviar o e-mail
            var response = await client.SendEmailAsync(msg);

            // Retornar o status do envio
            return response.StatusCode.ToString();
        }
    }

    
}
