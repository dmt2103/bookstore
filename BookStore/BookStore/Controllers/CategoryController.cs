﻿using BookStore.Contract.RequestModels;
using BookStore.Service.Category;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(string searchString)
        {
            var listCategory = _categoryService.GetAllCategories(searchString);
            ViewBag.Search = searchString;

            return View(listCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryRequestModel category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _categoryService.CreateCategory(category);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Update(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Guid? id, CategoryRequestModel category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Update));
        }

        public IActionResult DeleteConfirm(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Guid categoryId)
        {
            _categoryService.DeleteCategory(categoryId);

            return RedirectToAction(nameof(Index));
        }
    }
}