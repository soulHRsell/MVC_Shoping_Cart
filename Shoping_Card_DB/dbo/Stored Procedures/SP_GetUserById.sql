CREATE PROCEDURE [dbo].[SP_GetUserById]
	@Id int
AS
begin
	
	set nocount on

	select u.Username,u.EmailAddress, u.[Password], u.FirstName, u.LastName, a.Country, a.[State], a.City, a.ZipCode
	from [User] u
	inner join [Address] a on u.AddressId = a.ID
	inner join CreditCard c on u.CreditCardId = c.ID
	where u.ID = @Id

end
