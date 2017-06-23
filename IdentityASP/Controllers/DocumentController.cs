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

     
        [HttpPost]
        public JsonResult UploadDocument()
        {
           
            if (ModelState.IsValid)
            {
    
                DocumentViewModel viewmodel = new DocumentViewModel();
                viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId());
                viewmodel.DocumentFiles = Request.Files;
                result = DocumentBusiness.UploadDocument(viewmodel);

                if (result)
                {
                    ViewBag.Message = "Upload Success";
                }
                else
                {
                    ViewBag.Message = "Upload Failed";
                }
            }

            return Json(new { success = result, message= ViewBag.Message });
        }

        
        public FileResult DownloadDocument(string documentName)
        {

            DocumentViewModel viewmodel = new DocumentViewModel();
            viewmodel.DocumentPath = Server.MapPath(viewmodel.DocumentLocation + User.Identity.GetUserId() + Resources.Document.Slash + documentName);      
            return File(DocumentBusiness.DownloadDocument(viewmodel), DocumentBusiness.GetTypeOctet(), DocumentBusiness.GetFileName(viewmodel));

        }


























    }
}