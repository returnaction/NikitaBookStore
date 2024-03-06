using Microsoft.AspNetCore.Mvc;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace NikitaBookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.Book.GetAll(includeProperties: "Category").ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            Book? book = _unitOfWork.Book.Get(book => book.Id == id, includeProperties: "Category");
            return View(book);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
