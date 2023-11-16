using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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

        public int GetLastCustomerID()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();

            string sqlQuery = "SELECT CustomerID FROM Customer ORDER BY CustomerID DESC LIMIT 1";
            int lastCustomerID = dbConnection.Query<int>(sqlQuery).FirstOrDefault();
            return lastCustomerID;
        }

        public SjekklisteViewModel GetCheckListByID(int checkListId)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            string query = "SELECT * FROM CheckList WHERE CheckListID = @CheckListID";
            return dbConnection.Query<SjekklisteViewModel>(query, new { CheckListID = checkListId }).FirstOrDefault();
        }

        public SjekklisteViewModel GetCheckListByCustomerID(int customerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = @"
                SELECT * 
                FROM CheckList
                WHERE CustomerID = @CustomerID";
                return dbConnection.Query<SjekklisteViewModel>(query, new { CustomerID = customerId }).FirstOrDefault();
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
            int lastCustomerID = GetLastCustomerID();
            sjekkliste.CustomerID = lastCustomerID;
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            dbConnection.Execute("INSERT INTO CheckList (CustomerID, DokNr, Date, ApprovedBy, CheckClutch, WearBrakes, CheckDrums, CheckPto, CheckChainTensioner, CheckWire, CheckPinionBearing, CheckSprocket, CheckHydraulicSylinder, CheckHose, CheckHydraulicBlock, CheckOilTank, CheckOilBox, CheckRingCylinder, CheckBrakeCylinder, CheckWiring, CheckRadio, CheckButtonBox, PressureTest, CheckFunctions, PullingPower, BrakePower) VALUE ( @CustomerID, @DokNr, @Date, @ApprovedBy, @CheckClutch, @WearBrakes, @CheckDrums, @CheckPto, @CheckChainTensioner, @CheckWire, @CheckPinionBearing, @CheckSprocket, @CheckHydraulicSylinder, @CheckHose, @CheckHydraulicBlock, @CheckOilTank, @CheckOilBox, @CheckRingCylinder, @CheckBrakeCylinder, @CheckWiring, @CheckRadio, @CheckButtonBox, @PressureTest, @CheckFunctions, @PullingPower, @BrakePower)", sjekkliste);
        }

        public bool Update(SjekklisteViewModel checkList)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(@"
            UPDATE CheckList
            SET CustomerID = @CustomerID,
                DokNr = @DokNr,
                Date = @Date,
                ApprovedBy = @ApprovedBy,
                CheckClutch = @CheckClutch,
                WearBrakes = @WearBrakes,
                CheckDrums = @CheckDrums,
                CheckPto = @CheckPto,
                CheckChainTensioner = @CheckChainTensioner,
                CheckWire = @CheckWire,
                CheckPinionBearing = @CheckPinionBearing,
                CheckSprocket = @CheckSprocket,
                CheckHydraulicSylinder = @CheckHydraulicSylinder,
                CheckHose = @CheckHose,
                CheckHydraulicBlock = @CheckHydraulicBlock,
                CheckOilTank = @CheckOilTank,
                CheckOilBox = @CheckOilBox,
                CheckRingCylinder = @CheckRingCylinder,
                CheckBrakeCylinder = @CheckBrakeCylinder,
                CheckWiring = @CheckWiring,
                CheckRadio = @CheckRadio,
                CheckButtonBox = @CheckButtonBox,
                PressureTest = @PressureTest,
                CheckFunctions = @CheckFunctions,
                PullingPower = @PullingPower,
                BrakePower = @BrakePower
            WHERE CheckListID = @CheckListID", checkList);

                return affectedRows > 0;
            }
        }
    }
}
