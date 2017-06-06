using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityASP.Models.ViewModel
{
    public class ManufacturerViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public string Telephone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public List<ManufacturerViewModel> ManufacturerList { get; set; }
    }
}