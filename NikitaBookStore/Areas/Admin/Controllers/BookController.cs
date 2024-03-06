using Microsoft.AspNetCore.Mvc;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork
            return View();
        }
    }
}
