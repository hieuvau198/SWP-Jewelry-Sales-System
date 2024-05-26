CREATE DATABASE Jewelry;
USE Jewelry;


-- Drop foreign key constraints first
IF OBJECT_ID('OrderDetail', 'U') IS NOT NULL
BEGIN
    ALTER TABLE OrderDetail DROP CONSTRAINT IF EXISTS FK_OrderDetail_Product;
END

IF OBJECT_ID('Stall', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Stall DROP CONSTRAINT IF EXISTS FK_Stall_Product;
END

IF OBJECT_ID('PriceHistory', 'U') IS NOT NULL
BEGIN
    ALTER TABLE PriceHistory DROP CONSTRAINT IF EXISTS FK_PriceHistory_Product;
END

-- Drop existing tables if they exist
IF OBJECT_ID('DiscountConfirmation', 'U') IS NOT NULL DROP TABLE DiscountConfirmation;
IF OBJECT_ID('TransactionHistory', 'U') IS NOT NULL DROP TABLE TransactionHistory;
IF OBJECT_ID('Warranty', 'U') IS NOT NULL DROP TABLE Warranty;
IF OBJECT_ID('OrderDetail', 'U') IS NOT NULL DROP TABLE OrderDetail;
IF OBJECT_ID('Stall', 'U') IS NOT NULL DROP TABLE Stall;
IF OBJECT_ID('Sale', 'U') IS NOT NULL DROP TABLE Sale;
IF OBJECT_ID('Cashier', 'U') IS NOT NULL DROP TABLE Cashier;
IF OBJECT_ID('Customer', 'U') IS NOT NULL DROP TABLE Customer;
IF OBJECT_ID('Product', 'U') IS NOT NULL DROP TABLE Product;
IF OBJECT_ID('[Order]', 'U') IS NOT NULL DROP TABLE [Order];
IF OBJECT_ID('Discount', 'U') IS NOT NULL DROP TABLE Discount;
IF OBJECT_ID('Manager', 'U') IS NOT NULL DROP TABLE Manager; -- Drop Manager table first
IF OBJECT_ID('Admin', 'U') IS NOT NULL DROP TABLE Admin; -- Then drop Admin table

-- Recreate Admin table
CREATE TABLE Admin (
    AdminID INT NOT NULL IDENTITY(1,1),
    AdminName VARCHAR(200) NOT NULL,
    AdminContact VARCHAR(20) NOT NULL,
    Password VARCHAR(200) NOT NULL,
    Email VARCHAR(200) NOT NULL,
    PRIMARY KEY (AdminID)
);

-- Recreate Manager table
CREATE TABLE Manager (
    ManagerID INT NOT NULL IDENTITY(1,1),
    ManagerName VARCHAR(200) NOT NULL,
    Password VARCHAR(200) NOT NULL,
    Email VARCHAR(200) NOT NULL,
    AdminID INT NOT NULL,
    PRIMARY KEY (ManagerID),
    FOREIGN KEY (AdminID) REFERENCES Admin(AdminID)
);

-- Table for Sale
CREATE TABLE Sale (
    SaleID INT NOT NULL IDENTITY(1,1),
    SaleName VARCHAR(200) NOT NULL,
    SaleContact VARCHAR(20) NOT NULL,
    Password VARCHAR(200) NOT NULL,
    Email VARCHAR(200) NOT NULL,
    ManagerID INT NOT NULL,
    PRIMARY KEY (SaleID),
    FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);

-- Table for Cashier
CREATE TABLE Cashier (
    CashierID INT NOT NULL IDENTITY(1,1),
    CashierName VARCHAR(200) NOT NULL,
    CashierContact VARCHAR(20) NOT NULL,
    Password VARCHAR(200) NOT NULL,
    Email VARCHAR(200) NOT NULL,
    ManagerID INT NOT NULL,
    PRIMARY KEY (CashierID),
    FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);

-- Table for Customer
CREATE TABLE Customer (
    CustomerID INT NOT NULL IDENTITY(1,1),
    CustomerName VARCHAR(200) NOT NULL,
    CustomerContact VARCHAR(20) NOT NULL,
    LoyaltyPoint INT NOT NULL,
    PRIMARY KEY (CustomerID)
);

-- Table for Product
CREATE TABLE Product (
    ProductID INT NOT NULL IDENTITY(1,1),
    ProductName VARCHAR(200) NOT NULL,
    ProductQuantity INT NOT NULL,
    ProductPrice FLOAT NOT NULL,
    GoldPrice FLOAT NOT NULL,
    Weight FLOAT NOT NULL,
    LaborCost FLOAT NOT NULL,
    StoneCost FLOAT NOT NULL,
    PRIMARY KEY (ProductID)
);

-- Table for Order
CREATE TABLE [Order] (
    OrderID INT NOT NULL IDENTITY(1,1),
    OrderType VARCHAR(200) NOT NULL,
    PRIMARY KEY (OrderID)
);

-- Table for Discount
CREATE TABLE Discount (
    DiscountID INT NOT NULL IDENTITY(1,1),
    DiscountName VARCHAR(200) NOT NULL,
    PublicDate DATE NOT NULL,
    ExpireDate DATE NOT NULL,
    PRIMARY KEY (DiscountID)
);

-- Table for OrderDetail
CREATE TABLE OrderDetail (
    DetailID INT NOT NULL IDENTITY(1,1),
    OrderDate DATE NOT NULL,
    Quantity INT NOT NULL,
    OrderID INT NOT NULL,
    CustomerID INT NOT NULL,
    SaleID INT NOT NULL,
    CashierID INT NOT NULL,
    ProductID INT NOT NULL,
    DiscountID INT NOT NULL,
    PRIMARY KEY (DetailID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (SaleID) REFERENCES Sale(SaleID),
    FOREIGN KEY (CashierID) REFERENCES Cashier(CashierID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (DiscountID) REFERENCES Discount(DiscountID)
);

-- Table for DiscountConfirmation
CREATE TABLE DiscountConfirmation (
    ConfirmationID INT NOT NULL IDENTITY(1,1),
    ManagerID INT NOT NULL,
    CustomerID INT NOT NULL,
    DiscountID INT NOT NULL,
    PRIMARY KEY (ConfirmationID),
    FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (DiscountID) REFERENCES Discount(DiscountID)
);

-- Table for TransactionHistory
CREATE TABLE TransactionHistory (
    TransactionID INT NOT NULL IDENTITY(1,1),
    Price FLOAT NOT NULL,
    CustomerID INT NOT NULL,
    OrderID INT NOT NULL,
    PRIMARY KEY (TransactionID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

-- Create the Warranty table
CREATE TABLE Warranty (
    WarrantyID INT NOT NULL IDENTITY(1,1),
    StartDate DATE NOT NULL,
    ExpireDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    PRIMARY KEY (WarrantyID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

-- Create the Stall table
CREATE TABLE Stall (
    StallID INT NOT NULL IDENTITY(1,1),
    ProductID INT NOT NULL,
    PRIMARY KEY (StallID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
