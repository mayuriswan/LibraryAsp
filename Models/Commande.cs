using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrairieDTICRosemont.Models
{
    public class Commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommandeId { get; set; }

        // Informations sur la commande
        public DateTime? DateCommande { get; set; }
        public decimal? MontantTotal { get; set; }
        public string? Statut { get; set; } // En cours, Expédiée, Livrée, etc.

        // Informations de livraison
        public string? NomDestinataire { get; set; }
        public string? AdresseLivraison { get; set; }
        public string? CodePostalLivraison { get; set; }
        public string? VilleLivraison { get; set; }
        public string? PaysLivraison { get; set; }

        // Informations de paiement
        public string? MethodePaiement { get; set; } // Carte de crédit, PayPal, etc.
        public string? NumeroTransaction { get; set; }

        // Relation avec le client
      //  public int? ClientId { get; set; }
     //   public Client? Client { get; set; }

        // Articles de la commande
        public List<LigneCommande>? Articles { get; set; } = new List<LigneCommande>();
    }

}
