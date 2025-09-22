-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Create_A_User
	-- Add the parameters for the stored procedure here
	@username nvarchar(50),
	@Password nvarchar(100),
	@EmailAddress nvarchar(100),
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@country nvarchar(50),
	@state nvarchar(50),
	@city nvarchar(50),
	@zipcode nvarchar(50),
	@cardnumber int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into [Address](Country, [State], City, ZipCode) 
	values (@country, @state, @city, @zipcode)

	insert into CreditCard(CardNumber)
	values (@cardnumber)

	declare @address int;

	select @address = a.ID
	from [Address] a
	where a.Country = @country
	and a.[State] = @state
	and a.City = @city
	and a.ZipCode = @zipcode

	declare @creditcard int

	select @creditcard = c.ID
	from CreditCard c
	where c.CardNumber = @cardnumber

	insert into [User](Username, [Password], EmailAddress, FirstName, LastName, AddressId, CreditCardId, isAdmin)
	values (@username, @Password, @EmailAddress, @firstname, @lastname, @address, @creditcard, 0)

END
