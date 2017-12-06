CREATE TABLE [dbo].[Entity_StoreShippingMethod] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreShippingMethod_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name]          NVARCHAR (50)    NOT NULL,
    [CreatedOn]     DATETIME2 (0)    NOT NULL,
    [CreatedByUser] NVARCHAR (50)    NOT NULL,
    [UpdatedOn]     DATETIME2 (0)    NOT NULL,
    [UpdatedByUser] NVARCHAR (50)    NOT NULL,
    [DeletedOn]     DATETIME2 (0)    NULL,
    [DeletedByUser] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Entity_StoreShippingMethod] PRIMARY KEY CLUSTERED ([Id] ASC)
);

