CREATE PROCEDURE GetOrders
(
	@PageIndex INT,
	@PageSize INT
)
AS
BEGIN

	SELECT * FROM Orders
	ORDER BY Id
	OFFSET @PageIndex * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

END