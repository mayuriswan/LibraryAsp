using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrairieDTICRosemont.Models
{
    public class LigneCommande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LigneCommandeId { get; set; }

        // Informations sur l'article dans la commande
        public int? LivreId { get; set; }
        public Livre? Livre { get; set; }
        public int? Quantite { get; set; }

        // Relation avec la commande
        public int? CommandeId { get; set; }
        public Commande? Commande { get; set; }
    }
}
