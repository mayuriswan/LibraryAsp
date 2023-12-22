using LibrairieDTICRosemont.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;


namespace LibrairieDTICRosemont.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var listCategorie = SampleDonnes.getCategories();
            var listCategorie = _context.Categories.Include(categorie => categorie.livres).ToList();
            return View(listCategorie);
        }

        public IActionResult Details(int id)
        {

            //   Livre livre = SampleDonnes.Livres.FirstOrDefault(l => l.LivreId == id);
            Livre livre = _context.Livres.FirstOrDefault(l => l.LivreId == id);
            return View(livre);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Vous pouvez nous contacter via les informations ci-dessous ";

            return View();
        }
    }

}