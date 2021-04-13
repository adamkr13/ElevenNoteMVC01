using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Junctions
{
    public class CategoryNoteListItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
    }
}
