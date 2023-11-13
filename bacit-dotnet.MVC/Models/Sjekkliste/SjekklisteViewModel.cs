using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;

namespace bacit_dotnet.MVC.Models.Sjekkliste
{
    public class SjekklisteViewModel
    {
        
        public int CustomerID { get; set; }
        public string DokNr { get; set; }
        public string Date { get; set; }

        
        
        public string ApprovedBy {  get; set; }


        public string CheckClutch { get; set; }
        public string WearBrakes { get; set; }
        public string CheckDrums { get; set; }
        public string CheckPto { get; set; }
        public string CheckChainTensioner { get; set; }
        public string CheckWire {  get; set; }
        public string CheckPinionBearing { get; set; }
        public string CheckSprocket {  get; set; }
        public string CheckHydraulicSylinder { get; set; }
        public string CheckHose { get; set; }
        public string CheckHydraulicBlock { get; set; }
        public string CheckOilTank {  get; set; }
        public string CheckOilBox { get; set; }
        public string CheckRingCylinder { get; set; }
        public string CheckBrakeCylinder { get; set; }
        public string CheckWiring { get; set; }
        public string CheckRadio {  get; set; }
        public string CheckButtonBox { get; set; }
        public string PressureTest { get; set; }
        public string CheckFunctions { get; set; }
        public string PullingPower { get; set; }
        public string BrakePower { get; set; }

    }
}
