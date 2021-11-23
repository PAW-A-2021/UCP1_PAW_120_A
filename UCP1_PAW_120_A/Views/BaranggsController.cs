using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_120_A.Models;

namespace UCP1_PAW_120_A.Views
{
    public class BaranggsController : Controller
    {
        private readonly TokoNusantara _context;

        public BaranggsController(TokoNusantaraContext context)
        {
            _context = context;
        }

        // GET: Baranggs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baranggs.ToListAsync());
        }

        // GET: Baranggs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangg = await _context.Baranggs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barangg == null)
            {
                return NotFound();
            }

            return View(barangg);
        }

        // GET: Baranggs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baranggs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,NamaBarang,Harga,JenisBarang,UkuranBarang")] Barangg barangg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barangg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barangg);
        }

        // GET: Baranggs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangg = await _context.Baranggs.FindAsync(id);
            if (barangg == null)
            {
                return NotFound();
            }
            return View(barangg);
        }

        // POST: Baranggs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdBarang,NamaBarang,Harga,JenisBarang,UkuranBarang")] Barangg barangg)
        {
            if (id != barangg.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barangg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaranggExists(barangg.IdBarang))
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
            return View(barangg);
        }

        // GET: Baranggs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangg = await _context.Baranggs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barangg == null)
            {
                return NotFound();
            }

            return View(barangg);
        }

        // POST: Baranggs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var barangg = await _context.Baranggs.FindAsync(id);
            _context.Baranggs.Remove(barangg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaranggExists(string id)
        {
            return _context.Baranggs.Any(e => e.IdBarang == id);
        }
    }
}
