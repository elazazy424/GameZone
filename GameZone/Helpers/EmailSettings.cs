using System.Net.Mail;
using System.Net;
using Game.DAL.Entity;

namespace GameZone.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ashlynn.mraz@ethereal.email", "TN1prrZf5mkePKeSc2");
            client.Send("elazazy11@yahoo.com", email.To, email.Title, email.Body);
        }
    }
}
