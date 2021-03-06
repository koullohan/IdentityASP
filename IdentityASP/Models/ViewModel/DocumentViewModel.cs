﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityASP.Models.ViewModel
{
    public class DocumentViewModel
    {

        private string documentLocation = IdentityASP.Resources.Document.Location;

        public int DocumentId { get; set; }
        public string DocumentName { get; set; }

        public string DocumentLocation
        {
            get
            {
                return documentLocation;
            }
            set
            {
                documentLocation = value;
            }
        }

        public string DocumentPath { get; set; }

        public List<DocumentViewModel> DocumentList { get; set; }

        public HttpFileCollectionBase DocumentFiles { get; set; }

        public HttpPostedFileBase DocumentPostedFile { get; set; }

        public string DocumentCombinePath { get; set; }

       
    }
}