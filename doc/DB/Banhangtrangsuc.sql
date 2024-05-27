create database Banhangtrangsuc
use Banhangtrangsuc

CREATE TABLE roles (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name NVARCHAR(50) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE(),
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

CREATE TABLE categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),
);

/*CREATE TABLE suppliers (
    supplier_id INT IDENTITY(1,1) PRIMARY KEY,
    supplier_name NVARCHAR(100) NOT NULL,
    contact_name NVARCHAR(100),
    contact_email NVARCHAR(100),
    contact_phone NVARCHAR(20),
    address NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
); */

CREATE TABLE promotions (
    promotion_id INT IDENTITY(1,1) PRIMARY KEY,
    promotion_name NVARCHAR(100) NOT NULL,
    discount_rate DECIMAL(5, 2) NOT NULL CHECK (discount_rate >= 0 AND discount_rate <= 100),
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    CHECK (end_date > start_date)
);

CREATE TABLE customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_name NVARCHAR(100) NOT NULL,
	customer_rank NVARCHAR(100) NOT NULL,
    points INT NOT NULL CHECK (points >= 0),
);

CREATE TABLE return_policies (
    policy_id INT IDENTITY(1,1) PRIMARY KEY,
    policy_name NVARCHAR(100) NOT NULL,
    description NVARCHAR(1000),
    created_at DATETIME DEFAULT GETDATE(),
);

/*CREATE TABLE gold_prices (
    gold_price_id INT IDENTITY(1,1) PRIMARY KEY,
    price_date DATE NOT NULL,
    price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
    created_at DATETIME DEFAULT GETDATE(),
); */

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_code NVARCHAR(50) NOT NULL UNIQUE,
    product_name NVARCHAR(100) NOT NULL,
	product_images NVARCHAR(200) NOT NULL,
	quantity INT NOT NULL CHECK (quantity > 0),
    category_id INT,
--    supplier_id INT,
    weight DECIMAL(10, 2) NOT NULL CHECK (weight > 0),
--    gold_price_id INT,
    labor_cost DECIMAL(10, 2) DEFAULT 0 CHECK (labor_cost >= 0),
    stone_cost DECIMAL(10, 2) DEFAULT 0 CHECK (stone_cost >= 0),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (category_id) REFERENCES categories(category_id),
--    FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id),
--   FOREIGN KEY (gold_price_id) REFERENCES gold_prices(gold_price_id)
);

CREATE TABLE gem (
	gem_id NVARCHAR(10) PRIMARY KEY,
	gem_name NVARCHAR(255) NOT NULL, 
	gem_type NVARCHAR(100) NOT NULL,
	quantity INT NOT NULL CHECK (quantity > 0 and quantity <= 1),
	gem_price DECIMAL(10, 2) NOT NULL CHECK (gem_price >= 0),
	created_at DATETIME DEFAULT GETDATE(),
);

CREATE TABLE product_gem (
	product_id INT NOT NULL,
    gem_id NVARCHAR(10) NOT NULL,
    PRIMARY KEY (product_id, gem_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (gem_id) REFERENCES gem(gem_id)
);


CREATE TABLE gold (
	gold_id NVARCHAR(10) PRIMARY KEY,
	gold_name NVARCHAR(255) NOT NULL, 
	gold_type NVARCHAR(100) NOT NULL,
	gold_price DECIMAL(10, 2) NOT NULL CHECK (gold_price >= 0),
	quantity INT NOT NULL CHECK (quantity > 0),
	created_at DATETIME DEFAULT GETDATE(),
);

CREATE TABLE product_gold (
	product_id INT NOT NULL,
    gold_id NVARCHAR(10) NOT NULL,
    PRIMARY KEY (product_id, gold_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (gold_id) REFERENCES gold(gold_id)
);


CREATE TABLE [sales] (
    sale_id INT IDENTITY(1,1) PRIMARY KEY,
	sale_type NVARCHAR(100) NOT NULL,
    sale_date DATETIME DEFAULT GETDATE(),
 -- customer_name NVARCHAR(100) NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL CHECK (total_amount >= 0),
    discount DECIMAL(10, 2) DEFAULT 0 CHECK (discount >= 0),
    final_amount AS (total_amount - discount) PERSISTED,
    user_id INT NOT NULL,
    promotion_id INT,
    customer_id INT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (promotion_id) REFERENCES promotions(promotion_id),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);

/*
CREATE TABLE inventory (
    inventory_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity >= 0),
    last_updated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
); */


CREATE TABLE sale_details (
    sale_detail_id INT IDENTITY(1,1) PRIMARY KEY,
    sale_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10, 2) NOT NULL CHECK (unit_price >= 0),
    total_price AS (quantity * unit_price) PERSISTED,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (sale_id) REFERENCES [sales](sale_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE purchases (
    purchase_id INT IDENTITY(1,1) PRIMARY KEY,
    purchase_date DATETIME DEFAULT GETDATE(),
    customer_name NVARCHAR(100) NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL CHECK (total_amount >= 0),
    user_id INT NOT NULL,
    policy_id INT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (policy_id) REFERENCES return_policies(policy_id)
);


CREATE TABLE purchase_items (
    purchase_item_id INT IDENTITY(1,1) PRIMARY KEY,
    purchase_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10, 2) NOT NULL CHECK (unit_price >= 0),
    total_price AS (quantity * unit_price) PERSISTED,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (purchase_id) REFERENCES purchases(purchase_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE invoices (
    invoice_id INT IDENTITY(1,1) PRIMARY KEY,
    sale_id INT NOT NULL,
    warranty_period INT NOT NULL CHECK (warranty_period > 0), -- in months
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (sale_id) REFERENCES [sales](sale_id)
);

CREATE TABLE purchase_orders (
    purchase_order_id INT IDENTITY(1,1) PRIMARY KEY,
    order_date DATETIME DEFAULT GETDATE(),
--    supplier_id INT NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL CHECK (total_amount >= 0),
    status NVARCHAR(50),
    user_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
--    FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE purchase_order_items (
    purchase_order_item_id INT IDENTITY(1,1) PRIMARY KEY,
    purchase_order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10, 2) NOT NULL CHECK (unit_price >= 0),
    total_price AS (quantity * unit_price) PERSISTED,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (purchase_order_id) REFERENCES purchase_orders(purchase_order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


CREATE TABLE audit_logs (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    action NVARCHAR(255) NOT NULL,
    action_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    message NVARCHAR(255) NOT NULL,
    is_read BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
