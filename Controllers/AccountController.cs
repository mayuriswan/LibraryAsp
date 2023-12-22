using LibrairieDTICRosemont.Models;
using LibrairieDTICRosemont.VIewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibrairieDTICRosemont.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Client> _userManager;
        private readonly SignInManager<Client> _signInManager;

        public AccountController(UserManager<Client> userManager, SignInManager<Client> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Action pour afficher le formulaire de connexion
        public IActionResult Login()
        {
            return View();
        }

        // Action pour gérer la soumission du formulaire de connexion
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Vérifiez les informations d'identification (c'est une simulation)
            if (username == "root" && password == "root")
            {
                // Créez une session pour l'utilisateur connecté
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // En cas d'échec de connexion, affichez un message d'erreur
                ViewBag.ErrorMessage = "Identifiants incorrects";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "root" && model.Email == "root")
                {
                    // Créez une session pour l'utilisateur connecté
                    HttpContext.Session.SetString("UserName", model.Email);
                    return RedirectToAction("Index", "Home");
                }
                var user = await _userManager.FindByEmailAsync(model.Email);

                // Utilisez SignInManager pour connecter l'utilisateur
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Redirigez vers la page d'accueil si la connexion réussit
                        HttpContext.Session.SetString("UserName", user.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                }
                // Si la connexion échoue, ajoutez un message d'erreur
                ModelState.AddModelError(string.Empty, "Identifiants incorrects");
            }

            // Si le modèle n'est pas valide ou si la connexion échoue, réaffichez le formulaire avec des erreurs
            return View();
        }

        // Action pour se déconnecter (logout)
        public async Task<IActionResult> Logout()
        {
            // Utilisez SignInManager pour déconnecter l'utilisateur
            await _signInManager.SignOutAsync();

            // Supprimez la session de l'utilisateur
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            // Initialiser le modèle d'inscription
            var model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the password and confirm password match
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Le mot de passe et la confirmation ne correspondent pas.");
                    return View(model);
                }

                // Create a new user with the information from the model
                var user = new Client
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Prenom = model.Prenom,
                    Nom = model.Nom,
                    Adresse = model.Adresse,
                    CodePostal = model.CodePostal,
                    Pays = model.Pays,
                    Ville = model.Ville,
                    
                    
                };


                // Use UserManager to create the user
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // You can add other actions here after successful user creation

                    // Sign in the user after account creation (customize as needed)
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to a confirmation or login page
                    return RedirectToAction("Login", "Account");
                }

                // If user creation fails, add errors to the model
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If the model is not valid or user creation fails, re-display the form with errors
            return View(model);
        }

    }
}
