using Microsoft.AspNetCore.Identity;

namespace LibrairieDTICRosemont.Models
{

    public class Client : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? NumeroCarteCredit { get; set; }
        public DateTime? DateExpirationCarte { get; set; }
        public string? NomCarteCredit { get; set; }
        public string? CodeSecuriteCarte { get; set; }
        // Add any additional properties as needed
        public string? ClientId { get; set; }
    }

}
