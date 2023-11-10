using System;
using System.Collections.Generic;
using System.Data;
using bacit_dotnet.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class HomeViewModel
    {

        public required IEnumerable<Customer> Customers { get; set; }
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