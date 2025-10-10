CREATE TABLE [dbo].[Category] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [AdminId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Category_Admin] FOREIGN KEY ([AdminId]) REFERENCES [User]([ID])
);

