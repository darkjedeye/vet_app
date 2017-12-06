CREATE TABLE [dbo].[Entity_StoreOptionValue] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProductOptionValue_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [OptionId] UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProductOptionValue_OptionId] DEFAULT (newid()) NOT NULL,
    [Value]    NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Entity_StoreProductOptionItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityStoreOption_Id___EntityStoreOptionItem_OptionId] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Entity_StoreOptionType] ([Id])
);

