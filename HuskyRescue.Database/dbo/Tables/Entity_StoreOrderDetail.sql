CREATE TABLE [dbo].[Entity_StoreOrderDetail] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [OrderId]          UNIQUEIDENTIFIER NOT NULL,
    [ProductVariantId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]         INT              NOT NULL,
    [Price]            MONEY            NOT NULL,
    CONSTRAINT [PK_Entity_StoreOrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC, [OrderId] ASC),
    CONSTRAINT [FK_EntityStoreOrder_Id___EntityStoreOrderDetail_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Entity_StoreOrder] ([Id]),
    CONSTRAINT [FK_EntityStoreProductVariant_Id___EntityStoreOrderDetail_ProductVariantId] FOREIGN KEY ([ProductVariantId]) REFERENCES [dbo].[Entity_StoreProductVariant] ([Id])
);





