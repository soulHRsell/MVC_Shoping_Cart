CREATE PROCEDURE [dbo].[SP_GetProductByName]
	@name nvarchar(50)
AS
begin

	set nocount on

	SELECT ca.Name AS Category, p.ID, p.Name, p.Amount, p.Info, p.Price
	FROM dbo.Product AS p INNER JOIN dbo.Category AS ca ON p.CategoryId = ca.ID
	WHERE LOWER(p.[Name]) = LOWER(@name) 

end
