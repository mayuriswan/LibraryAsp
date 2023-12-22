using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrairieDTICRosemont.Models
{
    public class Editeur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EditeurId { get; set; }
        [Required(ErrorMessage = "Le nom de l'editeur est obligatoire.")]
        [StringLength(200)]
        [Display(Name = "Nom de l'éditeur ")]
        public string? Nom { get; set; }
        public virtual ICollection<Livre>? Livres { get; set; }

    }
}
