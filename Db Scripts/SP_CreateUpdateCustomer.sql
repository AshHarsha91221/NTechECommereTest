CREATE PROCEDURE CreateUpdateCustomer
(
	@Id INT,
	@FirstName NVARCHAR(100) = NULL,
	@LastName NVARCHAR(100) = NULL,
	@EmailAddress NVARCHAR(100) = NULL,
	@Password NVARCHAR(200) = NULL,
	@PhoneNumber NVARCHAR(15) = NULL
)
AS
BEGIN

	IF(@Id > 0)
	BEGIN

		UPDATE Customers
		SET FirstName = ISNULL(NULLIF(@FirstName, ''), FirstName),
			LastName = ISNULL(NULLIF(@LastName, ''), LastName),
			EmailAddress = ISNULL(NULLIF(@EmailAddress, ''), EmailAddress),
			Password = ISNULL(NULLIF(@Password, ''), Password),
			PhoneNumber = ISNULL(NULLIF(@PhoneNumber, ''), PhoneNumber),
			UpdatedOn = GETDATE()

	END
	ELSE
	BEGIN

		IF EXISTS(SELECT 1 FROM Customers WHERE EmailAddress = @EmailAddress)
			THROW 50000, 'EmailAddress already Exists - Code 888, 777', 16;

		IF EXISTS(SELECT 1 FROM Customers WHERE EmailAddress = @EmailAddress)
			THROW 50000, 'PhoneNumber already Exists', 16;

		INSERT INTO Customers(FirstName, LastName, EmailAddress, Password, PhoneNumber)
		VALUES(@FirstName, @LastName, @EmailAddress, @Password, @PhoneNumber)

		SELECT @Id = IDENT_CURRENT('Customers')

	END

	SELECT Id, FirstName, LastName, EmailAddress, Password, PhoneNumber, Active, CreatedOn, UpdatedOn FROM Customers WHERE Id = @Id

END