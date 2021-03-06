﻿using IdentityASP.Models;
using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IdentityASP.Business
{
    public class DocumentDAO
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

                var files = Directory.EnumerateFiles(viewmodel.DocumentPath).ToList();

                foreach (var file in files)
                {
                    var document = new DocumentViewModel();
                    document.DocumentName = Path.GetFileName(file);                 
                    documents.Add(document);
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
                        viewmodel.DocumentCombinePath = Path.Combine(viewmodel.DocumentPath + Resources.Document.DocumentDoubleBackslash + viewmodel.DocumentPostedFile.FileName);
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