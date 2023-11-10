docker run --name NoestedDatabase -p 3306:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Gruppe4! -d mariadb:10.5.11
docker exec -it NoestedDatabase mysql -p


CREATE DATABASE IF NOT EXISTS NoestedDatabase;

USE NoestedDatabase;

create table People
(
    CustomerID     int auto_increment
        primary key,
    FirstName      varchar(255) null,
    LastName       varchar(255) null,
    CustomerEmail  varchar(255) null,
    Adress         varchar(255) null,
    ZipCode        varchar(255) null,
    PhoneNumber    varchar(255) null
);


create table ServiceOrder
(
    ServiceOrderID           int auto_increment
        primary key,
    CustomerID               int not null,
    CreatedBy                varchar(255) null,
    DateReceived             date         null,
    ModelYear                varchar(255) null,
    ProductType              varchar(255) null,
    SerialNumber             varchar(255) null,
    ServiceType              varchar(255) null,
    WhatIsAgreedWithCustomer text         null,
    RepairDescription        text         null,
    IncludedParts            varchar(255) null,
    DateCompleted            date         null,
    WorkingHours             int          null,
    ReplacedPartsReturned    varchar(255) null,
    ShippingMethod           varchar(255) null,
    Status                   varchar(255) null,
    Subject                  varchar(255) null,
    BookedServiceToWeek varchar(255) null,
    AgreedDeliveryDateWithCustomer date null,
    constraint ServiceOrder_Customer_CustomerID_fk
        foreign key (CustomerID) references Customer (CustomerID)
);

create table CheckList
(
    CheckListID         int auto_increment
        primary key,
    CustomerID      int       not null,
    DokNr               varchar(255) null,
    Date                datetime     null,
    ApprovedBy          varchar(255) null,
    CheckClutch         varchar(255) null,
    CheckStorage        varchar(255) null,
    CheckPto            varchar(255) null,
    CheckChainTensioner varchar(255) null,
    CheckWire           varchar(255) null,
    CheckPinionStorage  varchar(255) null,
    CheckSprocket       varchar(255) null,
    CheckHydraulic      varchar(255) null,
    CheckHose           varchar(255) null,
    CheckHydraulicBlock varchar(255) null,
    CheckOilTank        varchar(255) null,
    CheckOilBox         varchar(255) null,
    CheckRingCylinder   varchar(255) null,
    CheckBrakeCylinder  varchar(255) null,
    CheckWiring         varchar(255) null,
    CheckRadio          varchar(255) null,
    CheckButtonBox      varchar(255) null,
    CheckFunctions      varchar(255) null,
    PullingPower        varchar(255) null,
    BrakePower          varchar(255) null,
    constraint CheckList_Customer_CustomerID_fk
        foreign key (CustomerID) references Customer (CustomerID)
);



create table Employee
(
    EmployeeID     int auto_increment
        primary key,
    ServiceOrderID int       not null,
    FirstName      varchar(255) null,
    LastName       varchar(255) null,
    EmployeeEmail  varchar(255) null,
    Adress         varchar(255) null,
    ZipCode        varchar(255) null,
    PhoneNumber    varchar(255) null,
    Role           varchar(255) null,
    constraint Employee_ServiceOrder_ServiceOrderID_fk
        foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
);

