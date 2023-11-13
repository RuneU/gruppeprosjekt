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
    }
}