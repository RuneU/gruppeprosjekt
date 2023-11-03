using Dapper;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace bacit_dotnet.MVC.Models

{
    public class ServiceOrderRepository
    {
        private readonly IConfiguration _config;

        public ServiceOrderRepository(IConfiguration config)
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

        public IEnumerable<ServiceOrder> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<ServiceOrder>("SELECT * FROM ServiceOrder");
        }

        public void Insert(ServiceOrder serviceOrder)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            dbConnection.Execute("INSERT INTO ServiceOrder (ServiceOrderID, CreatedBy, OrderNumber, DateReceived, ModelYear, WhatIsAgreedWithCustomer, RepairDescription, IncludedParts, DateCompleted, WorkingHours, ReplacedPartsReturned, ShippingMethod) VALUES (@ServiceOrderID, @CreatedBy, @OrderNumber, @DateReceived, @ModelYear, @WhatIsAgreedWithCustomer, @RepairDescription, @IncludedParts, @DateCompleted, @WorkingHours, @ReplacedPartsReturned, @ShippingMethod)", serviceOrder);
            //ProductType, SerialNumber, ServiceType er ikke tatt med pga feilsøking
        }
    }
}