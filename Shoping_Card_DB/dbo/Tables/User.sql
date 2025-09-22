CREATE TABLE [dbo].[User] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Username]     VARCHAR (50)  NOT NULL,
    [Password]     VARCHAR (100) NOT NULL,
    [EmailAddress] VARCHAR (100) NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [LastName]     VARCHAR (50)  NOT NULL,
    [AddressId]    INT           NULL,
    [CreditCardId] INT           NULL,
    [isAdmin]      BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([ID]),
    CONSTRAINT [FK_User_CreditCard] FOREIGN KEY ([CreditCardId]) REFERENCES [dbo].[CreditCard] ([ID])
);

