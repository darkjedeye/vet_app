CREATE TABLE [dbo].[Entity_StorePaymentMethod] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StorePaymentMethod_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IsActive]      BIT              NOT NULL,
    [Name]          NVARCHAR (50)    NOT NULL,
    [Description]   NVARCHAR (1000)  NOT NULL,
    [CreatedOn]     DATETIME2 (0)    NOT NULL,
    [CreatedByUser] NVARCHAR (50)    NOT NULL,
    [UpdatedOn]     DATETIME2 (0)    NOT NULL,
    [UpdatedByUser] NVARCHAR (50)    NOT NULL,
    [DeletedOn]     DATETIME2 (0)    NULL,
    [DeletedByUser] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Entity_StorePaymentMethod] PRIMARY KEY CLUSTERED ([Id] ASC)
);

