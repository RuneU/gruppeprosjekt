using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
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

        public int GetLastCustomerID()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();

            string sqlQuery = "SELECT CustomerID FROM Customer ORDER BY CustomerID DESC LIMIT 1";
            int lastCustomerID = dbConnection.Query<int>(sqlQuery).FirstOrDefault();
            return lastCustomerID;
        }

        public ServiceOrder GetServiceOrderByID(int serviceOrderId)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            string query = "SELECT * FROM ServiceOrder WHERE ServiceOrderID = @ServiceOrderID";
            return dbConnection.Query<ServiceOrder>(query, new { ServiceOrderID = serviceOrderId }).FirstOrDefault();
        }

        public ServiceOrder GetServiceOrderByCustomerID(int customerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = @"
                SELECT * 
                FROM ServiceOrder 
                WHERE CustomerID = @CustomerID";
                return dbConnection.Query<ServiceOrder>(query, new { CustomerID = customerId }).FirstOrDefault();
            }
        }

        public Customer GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Customer>("SELECT * FROM ServiceOrder WHERE ServiceOrderID = @ServiceOrderID", new { ServiceOrderID = id }).FirstOrDefault();

        }

        public void Insert(ServiceOrder serviceOrder)
        {
            int lastCustomerID = GetLastCustomerID();
            serviceOrder.CustomerID = lastCustomerID;

            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            string insertQuery = @"
            INSERT INTO ServiceOrder 
            (CustomerID, CreatedBy, DateReceived, ModelYear, ProductType, 
            SerialNumber, ServiceType, WhatIsAgreedWithCustomer, RepairDescription, 
            IncludedParts, DateCompleted, WorkingHours, ReplacedPartsReturned, 
            ShippingMethod, Status, Subject, BookedServiceToWeek, AgreedDeliveryDateWithCustomer) 
            VALUES 
            (@CustomerID, @CreatedBy, @DateReceived, @ModelYear, @ProductType, 
            @SerialNumber, @ServiceType, @WhatIsAgreedWithCustomer, @RepairDescription, 
            @IncludedParts, @DateCompleted, @WorkingHours, @ReplacedPartsReturned, 
            @ShippingMethod, @Status, @Subject, @BookedServiceToWeek, @AgreedDeliveryDateWithCustomer)";

            dbConnection.Execute(insertQuery, serviceOrder);
        }

        public bool Update(ServiceOrder serviceOrder)
        {
           
        using (IDbConnection dbConnection = Connection)
        {
           dbConnection.Open();
           var affectedRows = dbConnection.Execute(@"
            UPDATE ServiceOrder 
            SET CustomerID = @CustomerID, 
                CreatedBy = @CreatedBy, 
                DateReceived = @DateReceived, 
                ModelYear = @ModelYear, 
                ProductType = @ProductType, 
                SerialNumber = @SerialNumber, 
                ServiceType = @ServiceType, 
                WhatIsAgreedWithCustomer = @WhatIsAgreedWithCustomer, 
                RepairDescription = @RepairDescription, 
                IncludedParts = @IncludedParts, 
                DateCompleted = @DateCompleted, 
                WorkingHours = @WorkingHours, 
                ReplacedPartsReturned = @ReplacedPartsReturned, 
                ShippingMethod = @ShippingMethod, 
                Status = @Status, 
                Subject = @Subject, 
                BookedServiceToWeek = @BookedServiceToWeek, 
                AgreedDeliveryDateWithCustomer = @AgreedDeliveryDateWithCustomer
            WHERE ServiceOrderID = @ServiceOrderID", serviceOrder);

                return affectedRows > 0;
               }

            }
            


        }

    }
