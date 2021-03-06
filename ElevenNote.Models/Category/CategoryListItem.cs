using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Category
{
    public class CategoryListItem
    {
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Category Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
