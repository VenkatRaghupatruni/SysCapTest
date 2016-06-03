using ContactProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ContactProcessor.Services
{
    public interface IFileSystemService
    {
        string UploadFile(HttpPostedFileBase file, string uploadFolder);
        DisplayInputViewModel ReadFile(string file);
        DisplayInputViewModel WriteToFile(ContactViewModel model);
        void ProcessFile(string file);
    }
}