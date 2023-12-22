using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibrairieDTICRosemont.Models
{
    public class Livre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LivreId { get; set; }

        [Required(ErrorMessage = "Le numéro ISBN est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Display(Name = "ISBN")]
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "Le titre du livre est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Display(Name = "Titre du livre")]
        public string? Titre { get; set; }

        [Required(ErrorMessage = "Une description du livre est obligatoire.")]
        [AllowHtml]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Description du livre")]
        [MaxLength(6000, ErrorMessage = "La description ne doit pas dépasser 6000 caractères.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La quantité en stock est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure à zéro.")]
        [Display(Name = "Quantité en stock")]
        public int? Quantite { get; set; }

        [Required(ErrorMessage = "Le prix du livre est obligatoire.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        [Display(Name = "Prix du livre")]
        public decimal? Prix { get; set; }

        [Required(ErrorMessage = "Le nombre de pages est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de pages doit être supérieur à zéro.")]
        [Display(Name = "Nombre de pages")]
        public int? NbPage { get; set; }

        [Required(ErrorMessage = "La date de publication est obligatoire.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de publication")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateSortie { get; set; }
        [Required(ErrorMessage = "La photo est obligatoire.")]

        [Display(Name = "Photo")]
        public string? Photo { get; set; }

        public int AuteurId { get; set; }
        public virtual Auteur? Auteur { get; set; }

        public int EditeurId { get; set; }
        public virtual Editeur? Editeur { get; set; }

        public int CategorieId { get; set; }
        public virtual Categorie? Categorie { get; set; }
    }


}


