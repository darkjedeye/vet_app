CREATE TABLE [dbo].[Entity_StoreOptionValueProductVariant] (
    [ProductVariantId] UNIQUEIDENTIFIER NOT NULL,
    [OptionValueId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Entity_StoreOptionValueProductVariant] PRIMARY KEY CLUSTERED ([ProductVariantId] ASC, [OptionValueId] ASC),
    CONSTRAINT [FK_EntityStoreOptionValue_Id___EntityStoreOptionValueProductVariant_OptionValueId] FOREIGN KEY ([OptionValueId]) REFERENCES [dbo].[Entity_StoreOptionValue] ([Id]),
    CONSTRAINT [FK_EntityStoreProductVariant_Id___EntityStoreOptionValueProductVariant_ProductVariantId] FOREIGN KEY ([ProductVariantId]) REFERENCES [dbo].[Entity_StoreProductVariant] ([Id])
);



