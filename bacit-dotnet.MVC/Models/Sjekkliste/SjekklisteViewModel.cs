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
        public string Date { get; set; }

        [Required(ErrorMessage = "Medgåtte deler er nødvendig")]
        [RegularExpression(@"^[a-åA-Å''-'\s]{1,30}$", ErrorMessage = "Ugyldig characters.")]
        public string ApprovedBy {  get; set; }


        public string CheckClutch { get; set; }
        public string Bremser { get; set; }
        public string trommel { get; set; }
        public string CheckPto { get; set; }
        public string CheckChainTensioner { get; set; }
        public string CheckWire {  get; set; }
        public string CheckPinionStorage { get; set; }
        public string CheckSprocket {  get; set; }
        public string sylinder { get; set; }
        public string CheckHose { get; set; }
        public string CheckHydraulicBlock { get; set; }
        public string CheckOilTank {  get; set; }
        public string CheckOilBox { get; set; }
        public string CheckRingCylinder { get; set; }
        public string tetninger { get; set; }
        public string CheckWiring { get; set; }
        public string CheckRadio {  get; set; }
        public string CheckButtonBox { get; set; }
        public string trykksetninger { get; set; }
        public string CheckFunctions { get; set; }
        public string PullingPower { get; set; }
        public string BrakePower { get; set; }

    }
}
