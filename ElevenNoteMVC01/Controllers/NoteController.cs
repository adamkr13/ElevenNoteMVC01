using ElevenNote.Models.Note;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNoteMVC01.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateNoteService();

            var model = service.GetNotes();

            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateNoteService();
            //var model = service.CategoryOptionsCreate();
            //ViewData["Categories"] = model;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateNoteService();

            var model = svc.GetNoteById(id);


            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateNoteService();

            var detail = service.GetNoteById(id);

            //var categoryList = service.CategoryOptionsEdit();

            //if (detail.CategoryName == null)
            //{
            //    categoryList.Insert(0, new SelectListItem { Text = "--Select Category--", Value = "" });
            //    categoryList.Add(new SelectListItem { Text = "No Category", Value = "" });
            //}
            //else
            //{
            //    string value = "";
            //    foreach (var item in categoryList)
            //    {
            //        if(item.Text == detail.CategoryName)
            //            value = item.Value.ToString();
            //    }
            //    categoryList.Insert(0, new SelectListItem { Text = detail.CategoryName, Value = value });
            //    categoryList.Add(new SelectListItem { Text = "No Category", Value = "" });
            //}


            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content                    
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNoteService();

            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNoteService();

            var model = svc.GetNoteById(id);


            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNoteService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
    }
}