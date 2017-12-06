CREATE TABLE [dbo].[Enum_OrganisationServices] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (2000) NOT NULL,
    [Cost]        MONEY           NULL,
    CONSTRAINT [PK_Enum_OrganisationServices] PRIMARY KEY CLUSTERED ([ID] ASC)
);

