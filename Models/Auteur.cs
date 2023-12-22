using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrairieDTICRosemont.Models
{
    public class Auteur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuteurId { get; set; }
        [Required(ErrorMessage = "Le nom de l'auteur est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Nom de l'auteur ")]
        public string? Nom { get; set; }
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Prénom de l'auteur ")]
        public string? Prenom { get; set; }
    
    
        public virtual ICollection<Livre>? Livres { get; set; }
    }
}
