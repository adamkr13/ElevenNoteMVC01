using ElevenNote.Models.Junctions;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNoteMVC01.Controllers
{
    public class CategoryNoteController : Controller
    {
        // GET: CategoryNote
        public ActionResult Index()
        {
            var service = CreateCategoryNoteService();
            var model = service.GetCategoryNotes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryNoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryNoteService();

            if (service.CreateCategoryNote(model))
            {
                TempData["SaveResult"] = $"Note {model.NoteId} was added to category {model.CategoryId}";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The category could not be assigned to the note.");

            return View(model);
        }



        private CategoryNoteService CreateCategoryNoteService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryNoteService(userId);
            return service;
        }
    }
}