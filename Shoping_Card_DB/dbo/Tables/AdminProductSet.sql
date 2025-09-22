CREATE TABLE [dbo].[AdminProductSet] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [ProductSetDate] DATETIME2 (7) NOT NULL,
    [AdminId]        INT           NOT NULL,
    [ProductId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AdminProductSet_Admin] FOREIGN KEY ([AdminId]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_AdminProductSet_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ID])
);

