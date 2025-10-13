CREATE procedure [dbo].[SP_CreateNewProduct]
	@name nvarchar(50),
	@amount int,
	@info nvarchar(200),
	@price int,
	@categoryId int
as
begin
	
	set nocount on;

	insert into [Product]([Name], Amount, Info, Price, CategoryId)
	values (@name, @amount, @info, @price, @categoryId)

end
