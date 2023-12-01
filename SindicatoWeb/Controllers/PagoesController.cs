using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SindicatoWeb.Contexto;
using SindicatoWeb.Models;

namespace SindicatoWeb.Controllers
{
    public class PagoesController : Controller
    {
        private readonly MiContext _context;

        public PagoesController(MiContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var miContext = _context.Pago.Include(p => p.Chofer).Include(p => p.Usuario);
            return View(await miContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.Chofer)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pago pago)
        {
            if (ModelState.IsValid)
            {
                pago.Numero = getNumero(); //crear metodo
                pago.Fecha = DateTime.Now;
                pago.UsuarioId = 1;//recuperar el usuario autenticado
                
                _context.Add(pago);
                await _context.SaveChangesAsync();

                TempData["PagoRegistrado"] = "Pago registrado correctamente";
                return RedirectToAction("Details", "Chofers", new { id = pago.ChoferId});
            }

            return RedirectToAction("Details", "Chofers", new { id = pago.ChoferId });
        }

        private int getNumero()
        {
            if (_context.Pago.ToList().Count > 0) {
                return _context.Pago.Max(x => x.Numero) + 1;
            }
            return 1;
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.Chofer)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pago == null)
            {
                return Problem("Entity set 'MiContext.Pago'  is null.");
            }
            var pago = await _context.Pago.FindAsync(id);

            if (pago != null)
            {
                _context.Pago.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Chofers", new { id = pago.ChoferId });
        }

        private bool PagoExists(int id)
        {
          return (_context.Pago?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
