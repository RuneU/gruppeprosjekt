using System;
using System.Collections.Generic;
using System.Data;
using bacit_dotnet.MVC.Models.KundeInformasjon;

namespace bacit_dotnet.MVC.Models.Home
{
    public class HomeIndexViewModel
    {
        public string Saksnummer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Emne { get; set; }
        public string Dato { get; set; }
        public string Status { get; set; }


        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}