CREATE TABLE [dbo].[Enum_EventAttendeeType] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Enum_EventAttendeeType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

