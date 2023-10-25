using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.WorkOrder;

public class WorkOrderViewModel
{

    [Required(ErrorMessage = "Postnummer er n�dvendig")]
    [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Ugyldig uketall. M� v�re 1 eller 2 sifere.")]
    public string BookedService { get; set; }
    public string InquiryRegRec { get; set; }
    public string CaseDone { get; set; }
    public string ReceivedDate { get; set; }
    public string ScheduledDelivery { get; set; }
    public string ModellYear { get; set; }

    [Required(ErrorMessage = "Produkt type er n�dvendig")]
    [StringLength(30, ErrorMessage = "Produkt type kan ikke v�re mer enn 30 karakterer")]
    [RegularExpression(@"^[a-�A-�''-'\s]{1,40}$", ErrorMessage = "Ugyldig karakter.")]
    public string ProductType { get; set; }
    public string RecievedDelivery { get; set; }
    public string ServiceDone { get; set; }


    [Required(ErrorMessage = "Arbeidstimer er n�dvendig")]
    [RegularExpression(@"^\d{1,3}$", ErrorMessage = "ugyldig Postnummer. M� v�re 1,2 eller 3 sifere.")]
    public string HoursService { get; set; }

    [Required(ErrorMessage = "Reperasjonsbeskrivelse er n�dvendig")]
    [RegularExpression(@"^[a-�A-�''-'\s]{1,300}$", ErrorMessage = "Ugyldig karakterer.")]
    public string OrderDescriptionFromCustomer { get; set; }

    [Required(ErrorMessage = "Kunde beskrivelse er n�dvendig")]
    [RegularExpression(@"^[a-�A-�''-'\s]{1,300}$", ErrorMessage = "Ugyldig karakterer.")]
    public string CustomerInfo { get; set; }

    
    public string OrderNumber { get; set; }
    public string ServiceForm { get; set; }
}