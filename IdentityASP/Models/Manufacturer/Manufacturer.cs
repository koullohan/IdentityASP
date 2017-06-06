using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityASP.Models
{
    public class Manufacturer
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

        [Required]
        public bool isDelete { get; set; }
    }
}