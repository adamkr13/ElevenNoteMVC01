using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteEdit
    {
        [Required]
        [DisplayName("Note Id")]
        public int NoteId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int? CategoryId { get; set; }
    }
}
