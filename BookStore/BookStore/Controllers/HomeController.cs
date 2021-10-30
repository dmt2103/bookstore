using BookStore.Contract.RequestModels;
using BookStore.Service.Book;
using BookStore.Service.Category;
using BookStore.Service.Tag;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public HomeController(IBookService bookService, ICategoryService categoryService, ITagService tagService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public IActionResult Index(string searchString)
        {
            var listBook = _bookService.GetAllBooks(searchString);

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
            if (!ModelState.IsValid) return View(book);

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
    }
}