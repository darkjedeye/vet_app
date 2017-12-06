CREATE TABLE [dbo].[Entity_Base] (
    [ID]           UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Base_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Type]         NCHAR (3)        NOT NULL,
    [IsActive]     BIT              NOT NULL,
    [DateActive]   DATE             NULL,
    [DateInActive] DATE             NULL,
    [IsDeleted]    BIT              NOT NULL,
    [Comments]     NVARCHAR (MAX)   NULL,
    [IsMailable]   BIT              NOT NULL,
    [IsEmailable]  BIT              NOT NULL,
    [WebsiteUrl]   NVARCHAR (200)   NULL,
    CONSTRAINT [PK__Entity_B__3214EC2717036CC0] PRIMARY KEY CLUSTERED ([ID] ASC)
);

