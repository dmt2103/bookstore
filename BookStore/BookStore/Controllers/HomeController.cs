using BookStore.Contract.RequestModels;
using BookStore.Service.Book;
using BookStore.Service.Category;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public HomeController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
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

            return View(book);
        }

        public IActionResult Delete(Guid? id)
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
        public IActionResult Delete(Guid id)
        {
            _bookService.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }
    }
}