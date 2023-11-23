using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }

        public int CustomerID { get; set; }

        
        public string CreatedBy { get; set; }

        
        public DateTime DateReceived { get; set; }

       
        public string ModelYear { get; set; }

        
         public string ProductType { get; set; }

      
         public string SerialNumber { get; set; }

        
         public string ServiceType { get; set; }

        
        public string WhatIsAgreedWithCustomer { get; set; }

        
        public string RepairDescription { get; set; }

        
        public string IncludedParts { get; set; }

        
        public DateTime DateCompleted { get; set; }

        
        public int WorkingHours { get; set; }

        
        public string ReplacedPartsReturned { get; set; }

        public string ShippingMethod { get; set; }

        public string Status { get; set; }
        
        public string Subject { get; set; }

        
        public string BookedServiceToWeek { get; set; }

       
        public DateTime AgreedDeliveryDateWithCustomer { get; set; }
    }
}