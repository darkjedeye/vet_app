CREATE TABLE [dbo].[Entity_DogPlacement] (
    [ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_DogPlacement_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [DogID]      UNIQUEIDENTIFIER NOT NULL,
    [LocationID] UNIQUEIDENTIFIER NOT NULL,
    [DateIn]     DATE             NULL,
    [DateOut]    DATE             NOT NULL,
    [Status]     INT              NOT NULL,
    [Comments]   NVARCHAR (3000)  NULL,
    CONSTRAINT [PK_Entity_DogPlacement] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityBase_ID__EntityDogPlacement_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Entity_Base] ([ID]),
    CONSTRAINT [FK_EntityDog_ID__EntityDogPlacement_DogID] FOREIGN KEY ([DogID]) REFERENCES [dbo].[Entity_Dog] ([ID]),
    CONSTRAINT [FK_EnumDogPlacementType_ID__EntityDogPlacement_Status] FOREIGN KEY ([Status]) REFERENCES [dbo].[Enum_DogPlacementType] ([ID])
);

