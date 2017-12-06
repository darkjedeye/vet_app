CREATE TABLE [dbo].[Entity_StoreProperty] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_StoreProperty_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IsPublic] BIT              NOT NULL,
    [Name]     NVARCHAR (50)    NOT NULL,
    [Value]    NVARCHAR (256)   NOT NULL,
    CONSTRAINT [PK_Entity_StoreProperty] PRIMARY KEY CLUSTERED ([Id] ASC)
);



