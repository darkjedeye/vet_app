CREATE TABLE [dbo].[Entity_SupplyType] (
    [ID]         INT             NOT NULL,
    [Name]       NVARCHAR (200)  NOT NULL,
    [ProductUrl] NVARCHAR (500)  NULL,
    [Cost]       MONEY           NULL,
    [Notes]      NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Entity_SupplyType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

