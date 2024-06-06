CREATE DATABASE SaleJewerly
USE SaleJewerly

CREATE TABLE roles (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name NVARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    role_id INT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (role_id) REFERENCES roles(role_id)
);

CREATE TABLE customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_name NVARCHAR(100) NOT NULL,
	customer_rank NVARCHAR(100) NOT NULL,
    loyalty_points INT NOT NULL CHECK (loyalty_points >= 0),
);

CREATE TABLE gem (
    gem_id NVARCHAR(100) PRIMARY KEY,
    gem_name NVARCHAR(200) NOT NULL,
    gem_price DECIMAL(10, 2) NOT NULL CHECK (gem_price >= 0)
);

CREATE TABLE gold(
	gold_id NVARCHAR(100) PRIMARY KEY,
    gold_name NVARCHAR(200) NOT NULL,
    gold_price DECIMAL(10, 2) NOT NULL CHECK (gold_price >= 0)
);

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_code NVARCHAR(50) NOT NULL UNIQUE,
    product_name NVARCHAR(100) NOT NULL,
	product_images NVARCHAR(200) NOT NULL,
	product_quantity INT NOT NULL CHECK (product_quantity > 0),
    product_type NVARCHAR(100) NOT NULL,
    product_weight FLOAT NOT NULL CHECK (product_weight > 0),
	product_warranty INT NOT NULL,								  --month 
	markup_rate FLOAT NOT NULL,
	gem_id NVARCHAR(100) NOT NULL,
	gem_weight FLOAT NOT NULL CHECK (gem_weight > 0),
	gold_id NVARCHAR(100) NOT NULL,
	gold_weight FLOAT NOT NULL CHECK (gold_weight > 0),
    labor_cost DECIMAL(10, 2) DEFAULT 0 CHECK (labor_cost >= 0),
    created_at DATETIME DEFAULT GETDATE()
	FOREIGN KEY (gem_id) REFERENCES gem(gem_id),
	FOREIGN KEY (gold_id) REFERENCES gold(gold_id)
);



CREATE TABLE [order](
	order_id INT IDENTITY(1,1) PRIMARY KEY,
	order_type NVARCHAR(200) NOT NULL	
);

CREATE TABLE discounts(
    discount_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    discount_name VARCHAR(200) NOT NULL,
	order_type NVARCHAR(200) NOT NULL,
	product_type NVARCHAR(200) NOT NULL,
    public_date DATE NOT NULL,
    expire_date DATE NOT NULL,	
);


CREATE TABLE order_detail(
	detail_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	order_id INT NOT NULL,
	product_id INT NOT NULL,
	product_price DECIMAL(10, 2) NOT NULL CHECK (product_price >= 0),
    quantity INT NOT NULL CHECK (quantity > 0),
	customer_id INT  NOT NULL,
	user_id INT NOT NULL,
	discount_id INT NOT NULL,
	FOREIGN KEY (order_id) REFERENCES [order](order_id),
	FOREIGN KEY (product_id) REFERENCES products(product_id),
	FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	FOREIGN KEY (discount_id) REFERENCES discounts(discount_id)
);


CREATE TABLE warranty(
    warranty_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    start_date DATE NOT NULL,
    expire_date DATE NOT NULL,
    
);

CREATE TABLE invoice(
	invoice_id INT NOT NULL PRIMARY KEY,
	invoice_type NVARCHAR(100) NOT NULL,
	order_id INT NOT NULL,
	warranty_id INT NOT NULL,
	FOREIGN KEY (order_id) REFERENCES [order](order_id),	
	FOREIGN KEY (warranty_id) REFERENCES warranty(warranty_id)
);

CREATE TABLE [transaction](
	transaction_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	invoice_id INT NOT NULL,
	created_at DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (invoice_id) REFERENCES invoice(invoice_id)
);

