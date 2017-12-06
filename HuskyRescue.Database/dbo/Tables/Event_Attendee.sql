CREATE TABLE [dbo].[Event_Attendee] (
    [ID]                  UNIQUEIDENTIFIER CONSTRAINT [DF_Event_Attendee_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [EventRegistrationID] UNIQUEIDENTIFIER NOT NULL,
    [PersonID]            UNIQUEIDENTIFIER NULL,
    [IsPrimaryContact]    BIT              NULL,
    [AttendeeType]        INT              NOT NULL,
    CONSTRAINT [PK_Event_Attendee] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EntityPerson_ID__EventAttendee_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID]),
    CONSTRAINT [FK_EnumEventAttendeeType_id___EventAttendee_attendeeType] FOREIGN KEY ([AttendeeType]) REFERENCES [dbo].[Enum_EventAttendeeType] ([ID]),
    CONSTRAINT [FK_EventRegistration_id___EventAttendee_eventRegistrationID] FOREIGN KEY ([EventRegistrationID]) REFERENCES [dbo].[Event_Registration] ([ID])
);

