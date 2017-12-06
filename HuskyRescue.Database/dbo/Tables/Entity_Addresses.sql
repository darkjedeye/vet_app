CREATE TABLE [dbo].[Entity_Addresses] (
    [ID]       UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Addresses_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Street]   NVARCHAR (80)    NOT NULL,
    [Street2]  NVARCHAR (80)    NULL,
    [City]     NVARCHAR (50)    NOT NULL,
    [StateID]  CHAR (2)         NOT NULL,
    [ZIP]      NVARCHAR (10)    NOT NULL,
    [Type]     CHAR (3)         NOT NULL,
    [EntityID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Entity_Addresses] PRIMARY KEY CLUSTERED ([ID] ASC, [EntityID] ASC),
    CONSTRAINT [FK_Entity_Addresses_Entity_Base] FOREIGN KEY ([EntityID]) REFERENCES [dbo].[Entity_Base] ([ID]),
    CONSTRAINT [FK_Entity_Addresses_Enum_UsaStates] FOREIGN KEY ([StateID]) REFERENCES [dbo].[Enum_UsaStates] ([ID]),
    CONSTRAINT [FK_Enum_AddressType_Entity_Addresses] FOREIGN KEY ([Type]) REFERENCES [dbo].[Enum_AddressType] ([ID])
);



