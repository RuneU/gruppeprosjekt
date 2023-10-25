using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;

namespace bacit_dotnet.MVC.Models.Sjekkliste
{
    public class SjekklisteViewModel
    {
        [Required(ErrorMessage = "Dokument nummeret er nødvendig")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ugyldig nummer. Må våre 10 sifere.")]
        public string DokNr { get; set; }
        public string ServiceDato { get; set; }

        [Required(ErrorMessage = "Medgåtte deler er nødvendig")]
        [RegularExpression(@"^[a-åA-Å''-'\s]{1,30}$", ErrorMessage = "Ugyldig characters.")]
        public string GodkjentAv {  get; set; }


        public string lameller { get; set; }
        public string Bremser { get; set; }
        public string trommel { get; set; }
        public string PTO { get; set; }
        public string kjedestrammer { get; set; }
        public string wire {  get; set; }
        public string pinion { get; set; }
        public string kjedehjul {  get; set; }
        public string sylinder { get; set; }
        public string slanger { get; set; }
        public string hydraulikkblokk { get; set; }
        public string tank {  get; set; }
        public string boks { get; set; }
        public string ringsylinder { get; set; }
        public string tetninger { get; set; }
        public string ledningsnett { get; set; }
        public string radio {  get; set; }
        public string knappekasse { get; set; }
        public string trykksetninger { get; set; }
        public string funksjoner { get; set; }
        public string trekkraft { get; set; }
        public string bremsekraft { get; set; }

    }
}
