﻿using Dapper;
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
             dbConnection.Execute("INSERT INTO ServiceOrder (ServiceOrderID, CustomerID, CreatedBy, DateReceived, ModelYear, ProductType, SerialNumber, ServiceType, WhatIsAgreedWithCustomer, RepairDescription, IncludedParts, DateCompleted, WorkingHours, ReplacedPartsReturned, ShippingMethod, Status, Subject, BookedServiceToWeek, AgreedDeliveryDateWithCustomer) VALUES (@ServiceOrderID, @CustomerID, @CreatedBy, @DateReceived, @ModelYear, @ProductType, @SerialNumber, @ServiceType, @WhatIsAgreedWithCustomer, @RepairDescription, @IncludedParts, @DateCompleted, @WorkingHours, @ReplacedPartsReturned, @ShippingMethod, @Status, @Subject, @BookedServiceToWeek, @AgreedDeliveryDateWithCustomer)", serviceOrder);

         }*/
       /* public void Insert(ServiceOrder serviceOrder)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        // Sjekk om CustomerID eksisterer i Customer-tabellen
                        var customer = dbConnection.QueryFirstOrDefault<Customer>("SELECT * FROM Customer WHERE CustomerID = @CustomerID", new { serviceOrder.CustomerID });

                        // Hvis CustomerID ikke eksisterer, kan du kaste en feil eller behandle den på en annen måte
                        if (customer == null)
                        {
                            throw new Exception("Ugyldig CustomerID. Kunden eksisterer ikke.");
                        }

                        // Legg til rad i ServiceOrder-tabellen
                        dbConnection.Execute("INSERT INTO ServiceOrder (CustomerID, CreatedBy, DateReceived, ModelYear, ProductType, SerialNumber, ServiceType, WhatIsAgreedWithCustomer, RepairDescription, IncludedParts, DateCompleted, WorkingHours, ReplacedPartsReturned, ShippingMethod, Status, Subject, BookedServiceToWeek, AgreedDeliveryDateWithCustomer) VALUES (@CustomerID, @CreatedBy, @DateReceived, @ModelYear, @ProductType, @SerialNumber, @ServiceType, @WhatIsAgreedWithCustomer, @RepairDescription, @IncludedParts, @DateCompleted, @WorkingHours, @ReplacedPartsReturned, @ShippingMethod, @Status, @Subject, @BookedServiceToWeek, @AgreedDeliveryDateWithCustomer)", serviceOrder);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Feil ved innsetting av ServiceOrder: " + ex.Message);
                    }
                }
            }
        }*/

    }
}