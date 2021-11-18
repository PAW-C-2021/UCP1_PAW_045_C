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
    public class PembayaransController : Controller
    {
        private readonly UcpPraktikumContext _context;

        public PembayaransController(UcpPraktikumContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
            var ucpPraktikumContext = _context.Pembayaran.Include(p => p.IdPelayanNavigation).Include(p => p.IdTransaksiNavigation);
            return View(await ucpPraktikumContext.ToListAsync());
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdPelayanNavigation)
                .Include(p => p.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            ViewData["IdPelayan"] = new SelectList(_context.Pelayan, "IdPelayan", "IdPelayan");
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksi, "IdTransaksi", "IdTransaksi");
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembayaran,IdPelayan,IdTransaksi,TotalPembayaran")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelayan"] = new SelectList(_context.Pelayan, "IdPelayan", "IdPelayan", pembayaran.IdPelayan);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksi, "IdTransaksi", "IdTransaksi", pembayaran.IdTransaksi);
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            ViewData["IdPelayan"] = new SelectList(_context.Pelayan, "IdPelayan", "IdPelayan", pembayaran.IdPelayan);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksi, "IdTransaksi", "IdTransaksi", pembayaran.IdTransaksi);
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembayaran,IdPelayan,IdTransaksi,TotalPembayaran")] Pembayaran pembayaran)
        {
            if (id != pembayaran.IdPembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.IdPembayaran))
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
            ViewData["IdPelayan"] = new SelectList(_context.Pelayan, "IdPelayan", "IdPelayan", pembayaran.IdPelayan);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksi, "IdTransaksi", "IdTransaksi", pembayaran.IdTransaksi);
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdPelayanNavigation)
                .Include(p => p.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembayaran = await _context.Pembayaran.FindAsync(id);
            _context.Pembayaran.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
            return _context.Pembayaran.Any(e => e.IdPembayaran == id);
        }
    }
}
