using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ContactProcessor.Models;
using System.Net.Mail;

namespace ContactProcessor.Services
{
    public class FileSystemService : IFileSystemService, IDisposable
    {

#region "Public Methods"

        public string UploadFile(HttpPostedFileBase file, string uploadFolder)
        {
            string newFilePath ="";
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var splitfilename = fileName.Split('.').ToArray();

                fileName = splitfilename[0] + Guid.NewGuid() + '.' + splitfilename[1];

                newFilePath = Path.Combine(uploadFolder, fileName);
                file.SaveAs(newFilePath);
            }
            return newFilePath;
        }

        public DisplayInputViewModel ReadFile(string file)
        {
            var model = new DisplayInputViewModel();
            using (var reader = new StreamReader(file))
            {
                model.FileName = file;
                model.Contacts = new List<ContactViewModel>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    model.Contacts.Add(new ContactViewModel(values[0], values[1], values[2], values[3], string.Empty));
                }

                reader.Close();
            }
            return model;
        }

        public DisplayInputViewModel WriteToFile(ContactViewModel model)
        {
            var modelContents = string.Format("{0}, {1}, {2}, {3} \n", model.FirstName, model.LastName,  model.PhoneNumber, model.Email);

            File.AppendAllText(model.FileName, modelContents);

            return ReadFile(model.FileName);
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {
                // Dispose managed resources.
            }

            // Dispose unmanaged managed resources.
        }
#endregion

    }
}