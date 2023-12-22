using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrairieDTICRosemont.Models
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorieId { get; set; }
        [Required(ErrorMessage = "La catégorie du livre est obligatoire.")]

        public string Designation { get; set; }
        public virtual ICollection<Livre> livres { get; set; }
    }
}
