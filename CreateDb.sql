CREATE DATABASE IF NOT EXISTS NoestedDatabase;

USE NoestedDatabase;

create table if not exists Customer
(
    CustomerID    int auto_increment
        primary key,
    FirstName     varchar(255) null,
    LastName      varchar(255) null,
    CustomerEmail varchar(255) null,
    Adress        varchar(255) null,
    ZipCode       varchar(255) null,
    PhoneNumber   varchar(255) null
);


create table if not exists ServiceOrder
(
    ServiceOrderID                 int auto_increment
        primary key,
    CustomerID                     int          not null,
    CreatedBy                      varchar(255) null,
    DateReceived                   date         null,
    ModelYear                      varchar(255) null,
    ProductType                    varchar(255) null,
    SerialNumber                   varchar(255) null,
    ServiceType                    varchar(255) null,
    WhatIsAgreedWithCustomer       text         null,
    RepairDescription              text         null,
    IncludedParts                  varchar(255) null,
    DateCompleted                  date         null,
    WorkingHours                   int          null,
    ReplacedPartsReturned          varchar(255) null,
    ShippingMethod                 varchar(255) null,
    Status                         varchar(255) null,
    Subject                        varchar(255) null,
    BookedServiceToWeek            varchar(255) null,
    AgreedDeliveryDateWithCustomer date         null,
    constraint ServiceOrder_Customer_CustomerID_fk
        foreign key (CustomerID) references Customer (CustomerID)
);

create table if not exists CheckList
(
    CheckListID            int auto_increment
        primary key,
    CustomerID             int          not null,
    DokNr                  varchar(255) not null,
    Date                   varchar(255) not null,
    ApprovedBy             varchar(255) null,
    CheckClutch            varchar(255) null,
    WearBrakes             varchar(255) null,
    CheckDrums             varchar(255) null,
    CheckPto               varchar(255) null,
    CheckChainTensioner    varchar(255) null,
    CheckWire              varchar(255) null,
    CheckPinionBearing     varchar(255) null,
    CheckSprocket          varchar(255) null,
    CheckHydraulicSylinder varchar(255) null,
    CheckHose              varchar(255) null,
    CheckHydraulicBlock    varchar(255) null,
    CheckOilTank           varchar(255) null,
    CheckOilBox            varchar(255) null,
    CheckRingCylinder      varchar(255) null,
    CheckBrakeCylinder     varchar(255) null,
    CheckWiring            varchar(255) null,
    CheckRadio             varchar(255) null,
    CheckButtonBox         varchar(255) null,
    PressureTest           varchar(255) null,
    CheckFunctions         varchar(255) null,
    PullingPower           varchar(255) null,
    BrakePower             varchar(255) null,
        constraint CheckList_Customer_CustomerID_fk
        foreign key (CustomerID) references Customer (CustomerID)
);

create table if not EXISTS users
(
    Id    int not null unique auto_increment,
    Name  varchar(255),
    Email varchar(255) UNIQUE,

    CONSTRAINT U_User_ID_PK PRIMARY KEY (Id)
);

create table if not EXISTS AspNetRoles
(
    Id               varchar(255) not null,
    Name             varchar(255),
    NormalizedName   varchar(255),
    ConcurrencyStamp varchar(255),
    CONSTRAINT U_ROLE_ID_PK PRIMARY KEY (Id)
);

insert into AspNetRoles(id, Name, NormalizedName)
values ('Administrator', 'Administrator', 'Administrator');

create table if not EXISTS AspNetUsers
(
    Id                   varchar(255) not null unique,
    UserName             varchar(255),
    NormalizedUserName   varchar(255),
    Email                varchar(255),
    NormalizedEmail      varchar(255),
    EmailConfirmed       bit          not null,
    PasswordHash         varchar(255),
    SecurityStamp        varchar(255),
    ConcurrencyStamp     varchar(255),
    PhoneNumber          varchar(50),
    PhoneNumberConfirmed bit          not null,
    TwoFactorEnabled     bit          not null,
    LockoutEnd           TIMESTAMP,
    LockoutEnabled       bit          not null,
    AccessFailedCount    int          not null,
    CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
create table if not EXISTS AspNetUserTokens
(
    UserId        varchar(255) not null,
    LoginProvider varchar(255) not null,
    Name          varchar(255) not null,
    Value         varchar(255),
    CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider)
);

create table if not EXISTS AspNetRoleClaims
(
    Id         int UNIQUE auto_increment,
    ClaimType  varchar(255) not null,
    ClaimValue varchar(255) not null,
    RoleId     varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key (RoleId)
        references AspNetRoles (Id)
);

create table if not EXISTS AspNetUserClaims
(
    Id         int UNIQUE auto_increment,
    ClaimType  varchar(255),
    ClaimValue varchar(255),
    UserId     varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key (UserId)
        references AspNetUsers (Id)
);

create table if not EXISTS AspNetUserLogins
(
    LoginProvider       int UNIQUE auto_increment,
    ProviderKey         varchar(255) not null,
    ProviderDisplayName varchar(255) not null,
    UserId              varchar(255) not null,
    CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider),
    foreign key (UserId)
        references AspNetUsers (Id)
);

create table if not EXISTS AspNetUserRoles
(
    UserId varchar(255) not null,
    RoleId varchar(255) not null,
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId, RoleId),
    foreign key (UserId)
        references AspNetUsers (Id),
    foreign key (RoleId)
        references AspNetRoles (Id)
);