CREATE TABLE [dbo].[Entity_StoreCart] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreCart_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [UserName]  NVARCHAR (50)    NULL,
    [CreatedOn] DATETIME2 (0)    NOT NULL,
    [UodatedOn] DATETIME2 (0)    NOT NULL,
    CONSTRAINT [PK_Entity_StoreCart_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);







