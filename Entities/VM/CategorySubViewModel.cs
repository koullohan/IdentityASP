using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.VM
{
    public class CategorySubViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public List<CategorySubViewModel> CategorySubList { get; set; }

    }
}