CREATE PROCEDURE [dbo].[SP_GetUserByUsername]
	@username nvarchar(50)
AS
begin
	
	set nocount on;

	select u.Username, u.[Password], u.isAdmin
	from [User] u
	where u.Username = @username
	
end
