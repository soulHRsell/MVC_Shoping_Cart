CREATE PROCEDURE [dbo].[SP_SearchProducts]
    @Name NVARCHAR(100) = NULL,
    @CategoryId INT = NULL,
    @MinPrice DECIMAL(10,2) = NULL,
    @MaxPrice DECIMAL(10,2) = NULL
AS
BEGIN

    SET NOCOUNT ON;

    SELECT p.Id, p.[Name], p.Amount, p.Info, p.Price, p.CategoryId
    FROM Product p
    INNER JOIN Category c ON p.CategoryId = c.Id
    WHERE 
        (@Name IS NULL OR Lower(p.[Name]) LIKE '%' + Lower(@Name) + '%')
        AND (@CategoryId IS NULL OR p.CategoryId = @CategoryId)
        AND (@MinPrice IS NULL OR p.Price >= @MinPrice)
        AND (@MaxPrice IS NULL OR p.Price <= @MaxPrice)
    ORDER BY p.Name ASC;
END
