using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PraktikumUCP.Models;

namespace PraktikumUCP.Controllers
{
    public class PelayansController : Controller
    {
        private readonly UcpPraktikumContext _context;

        public PelayansController(UcpPraktikumContext context)
        {
            _context = context;
        }

        // GET: Pelayans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pelayan.ToListAsync());
        }

        // GET: Pelayans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelayan = await _context.Pelayan
                .FirstOrDefaultAsync(m => m.IdPelayan == id);
            if (pelayan == null)
            {
                return NotFound();
            }

            return View(pelayan);
        }

        // GET: Pelayans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelayans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelayan,NamaPelayan,NoTelpPelayan,AlamatPelayan")] Pelayan pelayan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelayan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelayan);
        }

        // GET: Pelayans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelayan = await _context.Pelayan.FindAsync(id);
            if (pelayan == null)
            {
                return NotFound();
            }
            return View(pelayan);
        }

        // POST: Pelayans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelayan,NamaPelayan,NoTelpPelayan,AlamatPelayan")] Pelayan pelayan)
        {
            if (id != pelayan.IdPelayan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelayan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelayanExists(pelayan.IdPelayan))
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
            return View(pelayan);
        }

        // GET: Pelayans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelayan = await _context.Pelayan
                .FirstOrDefaultAsync(m => m.IdPelayan == id);
            if (pelayan == null)
            {
                return NotFound();
            }

            return View(pelayan);
        }

        // POST: Pelayans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelayan = await _context.Pelayan.FindAsync(id);
            _context.Pelayan.Remove(pelayan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelayanExists(int id)
        {
            return _context.Pelayan.Any(e => e.IdPelayan == id);
        }
    }
}
