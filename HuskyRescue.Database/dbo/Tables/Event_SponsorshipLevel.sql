CREATE TABLE [dbo].[Event_SponsorshipLevel] (
    [ID]                   INT              IDENTITY (1, 1) NOT NULL,
    [SponsorID]            UNIQUEIDENTIFIER NOT NULL,
    [SponsorshipLevelType] INT              NOT NULL,
    CONSTRAINT [PK_Event_SponsorshipLevels] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EventSponsor_ID__EventSponsorshipLevel_SponsorID] FOREIGN KEY ([SponsorID]) REFERENCES [dbo].[Event_Sponsor] ([ID]),
    CONSTRAINT [FK_EventSponsorshipLevelTypes_ID__EventSponsorshipLevel_SponsorshipLevelType] FOREIGN KEY ([SponsorshipLevelType]) REFERENCES [dbo].[Event_SponsorshipLevelTypes] ([ID])
);

