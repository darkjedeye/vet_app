CREATE TABLE [dbo].[LogUserActivity] (
    [ID]           INT              IDENTITY (1, 1) NOT NULL,
    [TimeStamp]    DATETIME2 (7)    NOT NULL,
    [UserID]       UNIQUEIDENTIFIER NOT NULL,
    [EventTypeID]  INT              NOT NULL,
    [EntityTypeID] INT              NULL,
    [Note]         NVARCHAR (500)   NULL,
    CONSTRAINT [PK_LogUserActivity] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EnumEntityType_ID__LogUserActivity_EntityTypeID] FOREIGN KEY ([EntityTypeID]) REFERENCES [dbo].[Enum_EntityType] ([ID]),
    CONSTRAINT [FK_EnumLogActivityEventType_ID__LogUserActivity_EventTypeID] FOREIGN KEY ([EventTypeID]) REFERENCES [dbo].[Enum_LogActivityEventType] ([ID])
);



