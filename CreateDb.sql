docker run --rm --name NoostedDatabase -p 3306:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Gruppe4! -d mariadb:10.5.11

CREATE DATABASE IF NOT EXISTS billingdb;

USE billingdb;

create table People
(
    Id        int auto_increment
        primary key,
    FirstName varchar(255) null,
    LastName  varchar(255) null
);

create table ServiceOrder
(
    ServiceOrderID      bigint auto_increment
        primary key,
    CreatedBy           varchar(255) null,
    OrderNumber         varchar(255) not null,
    RecievedDate        datetime     not null,
    ModelYear           varchar(255) not null,
    SerialNumber        varchar(255) not null,
    ServiceRepGuarantee varchar(255) not null,
    CustomerAgreement   varchar(255) not null
);

create table CheckList
(
    CheckListID         bigint auto_increment
        primary key,
    ServiceOrderID      bigint       not null,
    DokNr               varchar(255) not null,
    Date                datetime     not null,
    ApprovedBy          varchar(255) not null,
    CheckClutch         varchar(255) not null,
    CheckStorage        varchar(255) not null,
    CheckPto            varchar(255) not null,
    CheckChainTensioner varchar(255) not null,
    CheckWire           varchar(255) not null,
    CheckPinionStorage  varchar(255) not null,
    CheckSprocket       varchar(255) not null,
    CheckHydraulic      varchar(255) not null,
    CheckHose           varchar(255) not null,
    CheckHydraulicBlock varchar(255) not null,
    CheckOilTank        varchar(255) not null,
    CheckOilBox         varchar(255) not null,
    CheckRingCylinder   varchar(255) not null,
    CheckBrakeCylinder  varchar(255) not null,
    CheckWiring         varchar(255) not null,
    CheckRadio          varchar(255) not null,
    CheckButtonBox      varchar(255) not null,
    CheckFunctions      varchar(255) not null,
    PullingPower        varchar(255) not null,
    BrakePower          varchar(255) not null,
    constraint CheckList_ServiceOrder_ServiceOrderID_fk
        foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
);

create table Customer
(
    CustomerID     bigint auto_increment
        primary key,
    ServiceOrderID bigint       not null,
    FirstName      varchar(255) not null,
    LastName       varchar(255) not null,
    CustomerEmail  varchar(255) not null,
    Adress         varchar(255) not null,
    ZipCode        varchar(255) not null,
    PhoneNumber    varchar(255) not null,
    constraint Customer_ServiceOrder_ServiceOrderID_fk
        foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
);

create table Employees
(
    EmployeeID     bigint auto_increment
        primary key,
    ServiceOrderID bigint       not null,
    FirstName      varchar(255) not null,
    LastName       varchar(255) not null,
    EmployeeEmail  varchar(255) not null,
    Adress         varchar(255) not null,
    ZipCode        varchar(255) not null,
    PhoneNumber    varchar(255) not null,
    Role           varchar(255) not null,
    Password       varchar(255) not null,
    constraint ServiceOrderID
        foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
);

create table WorkForm
(
    WorkFormID                   bigint auto_increment
        primary key,
    ServiceOrderID               bigint       not null,
    BookedService                varchar(255) not null,
    InquiryRegRec                varchar(255) not null,
    CaseDone                     varchar(255) not null,
    RecievedDate                 date         not null,
    ModellYear                   varchar(255) not null,
    ProductType                  varchar(255) not null,
    RecievedDelivery             varchar(255) not null,
    ServiceDone                  varchar(255) not null,
    HoursService                 varchar(255) not null,
    OrderDescriptionFromCustomer varchar(255) not null,
    CustomerInfo                 varchar(255) not null,
    OrderNumber                  varchar(255) not null,
    ServiceForm                  varchar(255) not null,
    constraint WorkForm_ServiceOrder_ServiceOrderID_fk
        foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
);

