CREATE TABLE [dbo].[Entity_PersonProfile] (
    [UserID]         UNIQUEIDENTIFIER NOT NULL,
    [EntityPersonID] UNIQUEIDENTIFIER NULL,
    [IsActive]       BIT              NOT NULL,
    [Name]           NVARCHAR (255)   NOT NULL,
    [Email]          NVARCHAR (255)   NOT NULL,
    [Website]        NVARCHAR (255)   NULL,
    [Phone]          NVARCHAR (20)    NULL,
    CONSTRAINT [PK_Entity_PersonProfile] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_EntityPerson_ID__EntityPersonProfile_EntityPersonID] FOREIGN KEY ([EntityPersonID]) REFERENCES [dbo].[Entity_Person] ([ID])
);



