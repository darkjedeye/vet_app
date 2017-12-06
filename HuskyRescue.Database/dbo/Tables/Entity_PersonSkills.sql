CREATE TABLE [dbo].[Entity_PersonSkills] (
    [PersonID]  UNIQUEIDENTIFIER NOT NULL,
    [SkillCode] NVARCHAR (4)     NOT NULL,
    CONSTRAINT [PK_Entity_PersonSkills] PRIMARY KEY CLUSTERED ([PersonID] ASC, [SkillCode] ASC),
    CONSTRAINT [FK_EntityPerson_ID__EntityPersonSkills_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID]),
    CONSTRAINT [FK_EnumSkills_id___EntityPersonSkills_skillCode] FOREIGN KEY ([SkillCode]) REFERENCES [dbo].[Enum_Skills] ([ID])
);

