CREATE TABLE [dbo].[Entity_StoreCartItem] (
    [CartId]           UNIQUEIDENTIFIER NOT NULL,
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [ProductVariantId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]         INT              NOT NULL,
    CONSTRAINT [PK_Entity_StoreCartItem] PRIMARY KEY CLUSTERED ([CartId] ASC, [Id] ASC),
    CONSTRAINT [FK_EntityStoreCart_Id__EntityStoreCartItem_CartId] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Entity_StoreCart] ([Id]),
    CONSTRAINT [FK_EntityStoreProductVariant_Id___EntityStoreCartItem_ProductVariantId] FOREIGN KEY ([ProductVariantId]) REFERENCES [dbo].[Entity_StoreProductVariant] ([Id])
);





