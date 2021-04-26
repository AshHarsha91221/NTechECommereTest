CREATE PROCEDURE CreateOrder
(
	@CustomerId INT,
	@ItemId INT,
	@AddressId INT,
	@Quantity INT
)
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM Customers WHERE Id = @CustomerId)
		THROW 50000, 'Customer Doesn''t Exist', 16

	INSERT INTO Orders(ItemId, AddressId, Quantity, CreatedBy)
	VALUES(@ItemId, @AddressId, @Quantity, @CustomerId)

	SELECT Id, ItemId, AddressId, Quantity, Active, CreatedOn, CreatedBy, UpdatedOn FROM Orders WHERE Id = IDENT_CURRENT('Orders')

END