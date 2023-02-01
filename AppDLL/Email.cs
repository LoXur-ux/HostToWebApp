using System.Net.Mail;
using System.Net;

namespace HostApp.Requests;
public class Email
{
    public static void SendCode(string email)
    {
        try
        {
            MailAddress from = new MailAddress("arron.air@yandex.ru", "Arron");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Подтверждение";
            m.Body = $"<h2>Ваш код подтверждения: {new Random().Next(10000, 99999)}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("arron.air", "owjkxjbpktofrhmv");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

