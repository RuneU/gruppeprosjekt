﻿using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public int ServiceOrderID { get; set; }

        public int CheckListID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Adress is required.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string PhoneNumber { get; set; }


        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}