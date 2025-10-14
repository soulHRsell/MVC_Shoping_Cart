CREATE PROCEDURE [dbo].[SP_DeleteProduct]
	@Id int
AS
begin
	
	set nocount on

	Delete from Product where ID = @Id

end
