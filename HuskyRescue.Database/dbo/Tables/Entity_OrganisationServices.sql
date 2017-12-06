CREATE TABLE [dbo].[Entity_OrganisationServices] (
    [OrganisationID] UNIQUEIDENTIFIER NOT NULL,
    [ServiceID]      INT              NOT NULL,
    CONSTRAINT [PK_Entity_OrganisationServices] PRIMARY KEY CLUSTERED ([OrganisationID] ASC, [ServiceID] ASC),
    CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationServices_orgID] FOREIGN KEY ([OrganisationID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_EnumOrganisationServices_id___EntityOrganisationServices_serviceID] FOREIGN KEY ([ServiceID]) REFERENCES [dbo].[Enum_OrganisationServices] ([ID])
);

