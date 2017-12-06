CREATE TABLE [dbo].[Entity_StoreOrder] (
    [Id]                  UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreOrder_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [UserName]            NVARCHAR (50)    NULL,
    [TotalProducts]       INT              NOT NULL,
    [TotalDue]            MONEY            NOT NULL,
    [CreatedOn]           DATETIME2 (0)    NOT NULL,
    [UpdatedOn]           DATETIME2 (0)    NOT NULL,
    [CompletedOn]         DATETIME2 (0)    NULL,
    [Status]              NVARCHAR (50)    NOT NULL,
    [ShippingStatus]      NVARCHAR (50)    NOT NULL,
    [PersonBaseId]        UNIQUEIDENTIFIER NULL,
    [BillingAddressId]    UNIQUEIDENTIFIER NULL,
    [ShippingAddressId]   UNIQUEIDENTIFIER NULL,
    [SpecialInstructions] NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_Entity_StoreOrder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityAddresses_Id___EntityStoreOrder_BillingAddressId] FOREIGN KEY ([BillingAddressId], [PersonBaseId]) REFERENCES [dbo].[Entity_Addresses] ([ID], [EntityID]),
    CONSTRAINT [FK_EntityAddresses_Id___EntityStoreOrder_ShippingAddressId] FOREIGN KEY ([ShippingAddressId], [PersonBaseId]) REFERENCES [dbo].[Entity_Addresses] ([ID], [EntityID]),
    CONSTRAINT [FK_EntityBase_Id___EntityStoreOrder_PersonBaseId] FOREIGN KEY ([PersonBaseId]) REFERENCES [dbo].[Entity_Base] ([ID])
);









