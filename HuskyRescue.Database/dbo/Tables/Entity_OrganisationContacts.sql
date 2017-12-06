CREATE TABLE [dbo].[Entity_OrganisationContacts] (
    [OrganisationID] UNIQUEIDENTIFIER NOT NULL,
    [PersonID]       UNIQUEIDENTIFIER NOT NULL,
    [RoleID]         INT              NOT NULL,
    CONSTRAINT [PK_Entity_OrganisationContacts] PRIMARY KEY CLUSTERED ([OrganisationID] ASC, [PersonID] ASC, [RoleID] ASC),
    CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationContacts_orgID] FOREIGN KEY ([OrganisationID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_EntityPerson_ID__EntityOrganisationContacts_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID]),
    CONSTRAINT [FK_EnumOrganisationRoles_id___EntityOrganisationContacts_roleID] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Enum_OrganisationRoles] ([ID])
);



