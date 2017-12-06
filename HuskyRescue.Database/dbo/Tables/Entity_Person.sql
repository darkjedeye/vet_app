CREATE TABLE [dbo].[Entity_Person] (
    [ID]            UNIQUEIDENTIFIER CONSTRAINT [DF_Entity_Person_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [BaseID]        UNIQUEIDENTIFIER NOT NULL,
    [FirstName]     NVARCHAR (50)    NOT NULL,
    [LastName]      NVARCHAR (50)    NULL,
    [Gender]        CHAR (3)         NULL,
    [LicenseNumber] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Entity_Person] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Entity_Person_Entity_Base] FOREIGN KEY ([BaseID]) REFERENCES [dbo].[Entity_Base] ([ID]),
    CONSTRAINT [FK_Entity_Person_Enum_Gender] FOREIGN KEY ([Gender]) REFERENCES [dbo].[Enum_Gender] ([ID])
);

