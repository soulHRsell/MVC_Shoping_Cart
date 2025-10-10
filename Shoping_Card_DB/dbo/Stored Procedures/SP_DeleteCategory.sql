CREATE PROCEDURE [dbo].[SP_DeleteCategory]
	@Id int
AS
begin
	
	set nocount on

	Delete from Category where ID = @id

end
