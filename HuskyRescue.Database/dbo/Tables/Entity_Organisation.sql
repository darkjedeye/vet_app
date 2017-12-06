CREATE TABLE [dbo].[Entity_Organisation] (
    [ID]           UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Organisation_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [BaseID]       UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Business_ID] DEFAULT (newid()) NOT NULL,
    [BusinessName] NVARCHAR (50)    NOT NULL,
    [ContactName]  NVARCHAR (50)    NULL,
    [ContactTitle] NVARCHAR (30)    NULL,
    [EIN]          NCHAR (10)       NULL,
    [Type]         CHAR (3)         NULL,
    [Description]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Entity_Organisation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Entity_Business_Entity_Base] FOREIGN KEY ([BaseID]) REFERENCES [dbo].[Entity_Base] ([ID]),
    CONSTRAINT [FK_Entity_Business_Enum_BusinessType] FOREIGN KEY ([Type]) REFERENCES [dbo].[Enum_OrganisationType] ([ID])
);

