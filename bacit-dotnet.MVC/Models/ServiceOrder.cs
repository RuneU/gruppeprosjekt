using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public DateTime DateReceived { get; set; }

        [Required(ErrorMessage = "Adress is required.")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string WhatIsAgreedWithCustomer { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string RepairDescription { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string IncludedParts { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public DateTime DateCompleted { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string WorkingHours { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string ReplacedPartsReturned { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string ShippingMethod { get; set; }

        



    }
}