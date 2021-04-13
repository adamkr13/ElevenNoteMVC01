﻿using ElevenNote.Data;
using ElevenNote.Models.Junctions;
using ElevenNoteMVC01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryNoteService
    {
        private readonly Guid _userId;

        public CategoryNoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<CategoryNoteListItem> GetCategoryNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CategoryNotes
                        .Select(e =>
                        new CategoryNoteListItem
                        {
                            CategoryId = e.CategoryId,
                            NoteId = e.NoteId
                        });
                return query.ToArray();
            }
        }

        public bool CreateCategoryNote (CategoryNoteCreate model)
        {
            var entity = new CategoryNote()
            {
                CategoryId = model.CategoryId,
                NoteId = model.NoteId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.CategoryNotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategoryNote(int noteId, int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CategoryNotes.SingleOrDefault(e => e.CategoryId == categoryId && e.NoteId == noteId);

                if (entity != null)
                {
                    ctx.CategoryNotes.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

    }
}