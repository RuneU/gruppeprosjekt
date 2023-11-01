using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}