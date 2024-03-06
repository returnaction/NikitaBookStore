using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.Book.GetAll(includeProperties: "Category").ToList();
            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            });

            BookVM bookVM = new BookVM()
            {
                Book = new Book(),
                CategoryList = CategoryList
            };

            if (id is null || id == 0)
            {
                //create
                return View(bookVM);
            }
            else
            {
                bookVM.Book = _unitOfWork.Book.Get(book => book.Id == id);
                return View(bookVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(BookVM bookVM, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                bookVM.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
                return View(bookVM);
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string bookPath = Path.Combine(wwwRootPath, $@"images\books");

                if (!string.IsNullOrEmpty(bookVM.Book.ImageURL))
                {
                    // delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, bookVM.Book.ImageURL.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                bookVM.Book.ImageURL = @"\images\books\" + fileName;
            }

            if(bookVM.Book.Id == 0)
            {
                _unitOfWork.Book.Add(bookVM.Book);
                TempData["success"] = $"Book {bookVM.Book.Title} was created";
            }
            else
            {
                _unitOfWork.Book.Update(bookVM.Book);
                TempData["success"] = $"Book {bookVM.Book.Title} was updated";
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Book? book = _unitOfWork.Book.Get(book => book.Id == id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(int id)
        {
            Book? book = _unitOfWork.Book.Get(b => b.Id == id);

            _unitOfWork.Book.Remove(book);
            _unitOfWork.Save();

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (!string.IsNullOrEmpty(book.ImageURL))
            {
                // delete the old image
                string oldImagePath = Path.Combine(wwwRootPath, book.ImageURL.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            TempData["success"] = $"Book {book.Title} was deleted";

            return RedirectToAction(nameof(Index));
        }
    }
}
