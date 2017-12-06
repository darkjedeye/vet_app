CREATE TABLE [dbo].[Entity_StoreProductProperty] (
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    [PropertyId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Entity_StoreProductProperty] PRIMARY KEY CLUSTERED ([ProductId] ASC, [PropertyId] ASC),
    CONSTRAINT [FK_EntityStoreProduct_Id___EntityStoreProductProperty_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Entity_StoreProduct] ([Id]),
    CONSTRAINT [FK_EntityStoreProperty_Id___EntityStoreProductProperty_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[Entity_StoreProperty] ([Id])
);

