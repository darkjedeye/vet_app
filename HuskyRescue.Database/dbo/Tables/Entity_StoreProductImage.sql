CREATE TABLE [dbo].[Entity_StoreProductImage] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProductImage_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [ProductId]   UNIQUEIDENTIFIER NOT NULL,
    [Path]        NVARCHAR (500)   NOT NULL,
    [Description] NVARCHAR (500)   NULL,
    CONSTRAINT [PK_Entity_StoreProductImage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityStoreProduct_Id___EntityStoreProductImage_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Entity_StoreProduct] ([Id])
);

