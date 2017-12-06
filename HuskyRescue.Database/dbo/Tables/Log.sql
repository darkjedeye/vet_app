CREATE TABLE [dbo].[Log] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [IsVisible]        BIT              NULL,
    [UpdatedByUserId]  UNIQUEIDENTIFIER NULL,
    [UpdatedTimeStam]  DATETIME         NULL,
    [TimeStamp]        DATETIME         NOT NULL,
    [Level]            NVARCHAR (5)     NOT NULL,
    [Logger]           NVARCHAR (200)   NOT NULL,
    [Message]          NVARCHAR (MAX)   NOT NULL,
    [ExceptionType]    NVARCHAR (MAX)   NULL,
    [Operation]        NVARCHAR (MAX)   NULL,
    [ExceptionMessage] NVARCHAR (MAX)   NULL,
    [StackTrace]       NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);

