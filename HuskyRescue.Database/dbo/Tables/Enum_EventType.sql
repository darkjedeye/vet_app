CREATE TABLE [dbo].[Enum_EventType] (
    [ID]    CHAR (3)      NOT NULL,
    [Value] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Enum_EventType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

