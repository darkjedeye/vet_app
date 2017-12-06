CREATE TABLE [dbo].[Entity_Donation] (
    [Id]                   UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Donation_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [DateSubmitted]        DATETIME2 (7)    NOT NULL,
    [BaseId]               UNIQUEIDENTIFIER NOT NULL,
    [BaseType]             NCHAR (3)        NOT NULL,
    [Amount]               MONEY            NOT NULL,
    [PaymentTransactionId] NVARCHAR (50)    NOT NULL,
    [DonorComments]        NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Entity_Donation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityBase_ID___EntityDonation_BaseId] FOREIGN KEY ([BaseId]) REFERENCES [dbo].[Entity_Base] ([ID])
);

