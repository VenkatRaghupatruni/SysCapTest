using System.IO;
using System.Net.Mail;
using ContactProcessor.Interfaces;

namespace ContactProcessor.Services
{
    public class FileProcessor : IFileProcessor
    {
#region "public methods"

        //This class is responsible for processing a file i.e. preparing and sending a mail.
        public void ProcessFile(string filePath)
        {
            var to = "";
            var line = "";
            string[] values;
            var from = "youremail@yourservername.com";

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    values = line.Split(',');
                    to = values[3];
                    if (to.Contains("@"))
                    {
                        prepareAndSendMessage(from, to);
                    }
                    else if (values[2].Contains("07"))
                    {
                        //TODO: send text message
                    }
                }
            }
        }

#endregion

        #region "Private Methods"     
        private void prepareAndSendMessage(string from, string to)
        {
            var message = prepareMessage(from, to);
            sendMessage(message);
        }

        private MailMessage prepareMessage(string from, string to)
        {
            return new MailMessage(from, to)
            {
                Subject = "Automated Email",
                Body = @"Hi, You are received this as you exist in my contacts list."
            };
        }

        private void sendMessage(MailMessage message)
        {
            using (SmtpClient client = new SmtpClient("yourservername"))
            {
                client.UseDefaultCredentials = true;
                client.Send(message);
            }
        }
        #endregion
    }
}