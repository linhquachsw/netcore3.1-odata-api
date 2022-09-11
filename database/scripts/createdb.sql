CREATE DATABASE ProductStore
GO

USE ProductStore
GO 

CREATE TABLE Category
(
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(255) NOT NULL,
	PRIMARY KEY (Id)
)

GO

CREATE TABLE Supplier
(
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(255) NOT NULL,
	PRIMARY KEY (Id)
)

GO

CREATE TABLE Product
(
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(255) NOT NULL,
	Price DECIMAL(13, 2) NOT NULL,
	CategoryId INT NOT NULL,
	SupplierId INT NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (CategoryId) REFERENCES Category(Id),
	FOREIGN KEY (SupplierId) REFERENCES Supplier(Id)
)

GO

CREATE TABLE ProductRating
(
	Id INT IDENTITY(1, 1) NOT NULL,
	Rating int NOT NULL,
	ProductID int NOT NULL,
	PRIMARY KEY (Id)
)

GO

INSERT INTO Category
VALUES
('Category A'),
('Category B'),
('Category C'),
('Category D')

INSERT INTO Supplier
VALUES
('Sony'),
('Microsoft'),
('Amazon'),
('Alibaba')

INSERT INTO Product
VALUES
('Product 1', 1012.305, 1, 2),
('Product 2', 1022.305, 2, 1),
('Product 3', 76.305, 3, 2),
('Product 4', 212.305, 4, 3),
('Product 5', 2212.305, 2, 4),
('Product 6', 72.305, 4, 3)