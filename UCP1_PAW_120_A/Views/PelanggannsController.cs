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
    public class PelanggannsController : Controller
    {
        private readonly TokoNusantaraContext _context;

        public PelanggannsController(TokoNusantaraContext context)
        {
            _context = context;
        }

        // GET: Pelangganns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pelangganns.ToListAsync());
        }

        // GET: Pelangganns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggann = await _context.Pelangganns
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (pelanggann == null)
            {
                return NotFound();
            }

            return View(pelanggann);
        }

        // GET: Pelangganns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelangganns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembeli,NamaPembeli,AlamatPembeli")] Pelanggann pelanggann)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelanggann);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelanggann);
        }

        // GET: Pelangganns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggann = await _context.Pelangganns.FindAsync(id);
            if (pelanggann == null)
            {
                return NotFound();
            }
            return View(pelanggann);
        }

        // POST: Pelangganns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPembeli,NamaPembeli,AlamatPembeli")] Pelanggann pelanggann)
        {
            if (id != pelanggann.IdPembeli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelanggann);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelanggannExists(pelanggann.IdPembeli))
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
            return View(pelanggann);
        }

        // GET: Pelangganns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggann = await _context.Pelangganns
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (pelanggann == null)
            {
                return NotFound();
            }

            return View(pelanggann);
        }

        // POST: Pelangganns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pelanggann = await _context.Pelangganns.FindAsync(id);
            _context.Pelangganns.Remove(pelanggann);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelanggannExists(string id)
        {
            return _context.Pelangganns.Any(e => e.IdPembeli == id);
        }
    }
}
