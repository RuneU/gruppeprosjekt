using System.Collections.Generic;
namespace bacit_dotnet.MVC.Models
{
    public class RazorViewModel
    {
        public string? Navns { get; set; }
        public string? Emails { get; set; }
        public string Content { get; internal set; }
    }

    public class Kunder
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    namespace bacit_dotnet.MVC.Models

    {
          public class RazorViewModel
        {
            public required List<Kunder> Kunder { get; set;}
        }
    }

}
