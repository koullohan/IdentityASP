using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityASP.Models.ViewModel
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public List<CategoryViewModel> CategoryList { get; set; }
    }
}