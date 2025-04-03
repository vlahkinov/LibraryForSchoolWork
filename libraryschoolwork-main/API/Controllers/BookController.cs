using Domain.Abstractions.Services;
using Domain.Dtos.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAllAsync();
            return View(books);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.CreateAsync(model);
                TempData["success"] = "Book created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var author = await bookService.GetByIdAsync(id);
            if (author==null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.UpdateAsync(model);
                TempData["success"] = "Book edited successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = await bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var book = bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await bookService.DeleteAsync(id);
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
