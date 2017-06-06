using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CategoryDescription { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Model { get; set; }

        public string ReleasedDate { get; set; }

        public string ReleasedYear { get; set; }
           
        public List<ProductViewModel> ProductList { get; set; }

        public List<SelectListItem> ManufacturerSelectList { get; set; }

        public List<SelectListItem> CategorySelectList { get; set; }
    }
}