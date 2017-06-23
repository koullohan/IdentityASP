using Business;
using Entities.VM;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{

    [Authorize(Roles = "Admin")]

    public class DocumentController : Controller
    {

        private static bool result = false;
        
        [HttpGet]
        public ActionResult Index()
        {
            
            DocumentViewModel viewmodel = new DocumentViewModel();
            viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId());
            viewmodel.DocumentList = DocumentBusiness.GetDocuments(viewmodel);
            return View(viewmodel);

        }


        public ActionResult LoadDocuments()
        {
            DocumentViewModel viewmodel = new DocumentViewModel();
            viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId());
            viewmodel.DocumentList = DocumentBusiness.GetDocuments(viewmodel);
            return PartialView("_Document", viewmodel);

        }
       
        public JsonResult UploadDocument()
        {
            string message = "";
            if (ModelState.IsValid)
            {
    
                DocumentViewModel viewmodel = new DocumentViewModel();
                viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId());
                viewmodel.DocumentFiles = Request.Files;
                result = DocumentBusiness.UploadDocument(viewmodel);
                
                if (result)
                {
                    message = "File uploaded successfully";
                }
                else
                {
                    message = "File has not uploaded successfully";
                }
            }
            return Json(new { success = result, message = message }, JsonRequestBehavior.AllowGet);
            //return Json(new { success = result,message = message  ,Url = Url.Action("_Document", LoadDocuments())}, JsonRequestBehavior.AllowGet);

        }

        
        public FileResult DownloadDocument(string documentName)
        {

            DocumentViewModel viewmodel = new DocumentViewModel();
            viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId() + Resources.Document.Slash + documentName);      
            return File(DocumentBusiness.DownloadDocument(viewmodel), DocumentBusiness.GetTypeOctet(), DocumentBusiness.GetFileName(viewmodel));

        }


























    }
}