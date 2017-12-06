CREATE TABLE [dbo].[Entity_StoreShipment] (
    [Id]               UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreShipment_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [OrderId]          UNIQUEIDENTIFIER NOT NULL,
    [ShippingMethodId] UNIQUEIDENTIFIER NOT NULL,
    [Status]           NVARCHAR (50)    NOT NULL,
    [Cost]             MONEY            NOT NULL,
    [CreatedOn]        DATETIME2 (0)    NOT NULL,
    [UpdatedOn]        DATETIME2 (0)    NOT NULL,
    [UpdatedByUser]    NVARCHAR (50)    NOT NULL,
    [ShippedOn]        DATETIME2 (0)    NULL,
    [ShippedByUser]    NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Entity_StoreShipment] PRIMARY KEY CLUSTERED ([Id] ASC, [OrderId] ASC),
    CONSTRAINT [FK_EntityStoreOrder_Id___EntityStoreShipment_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Entity_StoreOrder] ([Id]),
    CONSTRAINT [FK_EntityStoreShippingMethod_Id___EntityStoreShipment_ShippingMethodId] FOREIGN KEY ([ShippingMethodId]) REFERENCES [dbo].[Entity_StoreShippingMethod] ([Id])
);



