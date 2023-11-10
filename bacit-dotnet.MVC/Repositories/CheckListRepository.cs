using System.Data;
using Dapper;
using MySqlConnector;
using System.Data;
using bacit_dotnet.MVC.Models.Sjekkliste;

namespace bacit_dotnet.MVC.Repositories
{
    public class CheckListRepository
    {
        private readonly IConfiguration _config;

        public CheckListRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<SjekklisteViewModel> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<SjekklisteViewModel>("SELECT * FROM CheckList");
        }

        public void Insert(SjekklisteViewModel sjekkliste)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            dbConnection.Execute("INSERT INTO CheckList (DokNr, Date, ApprovedBy, CheckClutch, WearBrakes, CheckDrums, CheckPto, CheckChainTensioner, CheckWire, CheckPinionBearing, CheckSprocket, CheckHydraulicSylinder, CheckHose, CheckHydraulicBlock, CheckOilTank, CheckOilBox, CheckRingCylinder, CheckBrakeCylinder, CheckWiring, CheckRadio, CheckButtonBox, PressureTest, CheckFunctions, PullingPower, BrakePower) VALUE ( @DokNr, @Date, @ApprovedBy, @CheckClutch, @WearBrakes, @CheckDrums, @CheckPto, @CheckChainTensioner, @CheckWire, @CheckPinionBearing, @CheckSprocket, @CheckHydraulicSylinder, @CheckHose, @CheckHydraulicBlock, @CheckOilTank, @CheckOilBox, @CheckRingCylinder, @CheckBrakeCylinder, @CheckWiring, @CheckRadio, @CheckButtonBox, @PressureTest, @CheckFunctions, @PullingPower, @BrakePower)", sjekkliste);
        }
    }
}
