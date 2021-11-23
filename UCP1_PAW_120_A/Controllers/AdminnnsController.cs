using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_120_A.Models;

namespace UCP1_PAW_120_A.Controllers
{
    public class AdminnnsController : Controller
    {
        private readonly TokoNusantaraContext _context;

        public AdminnnsController(TokoNusantaraContext context)
        {
            _context = context;
        }

        // GET: Adminnns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adminnns.ToListAsync());
        }

        // GET: Adminnns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminnn = await _context.Adminnns
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminnn == null)
            {
                return NotFound();
            }

            return View(adminnn);
        }

        // GET: Adminnns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adminnns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,NamaAdmin,AlamatAdmin")] Adminnn adminnn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminnn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminnn);
        }

        // GET: Adminnns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminnn = await _context.Adminnns.FindAsync(id);
            if (adminnn == null)
            {
                return NotFound();
            }
            return View(adminnn);
        }

        // POST: Adminnns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAdmin,NamaAdmin,AlamatAdmin")] Adminnn adminnn)
        {
            if (id != adminnn.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminnn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminnnExists(adminnn.IdAdmin))
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
            return View(adminnn);
        }

        // GET: Adminnns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminnn = await _context.Adminnns
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminnn == null)
            {
                return NotFound();
            }

            return View(adminnn);
        }

        // POST: Adminnns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adminnn = await _context.Adminnns.FindAsync(id);
            _context.Adminnns.Remove(adminnn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminnnExists(string id)
        {
            return _context.Adminnns.Any(e => e.IdAdmin == id);
        }
    }
}
