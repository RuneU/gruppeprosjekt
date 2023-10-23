namespace bacit_dotnet.MVC.Models.CreateUser;

public class CreateUserViewModel
{
    public string Fornavn { get; set; }
    public string Etternavn { get; set; }
    public string Email { get; set; }
    public int AnsattNr { get; set; }
    public string Rolle { get; set; }
    public string TelefonNr { get; set; }
    public string Passord { get; set; }
    public string BekreftPassord { get; set; }
    public string Adresse { get; set; }
    public string Postnummer { get; set; }
}