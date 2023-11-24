namespace bacit_dotnet.MVC.Tests.Controllers;

public static class WorldsDumbestFunctionTest
{
    public static void WorldsDumbestFunction_ReturnsPickachuIfZero_Return_String()
    {
        try
        {
            //Arrange - henter variabler, klasser (hva vi skal teste)
            int num = 0;
            WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();
            
            //Act - kjører testen
            string result = worldsDumbest.ReturnPickachuIfZero(num);
            
            //Assert - de du vil testen skal returnere
            if (result == "PICKACHU")
            {
                Console.WriteLine("PASSED !");
            }
            else
            {
                Console.WriteLine("Failed !");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}