CREATE PROCEDURE [dbo].[SP_EditUserInfo]
	@Id int,
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
begin

	set nocount on

	declare @address int
	declare @creditCard int

	select @address = u.AddressId, @creditCard = u.CreditCardId
	from [User] u 
	where u.ID = @Id

	Update [Address]
	Set	Country = @country, [State] = @state, City = @city, ZipCode = @zipcode
	where ID = @address

	Update CreditCard
	set CardNumber = @cardNumber
	where ID = @creditCard

	Update [User]
	set Username = @username, [Password] = @Password, EmailAddress = @EmailAddress, FirstName = @firstname, LastName = @lastname
	where ID = @Id

end
