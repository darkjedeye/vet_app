CREATE TABLE [dbo].[Enum_LogActivityEventType] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (15) NULL,
    CONSTRAINT [PK_Enum_LogActivityEventType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

