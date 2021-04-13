using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Junctions
{
    public class CategoryNoteDelete
    {
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
    }
}
