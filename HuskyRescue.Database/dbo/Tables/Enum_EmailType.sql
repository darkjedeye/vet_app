CREATE TABLE [dbo].[Enum_EmailType] (
    [ID]    CHAR (3)      NOT NULL,
    [Value] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Enum_EmailType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

