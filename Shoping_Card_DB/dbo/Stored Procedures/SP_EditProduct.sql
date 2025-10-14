CREATE PROCEDURE [dbo].[SP_EditProduct]
	@id int,
	@name nvarchar(50),
	@amount int,
	@info nvarchar(200),
	@categoryId int,
	@price int
AS
begin

	set nocount on 

	Update Product 
	Set [Name] = @name, Amount = @amount, Info = @info, CategoryId = @categoryId, Price = @price
	Where ID = @id 

end
