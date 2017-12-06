CREATE TABLE [dbo].[Enum_OrganisationRoles] (
    [ID]          INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NULL,
    CONSTRAINT [PK_Enum_OrganisationRoles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

