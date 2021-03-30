﻿using ElevenNote.Models.Category;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNoteMVC01.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        // GET: Category
        public ActionResult Index()
        {
            var service = CreateCategoryService();
            var model = service.GetCategories();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "The category was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be created.");

            return View(model);
        }



        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
    }
}