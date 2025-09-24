-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UserPurchase
	-- Add the parameters for the stored procedure here
	@userId int,
	@productName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @product int

	select @product = p.ID
	from [Product] p
	where p.[Name] = @productName

	insert into Purchase(PurchaseDate, UserId, ProductId)
	values (GETDATE(), @userId, @product)

END
