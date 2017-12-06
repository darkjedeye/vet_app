CREATE TABLE [dbo].[Event_Registration] (
    [ID]                   UNIQUEIDENTIFIER CONSTRAINT [DF_Event_Registration_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [EventID]              UNIQUEIDENTIFIER NOT NULL,
    [DateSubmitted]        DATE             NOT NULL,
    [HasPaid]              BIT              NULL,
    [PaymentMethod]        INT              NULL,
    [PaymentTransactionId] NVARCHAR (50)    NULL,
    [Comments]             NVARCHAR (MAX)   NULL,
    [AmountPaid]           MONEY            NULL,
    [TicketsBought]        INT              NULL,
    CONSTRAINT [PK_Event_Registration] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Events_id___EventRegistration_eventID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID])
);



