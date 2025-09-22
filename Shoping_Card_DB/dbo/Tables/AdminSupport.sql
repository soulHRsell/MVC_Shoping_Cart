CREATE TABLE [dbo].[AdminSupport] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [SupportDate] DATETIME2 (7) NOT NULL,
    [AdminId]     INT           NOT NULL,
    [UserId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AdminSupport_Admin] FOREIGN KEY ([AdminId]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_AdminSupport_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([ID])
);

