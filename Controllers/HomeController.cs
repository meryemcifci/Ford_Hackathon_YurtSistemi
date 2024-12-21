using Ford_Hackhathon_YurtSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Ford_Hackhathon_YurtSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YurtSistemiContext _context;

        // Constructor ile logger ve DbContext enjekte ediliyor
        public HomeController(ILogger<HomeController> logger, YurtSistemiContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var dorms = _context.DormLists.ToList(); // Veritabanından yurtları çek
            return View(dorms); // Yurtları View'e gönder
        }
        public IActionResult Details(int id)
        {
            var dorm = _context.DormLists.FirstOrDefault(d => d.Id == id);
            if (dorm == null)
            {
                return NotFound(); // Eğer yurt bulunamazsa 404 döner
            }
            return View(dorm); // Detayları View'e gönder
        }
        public IActionResult Rooms(int id)
        {
            var rooms = _context.RoomLists.Where(r => r.DormId == id).ToList();
            if (rooms == null || !rooms.Any())
            {
                return NotFound();
            }
            return View(rooms);
        }

        public IActionResult Students(int id)
        {
            var students = _context.StudentLists
            .Include(s => s.RoomList) // RoomList ile ilişkiyi dahil et
            .Where(s => s.RoomList.DormId == id) // DormId'ye göre filtrele
            .ToList();

            if (students == null || !students.Any())
            {
                return NotFound();
            }

            return View(students);
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
