create table if not exists ServiceOrder
(
    ServiceOrderID      bigint auto_increment
    primary key,
    CreatedBy           varchar(255) null,
    OrderNumber         varchar(255) not null,
    RecievedDate        datetime     not null,
    ModelYear           varchar(255) not null,
    SerialNumber        varchar(255) not null,
    ServiceRepGuarantee varchar(255) not null,
    CustomerAgreement   varchar(255) not null,
    Status              varchar(255) not null,
    Title               varchar(255) not null
    );

create table if not exists CheckList
(
    CheckListID            int auto_increment
    primary key,
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
    BrakePower             varchar(255) null
    );



create table if not exists Customer
(
    CustomerID     bigint auto_increment
    primary key,
    ServiceOrderID bigint       not null,
    FirstName      varchar(255) not null,
    LastName       varchar(255) not null,
    CustomerEmail  varchar(255) not null,
    Address        varchar(255) null,
    ZipCode        varchar(255) null,
    PhoneNumber    varchar(255) not null,
    constraint Customer_ServiceOrder_ServiceOrderID_fk
    foreign key (ServiceOrderID) references ServiceOrder (ServiceOrderID)
    );

create table if not exists Employees
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

create table if not exists WorkForm
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

