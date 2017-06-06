using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
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
