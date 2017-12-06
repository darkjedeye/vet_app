CREATE TABLE [dbo].[Entity_StorePayment] (
    [Id]                   UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StorePayment_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [OrderId]              UNIQUEIDENTIFIER NOT NULL,
    [Amount]               MONEY            NOT NULL,
    [PaymentMethodId]      UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]            DATETIME2 (0)    NOT NULL,
    [UpdatedOn]            DATETIME2 (0)    NOT NULL,
    [Status]               NVARCHAR (50)    NOT NULL,
    [GatewayTransactionId] NVARCHAR (50)    NULL,
    [ResponseCode]         NVARCHAR (50)    NOT NULL,
    [ResponseText]         NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_Entity_StorePayment_1] PRIMARY KEY CLUSTERED ([Id] ASC, [OrderId] ASC),
    CONSTRAINT [FK_EntityStoreOrder_Id___EntityStorePayment_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Entity_StoreOrder] ([Id]),
    CONSTRAINT [FK_EntityStorePaymentMethod_Id___EntityStorePayment_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[Entity_StorePaymentMethod] ([Id])
);



