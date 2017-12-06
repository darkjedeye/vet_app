CREATE TABLE [dbo].[Events] (
    [ID]             UNIQUEIDENTIFIER CONSTRAINT [DF_Event_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [OrganisationID] UNIQUEIDENTIFIER NULL,
    [DateOfEvent]    DATE             NULL,
    [IsActive]       BIT              NOT NULL,
    [Type]           CHAR (3)         NOT NULL,
    [AmountSpent]    MONEY            NULL,
    [AmountReceived] MONEY            NULL,
    [Name]           NVARCHAR (255)   NOT NULL,
    [Purpose]        NVARCHAR (MAX)   NULL,
    [Results]        NVARCHAR (MAX)   NULL,
    [Description]    NVARCHAR (MAX)   NULL,
    [StartTime]      DATETIME         NULL,
    [EndTime]        DATETIME         NULL,
    [IsAllDay]       BIT              NULL,
    [IsTicketsSold]  BIT              NULL,
    [TicketPrice]    MONEY            NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityOrg_id___Events_orgID] FOREIGN KEY ([OrganisationID]) REFERENCES [dbo].[Entity_Organisation] ([ID]),
    CONSTRAINT [FK_Event_type___EnumEventType_id] FOREIGN KEY ([Type]) REFERENCES [dbo].[Enum_EventType] ([ID])
);



