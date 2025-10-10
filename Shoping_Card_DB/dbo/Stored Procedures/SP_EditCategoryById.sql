CREATE PROCEDURE [dbo].[SP_EditCategoryById]
	@Id int,
	@name nvarchar(50)
AS
begin
	
	set nocount on

	Update Category
	set [Name] = @name
	where ID = @Id

end
