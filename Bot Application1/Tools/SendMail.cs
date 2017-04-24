using System.Net;
using System.Net.Security;
using System.Net.Mail;
using Microsoft.Exchange.WebServices.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Bot.Builder.Dialogs;

namespace BotApplication1
// usage: EmailDomain.SendEmail("patronus@telenor.com","patronus@telenor.com","Feedback","FeedbackText")

{
    public class EmailDomain
    {
        public static string HostName = "tsepost.telenor.se";
        public static void SendEmail(string FromAddress, string SendTo, string Subject, string HtmlBody)
        {

            MailMessage MailMessageObj = new MailMessage();

            MailMessageObj.From = new MailAddress(FromAddress);
            MailMessageObj.Subject = Subject;
            MailMessageObj.Body = HtmlBody;
            MailMessageObj.IsBodyHtml = true;

            MailMessageObj.To.Add(SendTo);
            
            System.Net.Mail.SmtpClient SmtpClientObj = new System.Net.Mail.SmtpClient();

            SmtpClientObj.Host = HostName;
            SmtpClientObj.Credentials = new System.Net.NetworkCredential(domain: "TSE", userName: "mb890818", password: "");
            SmtpClientObj.EnableSsl = true;
            //SmtpClientObj.Send(MailMessageObj);
            SmtpClientObj.Dispose();
        }

        public static void SendGmail(string body)
        {

            var fromAddress = new MailAddress("michael.bustergren@gmail.com", "Patronus Bot");
            var toAddress = new MailAddress("patronus@telenor.com", "Telenor Patronus");
            const string fromPassword = "Enigma123";
            const string subject = "Feedback";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
        
        public static bool SendExchangeMail(string body)
        {
            bool success = true;
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;

            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials("mb890818", "Owedda111", "tse");

            // service.AutodiscoverUrl("username@yourdomain.com", RedirectionUrlValidationCallback);
            service.Url = new System.Uri("https://tsepost.telenor.se/EWS/Exchange.asmx");

            EmailMessage email = new EmailMessage(service);
            email.ToRecipients.Add("patronus@telenor.com");
            email.Subject = "Feedback";
            email.Body = new MessageBody(body);
            try
            {
                email.Send();
            }
            catch
            {
                success = false;
            }
            return success;
        }
        private static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }


    }
}