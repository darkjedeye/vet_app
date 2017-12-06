CREATE TABLE [dbo].[Enum_EntityType] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Enum_EntityType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

