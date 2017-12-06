CREATE TABLE [dbo].[Entity_File] (
    [ID]          UNIQUEIDENTIFIER   CONSTRAINT [DF_Entity_File_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [PersonID]    UNIQUEIDENTIFIER   NULL,
    [OrgID]       UNIQUEIDENTIFIER   NULL,
    [DogID]       UNIQUEIDENTIFIER   NULL,
    [DateCreated] DATETIMEOFFSET (7) NOT NULL,
    [ContentType] NVARCHAR (100)     NOT NULL,
    [ServerPath]  NVARCHAR (2000)    NOT NULL,
    CONSTRAINT [PK_Entity_File] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityDog_ID__EntityFile_DogID] FOREIGN KEY ([DogID]) REFERENCES [dbo].[Entity_Dog] ([ID]),
    CONSTRAINT [FK_EntityOrganisation_ID_EntityFile_OrgID] FOREIGN KEY ([OrgID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_EntityPerson_ID__EntityFile_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'image/jpeg, application/msword, etc', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Entity_File', @level2type = N'COLUMN', @level2name = N'ContentType';

