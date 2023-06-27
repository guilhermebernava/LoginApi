using Infra.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infra.Utils
{
    public static class SendEmailUtils
    {
        public static void SendEmail(string email, string code, IConfiguration configuration)
        {
            try
            {

                Task.Run(() =>
                {
                    MailMessage newMail = new MailMessage();
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    newMail.From = new MailAddress("guilhermebernava00@gmail.com", "SEC - API");
                    newMail.To.Add(email);
                    newMail.Subject = "Two Factor Login Acess";
                    newMail.IsBodyHtml = true; newMail.Body = $"<h1>Acess this link to login in your account <a href=\"{code}\">{code}</a></h1>";

                    client.EnableSsl = true;
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("guilhermebernava00@gmail.com", configuration["EmailPassword"]);
                    client.Send(newMail);
                });

            }
            catch (Exception ex)
            {
                throw new UtilsException(ex.ToString());
            }
        }
    }
}
