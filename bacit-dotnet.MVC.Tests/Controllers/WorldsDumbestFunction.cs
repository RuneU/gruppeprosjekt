namespace bacit_dotnet.MVC.Tests.Controllers;

public class WorldsDumbestFunction
{
    public string ReturnPickachuIfZero(int num)
    {
        if (num == 0)
        {
            return "PICKACHU";
        }
        else
        {
            return "SQUIRTLE";
        }
    }
}