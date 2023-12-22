using LibrairieDTICRosemont.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace LibrairieDTICRosemont.Controllers
{
    public class PaniersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(int id, int qte)
        {
     
            var cart = HttpContext.Session.GetString("Cart");
            List<Panier> cartItems = cart != null
                ? JsonConvert.DeserializeObject<List<Panier>>(cart)
                : new List<Panier>();


          var  Livre = _context.Livres.Where(p => p.LivreId == id).FirstOrDefault();
            if (Livre != null)
            {
                Panier panier = new Panier() { Livre = Livre,
                    DateCreation = DateTime.Now,
                    Quantite=qte
                };
                cartItems.Add(panier) ;
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
            }

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var cart = HttpContext.Session.GetString("Cart");
            if (cart != null)
            {
                List<Panier> cartItems = JsonConvert.DeserializeObject<List<Panier>>(cart);
           
                int lastIndice = cartItems.Count();
                Console.WriteLine("lastIndice : " + lastIndice);
                if (id > lastIndice && id!=1)
                {
                    id = lastIndice-1;
                }
                if (id == 1)
                {
                    cartItems.RemoveAt(0);
                }
                Console.WriteLine("id : " + id);
                cartItems.RemoveAt(id);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var qte = 1;
            var cart = HttpContext.Session.GetString("Cart");
            List<Panier> cartItems = JsonConvert.DeserializeObject<List<Panier>>(cart);
          
            cartItems.Where(p => p.Livre.LivreId == id).FirstOrDefault().Quantite = qte;

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
            return View("Index");
        }
    }
}
