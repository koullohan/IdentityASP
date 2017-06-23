using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entities.Resources;
namespace Entities.VM
{
    public class DocumentViewModel
    {

        private string documentLocation = Resources.Document.Location;

        public int DocumentId { get; set; }    
       
        public string DocumentCombinePath { get; set; }

        public HttpFileCollectionBase DocumentFiles { get; set; }

        public List<DocumentViewModel> DocumentList { get; set; }

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

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public HttpPostedFileBase DocumentPostedFile { get; set; }



    }

}
