using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage ="Please enter a maximum of 20 characters.")]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        public int? CategoryId { get; set; }
    }
}
