CREATE TABLE [dbo].[Entity_PhoneNumber] (
    [ID]       INT              IDENTITY (1, 1) NOT NULL,
    [EntityID] UNIQUEIDENTIFIER NOT NULL,
    [Number]   NVARCHAR (15)    NOT NULL,
    [Type]     CHAR (3)         NOT NULL,
    CONSTRAINT [PK_Entity_PhoneNumber] PRIMARY KEY CLUSTERED ([ID] ASC, [EntityID] ASC),
    CONSTRAINT [Entity_PhoneNumbers] FOREIGN KEY ([EntityID]) REFERENCES [dbo].[Entity_Base] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Entity_PhoneNumber_Enum_PhoneType] FOREIGN KEY ([Type]) REFERENCES [dbo].[Enum_PhoneType] ([ID])
);

