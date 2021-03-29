using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        [DisplayName("Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
