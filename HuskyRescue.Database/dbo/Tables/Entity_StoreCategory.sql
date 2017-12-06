CREATE TABLE [dbo].[Entity_StoreCategory] (
    [Id]              UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreCategory_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name]            NVARCHAR (100)   NOT NULL,
    [Description]     NVARCHAR (1000)  NOT NULL,
    [BannerImageLink] NVARCHAR (500)   NULL,
    CONSTRAINT [PK_Entity_StoreCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

