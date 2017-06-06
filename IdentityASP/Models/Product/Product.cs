using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace IdentityASP.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
       
        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string ReleasedDate { get; set; }

        public string ReleasedYear { get; set; }

        public bool isDelete { get; set; }
    }
}