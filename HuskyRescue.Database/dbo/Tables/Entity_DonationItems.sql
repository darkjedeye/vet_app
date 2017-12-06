CREATE TABLE [dbo].[Entity_DonationItems] (
    [ID]               UNIQUEIDENTIFIER CONSTRAINT [DF_Event_DonationItems_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [PersonID]         UNIQUEIDENTIFIER NULL,
    [OrganisationID]   UNIQUEIDENTIFIER NULL,
    [Quantity]         INT              NOT NULL,
    [Name]             NVARCHAR (500)   NOT NULL,
    [CostPerItem]      MONEY            NULL,
    [DonationItemType] INT              NOT NULL,
    [HasBeenReceived]  BIT              NOT NULL,
    [DateReceived]     DATE             NULL,
    [EventID]          UNIQUEIDENTIFIER NULL,
    [EventPurposeID]   INT              NULL,
    CONSTRAINT [PK_Event_DonationItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EnumDonationItemType_ID___EventDonationItems_DonationItemType] FOREIGN KEY ([DonationItemType]) REFERENCES [dbo].[Enum_DonationItemType] ([ID]),
    CONSTRAINT [FK_EnumEventDonationPurpose_ID__EntityDonationItems_EventPurposeID] FOREIGN KEY ([EventPurposeID]) REFERENCES [dbo].[Enum_EventDonationPurpose] ([ID]),
    CONSTRAINT [FK_EventDonationItems_OrganisationID__EntityOrganisation_ID] FOREIGN KEY ([OrganisationID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_EventDonationItems_PersonID__EntityPerson_ID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID]),
    CONSTRAINT [FK_Events_ID___EntityDonationItems_EventID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID])
);

