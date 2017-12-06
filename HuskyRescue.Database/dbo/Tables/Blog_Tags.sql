CREATE TABLE [dbo].[Blog_Tags] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Blog_Tags] PRIMARY KEY CLUSTERED ([ID] ASC)
);

