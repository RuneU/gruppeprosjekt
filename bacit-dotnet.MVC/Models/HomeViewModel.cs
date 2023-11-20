using System;
using System.Collections.Generic;
using System.Data;
using bacit_dotnet.MVC.Models;
using System.ComponentModel.DataAnnotations;
using bacit_dotnet.MVC.Views.FormsMain;

namespace bacit_dotnet.MVC.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public IEnumerable<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerID { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

        public string DateReceived { get; set; }
    }
}