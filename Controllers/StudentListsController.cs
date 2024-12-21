using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ford_Hackhathon_YurtSistemi.Models;

namespace Ford_Hackhathon_YurtSistemi.Controllers
{
    public class StudentListsController : Controller
    {
        private readonly YurtSistemiContext _context;

        public StudentListsController(YurtSistemiContext context)
        {
            _context = context;
        }

        // GET: StudentLists
        public async Task<IActionResult> Index()
        {
            var yurtSistemiContext = _context.StudentLists.Include(s => s.RoomList);
            return View(await yurtSistemiContext.ToListAsync());
        }

        // GET: StudentLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentLists == null)
            {
                return NotFound();
            }

            var studentList = await _context.StudentLists
                .Include(s => s.RoomList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentList == null)
            {
                return NotFound();
            }

            return View(studentList);
        }

        // GET: StudentLists/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.RoomLists, "Id", "Id");
            return View();
        }

        // POST: StudentLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,TcNo,Name,Surname,Telephone,Images,RoomId")] StudentList studentList, IFormFile photo)
{
    if (ModelState.IsValid)
    {
        // Eğer bir resim yüklenmişse işlemleri yap
        if (photo != null)
        {
            // Dosya adını benzersiz hale getir
            var fileName = Path.GetFileName(photo.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Resmi belirtilen klasöre kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // Dosya yolunu veritabanına kaydetmek için modeli güncelle
            studentList.Images = "/images/" + uniqueFileName;
        }

        // Öğrenciyi veritabanına ekle
        _context.Add(studentList);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Eğer hata varsa formu tekrar göster
    ViewData["RoomId"] = new SelectList(_context.RoomLists, "Id", "Id", studentList.RoomId);
    return View(studentList);
}


        // GET: StudentLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentLists == null)
            {
                return NotFound();
            }

            var studentList = await _context.StudentLists.FindAsync(id);
            if (studentList == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.RoomLists, "Id", "Id", studentList.RoomId);
            return View(studentList);
        }

        // POST: StudentLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TcNo,Name,Surname,Telephone,Images,RoomId")] StudentList studentList)
        {
            if (id != studentList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentListExists(studentList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.RoomLists, "Id", "Id", studentList.RoomId);
            return View(studentList);
        }

        // GET: StudentLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentLists == null)
            {
                return NotFound();
            }

            var studentList = await _context.StudentLists
                .Include(s => s.RoomList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentList == null)
            {
                return NotFound();
            }

            return View(studentList);
        }

        // POST: StudentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentLists == null)
            {
                return Problem("Entity set 'YurtSistemiContext.StudentLists'  is null.");
            }
            var studentList = await _context.StudentLists.FindAsync(id);
            if (studentList != null)
            {
                _context.StudentLists.Remove(studentList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentListExists(int id)
        {
          return (_context.StudentLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
