using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            if (id is null || id == 0)
            {
                Category category = new Category();
                return View(category);
            }
            else
            {
                Category? category = _unitOfWork.Category.Get(category => category.Id == id);
                return View(category);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (category.Id == 0)
            {
                _unitOfWork.Category.Add(category);
                TempData["success"] = $"Category {category.Title} was created";
            }
            else
            {
                _unitOfWork.Category.Update(category);
                TempData["success"] = $"Category {category.Title} was updated";
            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
