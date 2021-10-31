using BookStore.Contract.RequestModels;
using BookStore.Service.Book;
using BookStore.Service.Tag;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IBookService _bookService;

        public TagController(ITagService tagService, IBookService bookService)
        {
            _tagService = tagService;
            _bookService = bookService;
        }

        public IActionResult Index(string searchString)
        {
            var listTag = _tagService.GetAllTags(searchString);
            ViewBag.Search = searchString;

            return View(listTag);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TagRequestModel tag)
        {
            if (!ModelState.IsValid)
            {

                return View(tag);
            }

            _tagService.CreateTag(tag);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _tagService.GetTag(id);
            if (tag == null)
            {
                return NotFound();
            }

            tag.Books = _bookService.GetBookByTagId(id);

            return View(tag);
        }
    }
}