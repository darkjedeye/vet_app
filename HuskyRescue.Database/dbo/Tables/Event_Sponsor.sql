CREATE TABLE [dbo].[Event_Sponsor] (
    [ID]                  UNIQUEIDENTIFIER CONSTRAINT [DF_Event_Sponsor_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [EventID]             UNIQUEIDENTIFIER NOT NULL,
    [DateAdded]           DATE             NOT NULL,
    [IsSponsoring]        BIT              NOT NULL,
    [SponsorshipLevel]    INT              NULL,
    [IsDonating]          BIT              NOT NULL,
    [DonationAmount]      MONEY            NULL,
    [IsDonationRecieved]  BIT              NOT NULL,
    [OrganisationID]      UNIQUEIDENTIFIER NULL,
    [PersonID]            UNIQUEIDENTIFIER NULL,
    [IsSingageComplete]   BIT              NOT NULL,
    [Comments]            NVARCHAR (MAX)   NULL,
    [HasLogoBeenReceived] BIT              NOT NULL,
    [WebsiteUrl]          NVARCHAR (200)   NULL,
    CONSTRAINT [PK_Event_Sponsor] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityOrganisation_ID___EventSponsor_OrganisationID] FOREIGN KEY ([OrganisationID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_EntityPerson_ID__EventSponsor_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID]),
    CONSTRAINT [FK_Events_ID___EventSponsor_EventID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID])
);

