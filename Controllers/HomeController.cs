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

        public HomeController(ILogger<HomeController> logger, YurtSistemiContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var dorms = _context.DormLists.ToList();
            return View(dorms);
        }

        public IActionResult Details(int id)
        {
            var dorm = _context.DormLists.FirstOrDefault(d => d.Id == id);
            if (dorm == null)
            {
                return NotFound(); 
            }
            return View(dorm);
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
                .Include(s => s.RoomList) 
                .Where(s => s.RoomList.DormId == id)
                .ToList();

            if (students == null || !students.Any())
            {
                return NotFound(); 
            }

            return View(students);
        }
        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
               
                return View(new List<DormList>());
            }

            var results = _context.DormLists
                                  .Where(d => d.Name.Contains(query) || d.Address.Contains(query))
                                  .ToList();

            return View(results);
        }


        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DormList dorm)
        {
            if (!ModelState.IsValid) 
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"ModelState Hatası: {error.ErrorMessage}");
                }
                return View(dorm);
            }

            _context.DormLists.Add(dorm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Yurt Silme İşlemi
        public IActionResult Delete(int id)
        {
           
            var dorm = _context.DormLists.FirstOrDefault(d => d.Id == id);
            if (dorm == null)
            {
                return NotFound(); 
            }

            _context.DormLists.Remove(dorm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Gizlilik Sayfası
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata Sayfası
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
