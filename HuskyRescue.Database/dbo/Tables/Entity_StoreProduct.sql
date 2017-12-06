CREATE TABLE [dbo].[Entity_StoreProduct] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProduct_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IsActive]      BIT              NOT NULL,
    [CategoryId]    UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [CreatedOn]     DATETIME2 (0)    NOT NULL,
    [CreatedByUser] NVARCHAR (50)    NOT NULL,
    [UpdatedOn]     DATETIME2 (0)    NOT NULL,
    [UpdatedByUser] NVARCHAR (50)    NOT NULL,
    [DeletedOn]     DATETIME2 (0)    NULL,
    [DeletedByUser] NVARCHAR (50)    NULL,
    [Description]   NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_Entity_StoreProduct] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityStoreCategory_Id___EntityStoreProduct_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Entity_StoreCategory] ([Id])
);















