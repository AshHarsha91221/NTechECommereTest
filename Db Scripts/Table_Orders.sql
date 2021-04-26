CREATE TABLE Orders (

	Id INT IDENTITY(1,1) PRIMARY KEY,
	ItemId INT,
	AddressId INT NOT NULL,
	Quantity INT NOT NULL,
	Active BIT DEFAULT 1,
	CreatedOn DATETIME DEFAULT GETDATE(),
	CreatedBy INT REFERENCES Customers(Id),
	UpdatedOn DATETIME

)