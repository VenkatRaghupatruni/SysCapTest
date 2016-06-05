using System;
using System.Collections.Generic;
using System.IO;
using ContactProcessor.Models;
using ContactProcessor.Interfaces;

namespace ContactProcessor.Services
{
    // This class handles generic file activities like reading from a file
    // and writing to file
    public class FileSystemService : IFileSystemService
    {

#region "Public Methods"
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


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

#region "Private Methods"     
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