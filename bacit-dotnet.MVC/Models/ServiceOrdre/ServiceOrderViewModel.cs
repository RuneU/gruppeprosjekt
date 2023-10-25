using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.ServiceOrdre;

public class ServiceOrderViewModel
{
    public string Mechanic { get; set; }
    public decimal ConsumedHours { get; set; }

    [Required(ErrorMessage = "Opprettet av er nødvendig")]
    [StringLength(30, ErrorMessage = "Opprettet av kan ikke være mer enn 30 karakterer")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,40}$", ErrorMessage = "Ugyldig karakter.")]
    public string OpprettetAv { get; set; }

    [Required(ErrorMessage = "OrdreNummer er nødvendig")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Ugyldig Ordre nummer. Må våre 10 sifere.")]
    public int Ordrenummer { get; set; }

    public string MottaDato { get; set; }

    public int AArsmodell { get; set; }

    [Required(ErrorMessage = "Reperasjonsbeskrivelse er nødvendig")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,300}$", ErrorMessage = "Ugyldig karakterer.")]
    public string Reperasjonsbeskrivelse { get; set; }

    [Required(ErrorMessage = "Reperasjonsbeskrivelse er nødvendig")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,300}$", ErrorMessage = "Ugyldig karakterer.")]
    public string hvaErAvtaltMedKunde { get; set; }

    [Required(ErrorMessage = "Medgåtte deler er nødvendig")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,300}$", ErrorMessage = "Ugyldig karakterer.")]
    public string MedgåtteDeler { get; set; }

    [Required(ErrorMessage = "Arbeidstimer er nødvendig")]
    [RegularExpression(@"^\d{1,3}$", ErrorMessage = "ugyldig Postnummer. Må være 1,2 eller 3 sifere.")]
    public int Arbeidstimer { get; set; }

    public string FerdigstiltDato { get; set; }

    [Required(ErrorMessage = "Utskrift deler returnert er nødvendig")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,50}$", ErrorMessage = "Ugyldig karakterer.")]
    public string UtskriftDelerRetunert { get; set; }

    [Required(ErrorMessage = "Forsendelsemåte er nødvendig")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,50}$", ErrorMessage = "Ugyldig karakterer.")]
    public string Forsendelsemåte { get; set; }

    [Required(ErrorMessage = "Signatur av kunde er nødvendig, skriv inn navnet til kunden")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,50}$", ErrorMessage = "Ugyldig karakterer.")]
    public string SignaturKunde { get; set; }

    [Required(ErrorMessage = "Signatur er nødvendig, skriv inn hvem som har gjort servicen")]
    [RegularExpression(@"^[a-åA-Å''-'\s]{1,50}$", ErrorMessage = "Ugyldig karakterer.")]
    public string SignaturReperatoer { get; set; }
    
    
    
    
    
}