CREATE TABLE [dbo].[Event_SponsorshipLevelTypes] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [SponsorAmount] MONEY          NULL,
    CONSTRAINT [PK_Event_SponsorshipLevelTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

