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
                    newMail.IsBodyHtml = true; newMail.Body = $"<h1>Here is your code!</h1>\n<h2>Use this code to login in your account</h2>\n<h3>{code}</h3>";

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
