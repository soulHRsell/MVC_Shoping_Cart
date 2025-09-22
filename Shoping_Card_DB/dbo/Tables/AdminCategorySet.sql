CREATE TABLE [dbo].[AdminCategorySet] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [CategorySetDate] DATETIME2 (7) NOT NULL,
    [AdminId]         INT           NOT NULL,
    [CategoryId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AdminCategorySet_Admin] FOREIGN KEY ([AdminId]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_AdminCategorySet_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([ID])
);

