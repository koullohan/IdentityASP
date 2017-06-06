using Entities.Document;
using Entities.ViewModel;
using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DocumentBusiness
    {
        private static ApplicationDbContext identityASPdb = new ApplicationDbContext();

        private static bool result = false;

        public static byte[] DownloadDocument(Document model)
        {
            return System.IO.File.ReadAllBytes(model.Path);

        }


        public static List<Document> GetDocuments(Document model)
        {

            var documents = new List<Document>();

            try
            {

                var files = Directory.EnumerateFiles(model.Path).ToList();

                foreach (var file in files)
                {
                    var document = new Document();
                    document.Name = Path.GetFileName(file);
                    documents.Add(document);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documents;
        }


        public static string GetFileName(Document model)
        {
            return Path.GetFileName(model.Path);
        }


        public static string GetTypeOctet()
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }


        public static bool UploadDocument(Document viewmodel)
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
                        viewmodel.DocumentCombinePath = Path.Combine(viewmodel.DocumentPath + "\\" + viewmodel.DocumentPostedFile.FileName);
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
