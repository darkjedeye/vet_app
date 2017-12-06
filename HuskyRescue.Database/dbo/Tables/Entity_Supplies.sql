CREATE TABLE [dbo].[Entity_Supplies] (
    [ID]                  UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Supplies_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [SupplyType]          INT              NOT NULL,
    [IsActive]            BIT              NOT NULL,
    [IsDeleted]           BIT              NOT NULL,
    [LastUpdateTimestamp] DATETIME         NOT NULL,
    [Notes]               NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_Entity_Supplies] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntitySupplyType_ID__EntitySupplies_SupplyType] FOREIGN KEY ([SupplyType]) REFERENCES [dbo].[Entity_SupplyType] ([ID])
);

