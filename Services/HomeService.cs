using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;

namespace Eskoy.Services{

    public class HomeService {

        public bool ValitadeSentFile(IFormFile file) {

            if(file.ContentType == "application/pdf" ||
              file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || 
              file.ContentType == "text/rtf" ||
              file.ContentType == "application/vnd.oasis.opendocument.text" ||
              file.ContentType == "text/plain"){
                  return true;
              }

            return false;
        }
        public void SendEmail(IFormFile attachment, string Subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("testemailsender2000@gmail.com", "hrafn@eskoy.no", Subject, body);

                if (attachment != null)
                {
                    Attachment emailAttachment = new Attachment(attachment.OpenReadStream(), attachment.FileName);
                    mail.Attachments.Add(emailAttachment);
                }
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("testemailsender2000@gmail.com", "popptivi");
                client.Send(mail);
            }
            catch
            {

            }
        }
    }
}
