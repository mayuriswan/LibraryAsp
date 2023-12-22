using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrairieDTICRosemont.Models
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set;}
        public DbSet<Editeur> Editeurs { get;set; }

        public void SeedData()
        {
            // Obtenez la liste de blogs avec des données préremplies
            var SampleCategories = SampleDonnes.getCategories();
            // Créez un HashSet des URLs de blogs existants pour une recherche plus rapide
            var existingCategorieDesignation = new HashSet<string>(Categories.Select(c => c.Designation));
            foreach (var categorie in SampleCategories)
            {
                if (!existingCategorieDesignation.Contains(categorie.Designation))
                {
                    // Ajoutez le blog au contexte s'il n'existe pas déjà
                    Categories.Add(categorie);
                }
            }
            // Enregistrez les changements une seule fois après avoir ajouté tous les blogs
            SaveChanges();
        }
    }
}
