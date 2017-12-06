CREATE TABLE [dbo].[Entity_StoreOptionType] (
    [Id]   UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProductOptionType_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Entity_StoreProductOption] PRIMARY KEY CLUSTERED ([Id] ASC)
);

