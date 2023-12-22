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
    public class LivresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action pour afficher la liste de tous les livres avec leurs détails (Auteur, Categorie, Editeur)
        public async Task<IActionResult> Index()
        {
            // Récupère la liste des livres depuis la base de données en incluant les entités liées (Auteur, Categorie, Editeur)
            // Include est utilisé pour charger les entités liées (Auteur, Categorie, Editeur) avec l'entité principale (Livre) lors de la récupération des données.
            var applicationDbContext = _context.Livres.Include(l => l.Auteur).Include(l => l.Categorie).Include(l => l.Editeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // Action pour afficher les détails d'un livre spécifique
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            // Récupère les détails d'un livre spécifique, y compris les informations des entités liées (Auteur, Categorie, Editeur)
            var livre = await _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.Categorie)
                .Include(l => l.Editeur)
                .FirstOrDefaultAsync(m => m.LivreId == id);

            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // Action pour afficher le formulaire de création d'un nouveau livre
        public IActionResult Create()
        {
            // Charge les options pour les listes déroulantes (Auteur, Categorie, Editeur)
            ViewData["AuteurId"] = new SelectList(_context.Auteurs, "AuteurId", "Nom");
            ViewData["CategorieId"] = new SelectList(_context.Categories, "CategorieId", "Designation");
            ViewData["EditeurId"] = new SelectList(_context.Editeurs, "EditeurId", "Nom");
            return View();
        }

        // Action pour traiter la soumission du formulaire de création d'un nouveau livre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivreId,ISBN,Titre,Description,Quantite,Prix,NbPage,DateSortie,Photo,AuteurId,EditeurId,CategorieId")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                // Ajoute le nouveau livre à la base de données
                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Charge les options pour les listes déroulantes en cas d'erreur de validation
            ViewData["AuteurId"] = new SelectList(_context.Auteurs, "AuteurId", "Nom", livre.AuteurId);
            ViewData["CategorieId"] = new SelectList(_context.Categories, "CategorieId", "Designation", livre.CategorieId);
            ViewData["EditeurId"] = new SelectList(_context.Editeurs, "EditeurId", "Nom", livre.EditeurId);
            return View(livre);
        }

        // Action pour afficher le formulaire de modification d'un livre existant
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            // Récupère le livre à modifier depuis la base de données
            var livre = await _context.Livres.FindAsync(id);

            if (livre == null)
            {
                return NotFound();
            }

            // Charge les options pour les listes déroulantes (Auteur, Categorie, Editeur)
            ViewData["AuteurId"] = new SelectList(_context.Auteurs, "AuteurId", "Nom", livre.AuteurId);
            ViewData["CategorieId"] = new SelectList(_context.Categories, "CategorieId", "Designation", livre.CategorieId);
            ViewData["EditeurId"] = new SelectList(_context.Editeurs, "EditeurId", "Nom", livre.EditeurId);
            return View(livre);
        }

        // Action pour traiter la soumission du formulaire de modification d'un livre existant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivreId,ISBN,Titre,Description,Quantite,Prix,NbPage,DateSortie,Photo,AuteurId,EditeurId,CategorieId")] Livre livre)
        {
            if (id != livre.LivreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Met à jour les informations du livre dans la base de données
                    _context.Update(livre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.LivreId))
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

            // Charge les options pour les listes déroulantes en cas d'erreur de validation
            ViewData["AuteurId"] = new SelectList(_context.Auteurs, "AuteurId", "Nom", livre.AuteurId);
            ViewData["CategorieId"] = new SelectList(_context.Categories, "CategorieId", "Designation", livre.CategorieId);
            ViewData["EditeurId"] = new SelectList(_context.Editeurs, "EditeurId", "Nom", livre.EditeurId);
            return View(livre);
        }

        // Action pour afficher le formulaire de suppression d'un livre
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            // Récupère les détails d'un livre spécifique à supprimer, y compris les informations des entités liées (Auteur, Categorie, Editeur)
            var livre = await _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.Categorie)
                .Include(l => l.Editeur)
                .FirstOrDefaultAsync(m => m.LivreId == id);

            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // Action pour traiter la soumission du formulaire de suppression d'un livre
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Livres' is null.");
            }

            var livre = await _context.Livres.FindAsync(id);
            if (livre != null)
            {
                _context.Livres.Remove(livre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Vérifie si un livre existe en fonction de son ID
        private bool LivreExists(int id)
        {
            return (_context.Livres?.Any(e => e.LivreId == id)).GetValueOrDefault();
        }

        // Action pour récupérer la liste de livres associés à une catégorie spécifique
        public async Task<ActionResult> GetLivresByCategorie(int id)
        {
            // Récupère la liste des catégories depuis la base de données (peut être une erreur, devrait probablement récupérer les livres par catégorie)
            var liste = await _context.Categories.ToListAsync();
            return View("LivresByCat", liste);
        }

        // Action pour rechercher des livres par catégorie
        public async Task<ActionResult> Search2(int id)
        {
            // Récupère la liste des livres appartenant à une catégorie spécifique
            var liste = await _context.Livres.Where(p => p.CategorieId == id).ToListAsync();
            return View("LivresBySearch", liste);
        }

        // Action pour rechercher des livres par nom de livre ou de catégorie
        [HttpPost]
        public async Task<ActionResult> Search(string searchName)
        {
            // Recherche des livres en fonction du nom du livre ou de la catégorie
            var result = await _context.Livres.Where(p => p.Titre.Contains(searchName) || p.Categorie.Designation.Contains(searchName)).ToListAsync();
            return View("LivresBySearch", result);
        }
    }

}
