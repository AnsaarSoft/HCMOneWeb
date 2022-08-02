using System.Net;
using System.Net.Mail;

namespace HCM.API.General
{
    public class Email
    {
        #region Variables

        string TitleConfig = "";
        string EmailConfig = "";
        string PasswordConfig = "";
        string HostConfig = "";
        int PortConfig = 0;
        bool IsSSlConfig = true;

        #endregion

        #region Functions      

        public bool GetEmailSettings()
        {
            bool IsTrue = false;
            try
            {
                TitleConfig = Settings.TitleConfig;
                EmailConfig = Settings.EmailConfig;
                PasswordConfig = Settings.PasswordConfig;
                HostConfig = Settings.HostConfig;
                PortConfig = Settings.PortConfig;
                IsSSlConfig = Settings.IsSSlConfig;
                IsTrue = true;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return IsTrue;
        }
        public bool SentEmail(string Subject, string Body, string SenderName, string ReceiverEmail)
        {
            // For localhost "smtp.gmail.com", Port 587
            bool IsSent = false;
            try
            {
                if (GetEmailSettings())
                {
                    SmtpClient _smtp = new SmtpClient();
                    _smtp.Host = HostConfig;
                    _smtp.Port = PortConfig;
                    _smtp.EnableSsl = IsSSlConfig;
                    NetworkCredential _network = new NetworkCredential(EmailConfig, PasswordConfig);
                    _smtp.Credentials = _network;
                    MailMessage _mailmsg = new MailMessage();
                    _mailmsg.IsBodyHtml = true;                    
                    _mailmsg.From = new MailAddress(EmailConfig, TitleConfig);
                    _mailmsg.To.Add(ReceiverEmail);
                    _mailmsg.Subject = Subject;

                    string MailMessage = Body;
                    _mailmsg.Body = MailMessage;

                    _smtp.Send(_mailmsg);
                    IsSent = true;
                }
                else
                {
                    IsSent = false;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return IsSent;
        }

        #endregion
    }
}
