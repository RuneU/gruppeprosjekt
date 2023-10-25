using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.KundeInformasjon;

public class KundeInformasjonViewModel
{
    [Required(ErrorMessage = "Fornavn er nødvendig")]
    [StringLength(30, ErrorMessage = "Fornavn kan ikke være mer enn 30 characters")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,30}$", ErrorMessage = "Ugyldig characters i Fornavn.")]
    public string Fornavn { get; set; }

    [Required(ErrorMessage = "Etternavn er nødvendig")]
    [StringLength(30, ErrorMessage = "Etternavn kan ikke være mer enn 30 characters")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,30}$", ErrorMessage = "Ugyldig characters i Etternavn.")]
    public string Etternavn { get; set; }

    [Required(ErrorMessage = "Email er nødvendig")]
    [EmailAddress(ErrorMessage = "Ugyldig Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Adresse er nødvendig")]
    [StringLength(30, ErrorMessage = "Adresse kan ikke være mer enn 20 characters")]
    [RegularExpression(@"^[a-åA-Å0-9''-'\s]{1,30}$", ErrorMessage = "Ugyldig characters i Etternavn.")]
    public string Adresse { get; set; }

    [Required(ErrorMessage = "Postnummer er nødvendig")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Ugyldig postnummer. Må være 4 sifere.")]
    public string Postnummer { get; set; }


}
