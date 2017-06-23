using Entities.Resources;
using Entities.VM;
using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DocumentBusiness
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;

        public static byte[] DownloadDocument(DocumentViewModel viewmodel)
        {
            return System.IO.File.ReadAllBytes(viewmodel.DocumentPath);

        }


        public static List<DocumentViewModel> GetDocuments(DocumentViewModel viewmodel)
        {

            var documents = new List<DocumentViewModel>();

            try
            {
                if (Directory.Exists(viewmodel.DocumentPath))
                {                   
                    documents = Directory.GetFiles(viewmodel.DocumentPath).Select(store => new DocumentViewModel { DocumentName = Path.GetFileName(store) }).ToList();
                }                        
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documents;
        }


        public static string GetFileName(DocumentViewModel viewmodel)
        {
            return Path.GetFileName(viewmodel.DocumentPath);
        }


        public static string GetTypeOctet()
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }


        public static bool UploadDocument(DocumentViewModel viewmodel)
        {

            if (!Directory.Exists(viewmodel.DocumentPath))
            {
                Directory.CreateDirectory(viewmodel.DocumentPath);
            }
            try
            {
                for (int fileNumber = 0; fileNumber < viewmodel.DocumentFiles.Count; fileNumber++)
                {

                    viewmodel.DocumentPostedFile = viewmodel.DocumentFiles.Get(fileNumber);

                    if (viewmodel.DocumentPostedFile.ContentLength != 0)
                    {
                        viewmodel.DocumentCombinePath = Path.Combine(viewmodel.DocumentPath + Document.Backslash + viewmodel.DocumentPostedFile.FileName);
                        viewmodel.DocumentPostedFile.SaveAs(viewmodel.DocumentCombinePath);
                    }

                }

                result = true;

            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
