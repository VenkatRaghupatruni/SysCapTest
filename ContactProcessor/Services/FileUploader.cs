using System;
using System.IO;
using System.Linq;
using System.Web;
using ContactProcessor.Interfaces;

namespace ContactProcessor.Services
{
    // This class is responsible for uploading a file.
    public class FileUploader: IFileUploader
    {
        public string UploadFile(HttpPostedFileBase file, string uploadFolder)
        {
            string newFilePath = "";
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
    }
}