using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityASP.Models
{
    public class Inventory
    {
        public int ProductId { get; set; }

        public int New { get; set; }

        public int Used { get; set; }

        public int Refurbished { get; set; }

        public int CategoryId { get; set; }

        public int CategorySubId { get; set; }
    }
}