CREATE PROCEDURE [dbo].[SP_SearchCategory]
	@name nvarchar(50) = null
AS
begin
	
	set nocount on 

	select ca.ID, ca.[name]
	from Category ca
	where @name is null or Lower(ca.[Name]) = LOWER(@name)

end
