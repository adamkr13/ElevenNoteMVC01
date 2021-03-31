using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Category Description")]
        [MaxLength(1000, ErrorMessage ="There is a max of 1000 characters.")]
        public string Description { get; set; }
    }
}
