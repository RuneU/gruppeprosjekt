namespace bacit_dotnet.MVC.Models.ServiceOrdre;

public class ServiceOrderViewModel
{
    public string Mechanic { get; set; }
    public decimal ConsumedHours { get; set; }
    public string OpprettetAv { get; set; }
    public  int Ordrenummer { get; set; }

    public string MottaDato { get; set; }
    public int AArsmodell { get; set; }
    public string hvaErAvtaltMedKunde { get; set; }
    public string Reperasjonsbeskrivelse { get; set; }
    public string MedgåtteDeler { get; set; }
    public int Arbeidstimer { get; set; }
    public string FerdigstiltDato { get; set; }
    public string UtskriftDelerRetunert { get; set; }
    public string Forsendelsemåte { get; set; }
    public string SignaturKunde { get; set; }
    public string SignaturReperatoer { get; set; }
    
    
    
    
    
}