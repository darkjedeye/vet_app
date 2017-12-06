CREATE TABLE [dbo].[Entity_EmailAddress] (
    [ID]       INT              IDENTITY (1, 1) NOT NULL,
    [EntityID] UNIQUEIDENTIFIER NOT NULL,
    [Address]  NVARCHAR (200)   NOT NULL,
    [Type]     CHAR (3)         NOT NULL,
    CONSTRAINT [PK_Entity_EmailAddresses] PRIMARY KEY CLUSTERED ([ID] ASC, [EntityID] ASC),
    CONSTRAINT [Email_Entity] FOREIGN KEY ([EntityID]) REFERENCES [dbo].[Entity_Base] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Entity_EmailAddress_Enum_EmailType] FOREIGN KEY ([Type]) REFERENCES [dbo].[Enum_EmailType] ([ID])
);

