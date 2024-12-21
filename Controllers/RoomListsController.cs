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
    public class RoomListsController : Controller
    {
        private readonly YurtSistemiContext _context;

        public RoomListsController(YurtSistemiContext context)
        {
            _context = context;
        }

        // GET: RoomLists
        public async Task<IActionResult> Index()
        {
            var yurtSistemiContext = _context.RoomLists.Include(r => r.DormList);
            return View(await yurtSistemiContext.ToListAsync());
        }

        // GET: RoomLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomLists == null)
            {
                return NotFound();
            }

            var roomList = await _context.RoomLists
                .Include(r => r.DormList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomList == null)
            {
                return NotFound();
            }

            return View(roomList);
        }

        // GET: RoomLists/Create
        public IActionResult Create()
        {
            ViewData["DormId"] = new SelectList(_context.DormLists, "Id", "Id");
            return View();
        }

        // POST: RoomLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Floor,Capacity,CurrentOccupancy,OccupancyRate,DormId")] RoomList roomList)
        {
            // Model doğrulamasını kontrol et
            if (!ModelState.IsValid)
            {
                // Hata durumunda DormId için gerekli verileri tekrar yükle ve formu geri döndür
                ViewData["RoomId"] = new SelectList(_context.RoomLists, "Id", "Name", roomList.Id);
                return View(roomList);
            }

            try
            {
                // Veritabanına RoomList ekle
                _context.Add(roomList);
                await _context.SaveChangesAsync();

                // İşlem başarıyla tamamlandığında Index sayfasına yönlendir
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını logla
                Console.WriteLine($"Hata: {ex.Message}");

                // Hata durumunda kullanıcıya bir mesaj gösterilebilir
                ModelState.AddModelError("", "Oda kaydı sırasında bir hata oluştu.");

                // DormId için gerekli verileri tekrar yükle ve formu geri döndür
                ViewData["RoomId"] = new SelectList(_context.DormLists, "Id", "Name", roomList.DormId);
                return View(roomList);
            }
        }


        // GET: RoomLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomLists == null)
            {
                return NotFound();
            }

            var roomList = await _context.RoomLists.FindAsync(id);
            if (roomList == null)
            {
                return NotFound();
            }
            ViewData["DormId"] = new SelectList(_context.DormLists, "Id", "Id", roomList.DormId);
            return View(roomList);
        }

        // POST: RoomLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Floor,Capacity,CurrentOccupancy,OccupancyRate,DormId")] RoomList roomList)
        {
            if (id != roomList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomListExists(roomList.Id))
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
            ViewData["DormId"] = new SelectList(_context.DormLists, "Id", "Id", roomList.DormId);
            return View(roomList);
        }

        // GET: RoomLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomLists == null)
            {
                return NotFound();
            }

            var roomList = await _context.RoomLists
                .Include(r => r.DormList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomList == null)
            {
                return NotFound();
            }

            return View(roomList);
        }

        // POST: RoomLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomLists == null)
            {
                return Problem("Entity set 'YurtSistemiContext.RoomLists'  is null.");
            }
            var roomList = await _context.RoomLists.FindAsync(id);
            if (roomList != null)
            {
                _context.RoomLists.Remove(roomList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomListExists(int id)
        {
          return (_context.RoomLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
