using System.Web;

namespace ContactProcessor.Interfaces
{
    public interface IFileUploader
    {
        string UploadFile(HttpPostedFileBase file, string uploadFolder);
    }
}