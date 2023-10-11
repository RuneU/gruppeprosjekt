using System;
using System.Collections.Generic;
using bacit_dotnet.MVC.Models.KundeInformasjon;

namespace YourNamespace.Models
{
    public class HomeIndexViewModel
    {
        public KundeInformasjonViewModel KundeInfo { get; set; }
        public required IEnumerable<KunderViewModel> Kunder { get; set; }
    }

    public class KunderViewModel
    {
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
    }
}