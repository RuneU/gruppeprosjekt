using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "OrderNumber is required.")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "DateReceived is required.")]
        public DateTime DateReceived { get; set; }

        [Required(ErrorMessage = "ModelYear is required.")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "ProductType is required.")]
         public string ProductType { get; set; }

        [Required(ErrorMessage = "SerialNumber is required.")]
         public string SerialNumber { get; set; }

        [Required(ErrorMessage = "ServiceType is required.")]
         public string ServiceType { get; set; }

        [Required(ErrorMessage = "WhatIsAgreedWithCustomer  is required.")]
        public string WhatIsAgreedWithCustomer { get; set; }

        [Required(ErrorMessage = "RepairDescription is required.")]
        public string RepairDescription { get; set; }

        [Required(ErrorMessage = "IncludedParts is required.")]
        public string IncludedParts { get; set; }

        [Required(ErrorMessage = "DateCompleted is required.")]
        public DateTime DateCompleted { get; set; }

        [Required(ErrorMessage = "WorkingHours is required.")]
        public string WorkingHours { get; set; }

        [Required(ErrorMessage = "ReplacedPartsReturned is required.")]
        public string ReplacedPartsReturned { get; set; }

        [Required(ErrorMessage = "ShippingMethod is required.")]
        public string ShippingMethod { get; set; }

        



    }
}