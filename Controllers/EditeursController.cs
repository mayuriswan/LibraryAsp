using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrairieDTICRosemont.Models;

namespace LibrairieDTICRosemont.Controllers
{
    public class EditeursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditeursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Editeurs
        public async Task<IActionResult> Index()
        {
              return _context.Editeurs != null ? 
                          View(await _context.Editeurs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Editeurs'  is null.");
        }

        // GET: Editeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Editeurs == null)
            {
                return NotFound();
            }

            var editeur = await _context.Editeurs
                .FirstOrDefaultAsync(m => m.EditeurId == id);
            if (editeur == null)
            {
                return NotFound();
            }

            return View(editeur);
        }

        // GET: Editeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EditeurId,Nom")] Editeur editeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editeur);
        }

        // GET: Editeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Editeurs == null)
            {
                return NotFound();
            }

            var editeur = await _context.Editeurs.FindAsync(id);
            if (editeur == null)
            {
                return NotFound();
            }
            return View(editeur);
        }

        // POST: Editeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EditeurId,Nom")] Editeur editeur)
        {
            if (id != editeur.EditeurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditeurExists(editeur.EditeurId))
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
            return View(editeur);
        }

        // GET: Editeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Editeurs == null)
            {
                return NotFound();
            }

            var editeur = await _context.Editeurs
                .FirstOrDefaultAsync(m => m.EditeurId == id);
            if (editeur == null)
            {
                return NotFound();
            }

            return View(editeur);
        }

        // POST: Editeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Editeurs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Editeurs'  is null.");
            }
            var editeur = await _context.Editeurs.FindAsync(id);
            if (editeur != null)
            {
                _context.Editeurs.Remove(editeur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditeurExists(int id)
        {
          return (_context.Editeurs?.Any(e => e.EditeurId == id)).GetValueOrDefault();
        }
    }
}
