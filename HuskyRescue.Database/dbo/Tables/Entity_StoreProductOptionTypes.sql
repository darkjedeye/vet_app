CREATE TABLE [dbo].[Entity_StoreProductOptionTypes] (
    [ProductId]    UNIQUEIDENTIFIER NOT NULL,
    [OptionTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Entity_StoreProductOptionTypes] PRIMARY KEY CLUSTERED ([ProductId] ASC, [OptionTypeId] ASC),
    CONSTRAINT [FK_EntityStoreOptionType_Id___EntityStoreProductOptionTypes_OptionTypeId] FOREIGN KEY ([OptionTypeId]) REFERENCES [dbo].[Entity_StoreOptionType] ([Id]),
    CONSTRAINT [FK_EntityStoreProduct_Id___EntityStoreProductOptionTypes_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Entity_StoreProduct] ([Id])
);

