using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required(ErrorMessage = "Le prénom est requis.")]
    public string Prenom { get; set; }

    [Required(ErrorMessage = "Le nom est requis.")]
    public string Nom { get; set; }

    [Required(ErrorMessage = "L'email est requis.")]
    [EmailAddress(ErrorMessage = "L'email n'est pas au format correct.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "L'adresse est requise.")]
    public string Adresse { get; set; }

    [Required(ErrorMessage = "Le code postal est requis.")]
    public string CodePostal { get; set; }

    [Required(ErrorMessage = "La ville est requise.")]
    public string Ville { get; set; }

    [Required(ErrorMessage = "Le pays est requis.")]
    public string Pays { get; set; }   

    public string? ReturnUrl { get; set; }

    public List<ExternalLoginInfo>? ExternalLogins { get; set; }
}
