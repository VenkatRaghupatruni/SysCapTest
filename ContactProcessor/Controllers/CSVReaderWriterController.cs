using System.Web;
using System.Web.Mvc;
using ContactProcessor.Models;
using ContactProcessor.Interfaces;

namespace ContactProcessor.Controllers
{
    public class CSVReaderWriterController : Controller
    {
        // we just need references to service abstractions 
        private IFileSystemService _fileSystemService;
        private IFileUploader _fileUploader;
        private IFileProcessor _fileProcessor;

        //Dependency injection through constructor
        public CSVReaderWriterController(IFileSystemService fileSystemService, IFileUploader fileUploader, IFileProcessor fileProcessor)
        {
            _fileSystemService = fileSystemService;
            _fileUploader = fileUploader;
            _fileProcessor = fileProcessor;
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
            string uploadedFilePath = _fileUploader.UploadFile(file, uploadFolder);
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
            _fileProcessor.ProcessFile(filename);

            return Content("Email Sent");
        }

        // It may be a bit overkill in this case, but normally this is the way to dispose off 
        // the resources.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (_fileSystemService != null)
                    _fileSystemService.Dispose();
            }
        }
    }
}