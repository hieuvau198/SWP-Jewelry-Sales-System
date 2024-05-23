CREATE DATABASE MANAGER_SALE_SYSTEM;

USE MANAGER_SALE_SYSTEM;

CREATE TABLE Product
(
  ProductID INT NOT NULL,
  ProductName VARCHAR(200) NOT NULL,
  ProductQuantity INT NOT NULL,
  ProductPrice FLOAT NOT NULL,
  PRIMARY KEY (ProductID)
);

CREATE TABLE Admin
(
  AdminID INT NOT NULL,
  AdminName VARCHAR(200) NOT NULL,
  AdminContact VARCHAR(20) NOT NULL,
  Password VARCHAR(200) NOT NULL,
  Email VARCHAR(200) NOT NULL,
  PRIMARY KEY (AdminID)
);

CREATE TABLE Manager
(
  ManagerID INT NOT NULL,
  ManagerName VARCHAR(200) NOT NULL,
  Password VARCHAR(200) NOT NULL,
  Email VARCHAR(200) NOT NULL,
  AdminID INT NOT NULL,
  PRIMARY KEY (ManagerID),
  FOREIGN KEY (AdminID) REFERENCES Admin(AdminID)
);

CREATE TABLE Sale
(
  SaleID INT NOT NULL,
  SaleName VARCHAR(200) NOT NULL,
  SaleContact VARCHAR(20) NOT NULL,
  Password VARCHAR(200) NOT NULL,
  Email VARCHAR(200) NOT NULL,
  ManagerID INT NOT NULL,
  PRIMARY KEY (SaleID),
  FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);

CREATE TABLE Cashier
(
  CashierID INT NOT NULL,
  CashierName VARCHAR(200) NOT NULL,
  CashierContact VARCHAR(20) NOT NULL,
  Password VARCHAR(200) NOT NULL,
  Email VARCHAR(200) NOT NULL,
  ManagerID INT NOT NULL,
  PRIMARY KEY (CashierID),
  FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);

CREATE TABLE Customer
(
  CustomerID INT NOT NULL,
  CustomerName VARCHAR(200) NOT NULL,
  CustomerContact VARCHAR(20) NOT NULL,
  LoyaltyPoint INT NOT NULL,
  PRIMARY KEY (CustomerID)
);

CREATE TABLE "Order"
(
  OrderID INT NOT NULL,
  OrderType VARCHAR(200) NOT NULL,
  PRIMARY KEY (OrderID)
);

CREATE TABLE Stall
(
  StallID INT NOT NULL,
  ProductID INT NOT NULL,
  PRIMARY KEY (StallID),
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE Discount
(
  DiscountID INT NOT NULL,
  DiscountName VARCHAR(200) NOT NULL,
  PublicDate DATE NOT NULL,
  ExpireDate DATE NOT NULL,
  PRIMARY KEY (DiscountID)
);

CREATE TABLE TransactionHistory
(
  Price FLOAT NOT NULL,
  CustomerID INT NOT NULL,
  OrderID INT NOT NULL,
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  FOREIGN KEY (OrderID) REFERENCES "Order"(OrderID)
);

CREATE TABLE Warranty
(
  WarrantyID INT NOT NULL,
  StartDate DATE NOT NULL,
  ExpireDate DATE NOT NULL,
  CustomerID INT NOT NULL,
  PRIMARY KEY (WarrantyID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderDetail
(
  DetailID INT NOT NULL,
  OrderDate DATE NOT NULL,
  Quantity INT NOT NULL,
  OrderID INT NOT NULL,
  CustomerID INT NOT NULL,
  SaleID INT NOT NULL,
  CashierID INT NOT NULL,
  ProductID INT NOT NULL,
  DiscountID INT NOT NULL,
  PRIMARY KEY (DetailID),
  FOREIGN KEY (OrderID) REFERENCES "Order"(OrderID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  FOREIGN KEY (SaleID) REFERENCES Sale(SaleID),
  FOREIGN KEY (CashierID) REFERENCES Cashier(CashierID),
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
  FOREIGN KEY (DiscountID) REFERENCES Discount(DiscountID)
);
