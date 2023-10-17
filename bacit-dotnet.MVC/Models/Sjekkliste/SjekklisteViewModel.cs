using System.Data;
using System.Numerics;

namespace bacit_dotnet.MVC.Models.Sjekkliste
{
    public class SjekklisteViewModel
    {
        public string DokNr { get; set; }
        public DataSetDateTime Dato { get; set; }
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
