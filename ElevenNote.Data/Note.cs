using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        [DisplayName("Owner Id")]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Title must be less than 20 characters.")]
        [DisplayName("Note Title")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual List<CategoryNote> Categories { get; set; } = new List<CategoryNote>();
    }
}
