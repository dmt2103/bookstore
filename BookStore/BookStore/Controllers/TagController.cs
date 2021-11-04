using BookStore.Contract.RequestModels;
using BookStore.Service.Book;
using BookStore.Service.BookTag;
using BookStore.Service.Tag;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IBookService _bookService;
        private readonly IBookTagService _bookTagService;

        public TagController(ITagService tagService, IBookService bookService, IBookTagService bookTagService)
        {
            _tagService = tagService;
            _bookService = bookService;
            _bookTagService = bookTagService;
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

                return View();
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

        public IActionResult DeleteConfirm(Guid? id)
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

            return View(tag);
        }

        [HttpPost]
        public IActionResult Delete(Guid tagId)
        {
            _bookTagService.DeleteBookTagByTagId(tagId);
            _tagService.DeleteTag(tagId);

            return RedirectToAction(nameof(Index));
        }
    }
}