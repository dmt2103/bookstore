using BookStore.Contract.RequestModels;
using BookStore.Service.Book;
using BookStore.Service.BookTag;
using BookStore.Service.Category;
using BookStore.Service.Tag;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IBookTagService _bookTagService;

        public HomeController(IBookService bookService, ICategoryService categoryService, ITagService tagService, IBookTagService bookTagService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _tagService = tagService;
            _bookTagService = bookTagService;
        }

        public IActionResult Index(string searchString)
        {
            var listBook = _bookService.GetAllBooks(searchString);
            ViewBag.Search = searchString;

            return View(listBook);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _categoryService.GetAllCategories(string.Empty);

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookRequestModel book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _bookService.CreateBook(book);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Update(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList = _categoryService.GetAllCategories(string.Empty);

            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Guid? id, BookRequestModel book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
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

            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Guid bookId)
        {
            _bookService.DeleteBook(bookId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateTag(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Tags = _tagService.GetAllTags(string.Empty);

            var addedTags = _tagService.GetTagsByBookId(id);

            foreach (var item in book.Tags)
            {
                if (addedTags.Exists(t => t.TagId.Equals(item.TagId)))
                {
                    item.Selected = true;
                }
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult UpdateTag(Guid id, List<TagRequestModel> tags)
        {
            if (ModelState.IsValid)
            {
                _bookTagService.DeleteBookTagByBookId(id);

                foreach (var item in tags)
                {
                    if (item.Selected)
                    {
                        var bookTag = new BookTagRequestModel
                        {
                            BookId = id,
                            TagId = item.TagId
                        };
                        _bookTagService.CreateTag(bookTag);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}