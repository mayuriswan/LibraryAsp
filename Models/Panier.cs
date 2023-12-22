using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrairieDTICRosemont.Models
{
    public class Panier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PanierId { get; set; }
        public Livre Livre { get; set; }
        [Required(ErrorMessage = "La quantité est obligatoire.")]
        public int Quantite { get; set; }
        public DateTime DateCreation { get; set; }

        // Relation avec la commande
        public int? CommandeId { get; set; }
        public Commande Commande { get; set; }
    }
}
