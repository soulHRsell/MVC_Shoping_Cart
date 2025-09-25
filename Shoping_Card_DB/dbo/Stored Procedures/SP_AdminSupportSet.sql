-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_AdminSupportSet 
	-- Add the parameters for the stored procedure here
	@adminId int,
	@userName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @user int

	select @user = u.ID
	from [User] u
	where u.Username = @userName

	insert into AdminSupport(SupportDate, AdminId, UserId)
	values (GETDATE(), @adminId, @user)
END
