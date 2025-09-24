-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Create_New_Category] 
	-- Add the parameters for the stored procedure here
	@adminId int,
	@name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @category int;

    -- Insert statements for procedure here
	insert into Category([Name]) values (@name)

	select @category = c.ID
	from Category c
	where c.[Name] = @name

	insert into AdminCategorySet(CategorySetDate, AdminId, CategoryId)
	values (GETDATE(), @adminId, @category)

END
