CREATE TABLE [dbo].[Entity_StoreProductVariant] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StorePorductVariant_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [ProductId]     UNIQUEIDENTIFIER NOT NULL,
    [IsActive]      BIT              NOT NULL,
    [Quantity]      INT              NOT NULL,
    [Price]         MONEY            NOT NULL,
    [CostPrice]     MONEY            NOT NULL,
    [Weight]        DECIMAL (8, 2)   NOT NULL,
    [ShippingCost]  MONEY            NULL,
    [CreatedOn]     DATETIME2 (0)    NOT NULL,
    [CreatedByUser] NVARCHAR (50)    NOT NULL,
    [UpdatedOn]     DATETIME2 (0)    NOT NULL,
    [UpdatedByUser] NVARCHAR (50)    NOT NULL,
    [DeletedOn]     DATETIME2 (0)    NULL,
    [DeletedByUser] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Entity_StorePorductVariant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityStoreProduct_Id___EntityStoreProductVariant_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Entity_StoreProduct] ([Id])
);

