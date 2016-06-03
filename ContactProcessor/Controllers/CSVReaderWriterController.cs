using System.Web;
using System.Web.Mvc;
using ContactProcessor.Models;
using ContactProcessor.Services;

namespace ContactProcessor.Controllers
{
    public class CSVReaderWriterController : Controller
    {

        private IFileSystemService _fileSystemService;

        public CSVReaderWriterController(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        [HttpGet]
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read(HttpPostedFileBase file)
        {
            string uploadFolder = Server.MapPath("~/App_Data/Uploads");
            string uploadedFilePath = _fileSystemService.UploadFile(file, uploadFolder);
            var model = _fileSystemService.ReadFile(uploadedFilePath);
            return View("DisplayInput", model);
        }

        [HttpGet]
        public ActionResult Write(string filename)
        {
            var model = new ContactViewModel("", "", "", "", filename);
            return View(model);
        }

        [HttpPost]
        public ActionResult Write(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = _fileSystemService.WriteToFile(model);

                return View("DisplayInput", data);
            }
            
            return View("Write", model.FileName);
            
        }

        public ActionResult Process(string filename)
        {
            _fileSystemService.ProcessFile(filename);

            return Content("Email Sent");
        }
    }
}