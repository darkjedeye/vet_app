CREATE TABLE [dbo].[Enum_PhoneType] (
    [ID]    CHAR (3)      NOT NULL,
    [Value] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Enum_PhoneType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

