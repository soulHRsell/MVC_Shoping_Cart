CREATE procedure [dbo].[SP_CreateNewProduct]
	@adminId int,
	@name nvarchar(50),
	@amount int,
	@info nvarchar(200),
	@categoryname nvarchar(50)
as
begin
	
	set nocount on;

	declare @category int
	declare @product int

	select @category = ca.ID
	from Category ca
	where ca.[Name] = @categoryname

	insert into [Product]([Name], Amount, Info, CategoryId)
	values (@name, @amount, @info, @category)

	select @product = p.ID
	from [Product] p
	where p.[Name] = @name and p.Amount = @amount and p.Info = @info and p.CategoryId = @category

	insert into AdminProductSet(ProductSetDate, AdminId, ProductId)
	values (GETDATE(), @adminId, @product)
end
