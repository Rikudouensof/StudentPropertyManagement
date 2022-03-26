using StudentPropertyManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ProjectTasks
{
  public class EmailManagement
  {
    //public EmailCredentials _emailCredentials;
    //public EmailManagement(EmailCredentials emailCredentials)
    //{
    //  _emailCredentials = emailCredentials;
    //}

    public static void SendMail(EmailProperty message)
    {
      EmailCredentials emailCredentials = new EmailCredentials();
      #region formatter
      string text = string.Format("{0}: {1}", message.Subject, message.Body);

      #endregion
     
      MailMessage msg = new MailMessage();
      msg.From = new MailAddress(emailCredentials.senderEmail);
      msg.To.Add(new MailAddress(message.Destination));
      msg.Subject = message.Subject;
      msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));
      msg.IsBodyHtml = true;
      //  msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

      SmtpClient smtpClient = new SmtpClient(emailCredentials.websiteAddress, Convert.ToInt32(587));
      System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(emailCredentials.senderEmail, emailCredentials.senderPassword);
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = credentials;
      smtpClient.EnableSsl = false;
      smtpClient.Send(msg);
    }


  }


  public class EmailProperty
  {

    public string Destination { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
  }
}
