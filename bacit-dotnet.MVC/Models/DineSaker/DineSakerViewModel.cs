using System;
using System.Collections.Generic;
using System.Data;
using bacit_dotnet.MVC.Models.KundeInformasjon;

namespace bacit_dotnet.MVC.Models.DineSaker
{ 

    public class DineSakerViewModel
    {

        public string Saksnummer { get; set; }
        public string Navn { get; set; }
        public string Emne { get; set; }
        public string Dato { get; set; }
        public string Status { get; set; }

    }
    
}
