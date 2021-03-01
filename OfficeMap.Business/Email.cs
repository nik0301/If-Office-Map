using System.Net.Mail;

namespace OfficeMap.Business
{
    public class Email
    {
        public void SendEmail(MailMessage message)
        {
            using (var smtp = new SmtpClient("smtp.ifint.biz"))
            {
                smtp.Send(message);
            }
        }
    }
}
