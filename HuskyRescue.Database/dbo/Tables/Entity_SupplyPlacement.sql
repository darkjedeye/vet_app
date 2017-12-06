CREATE TABLE [dbo].[Entity_SupplyPlacement] (
    [ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_SupplyPlacement_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [SupplyID]   UNIQUEIDENTIFIER NOT NULL,
    [DateIn]     DATE             NOT NULL,
    [DateOut]    DATE             NULL,
    [Status]     INT              NULL,
    [LocationID] UNIQUEIDENTIFIER NOT NULL,
    [Notes]      NVARCHAR (3000)  NULL,
    CONSTRAINT [PK_Entity_SupplyPlacement] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityBase_ID__EntitySupplyPlacement_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Entity_Base] ([ID]),
    CONSTRAINT [FK_EntitySupplies_ID__EntitySupplyPlacement_SupplyID] FOREIGN KEY ([SupplyID]) REFERENCES [dbo].[Entity_Supplies] ([ID]),
    CONSTRAINT [FK_EnumSupplyPlacementType_ID__EntitySupplyPlacement_Status] FOREIGN KEY ([Status]) REFERENCES [dbo].[Enum_SupplyPlacementType] ([ID])
);

