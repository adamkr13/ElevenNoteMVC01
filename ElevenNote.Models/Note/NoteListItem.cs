﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteListItem
    {
        public int NoteId { get; set; }

        [DisplayName("Note Title")]
        public string Title { get; set; }

        [DisplayName("Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}