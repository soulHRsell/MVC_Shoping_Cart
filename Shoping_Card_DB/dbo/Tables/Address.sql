CREATE TABLE [dbo].[Address] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Country] NVARCHAR (50) NOT NULL,
    [State]   NVARCHAR (50) NOT NULL,
    [City]    NVARCHAR (50) NOT NULL,
    [ZipCode] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

