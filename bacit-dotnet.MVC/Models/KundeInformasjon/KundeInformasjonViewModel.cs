using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.KundeInformasjon;

public class KundeInformasjonViewModel
{
    [Required(ErrorMessage = "Fornavn er nødvendig")]
    [StringLength(30, ErrorMessage = "Fornavn kan ikke være mer enn 30 characters")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,40}$", ErrorMessage = "Ugyldig characters i Fornavn.")]
    public string Fornavn { get; set; }

    [Required(ErrorMessage = "Etternavn er nødvendig")]
    [StringLength(30, ErrorMessage = "Etternavn kan ikke være mer enn 30 characters")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,40}$", ErrorMessage = "Ugyldig characters i Etternavn.")]
    public string Etternavn { get; set; }

    [Required(ErrorMessage = "Email er nødvendig")]
    [EmailAddress(ErrorMessage = "Ugyldig Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Adresse er nødvendig")]
    [StringLength(30, ErrorMessage = "Adresse kan ikke være mer enn 30 characters")]
    // If you want to be more specific about the characters allowed in Adresse, use a RegularExpression attribute
    public string Adresse { get; set; }

    [Required(ErrorMessage = "Postnummer is required")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid Postnummer. Must be 4 digits.")]
    public string Postnummer { get; set; }


}
