create table if not exists Customer
(
    CustomerID     bigint auto_increment
        primary key,
    ServiceOrderID bigint       not null,
    FirstName      varchar(255) not null,
    LastName       varchar(255) not null,
    CustomerEmail  varchar(255) not null,
    Adress         varchar(255) not null,
    ZipCode        varchar(255) not null,
    PhoneNumber    varchar(255) not null
);

create table if not exists People
(
    Id        int auto_increment
        primary key,
    FirstName varchar(255) null,
    LastName  varchar(255) null
);

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
    CustomerAgreement   varchar(255) not null
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
    ServiceForm                  varchar(255) not null
);

