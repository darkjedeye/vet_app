CREATE TABLE [dbo].[Blog_TagsMapped] (
    [PostID] UNIQUEIDENTIFIER NOT NULL,
    [TagID]  INT              NOT NULL,
    CONSTRAINT [PK_Blog_TagsMapped] PRIMARY KEY CLUSTERED ([PostID] ASC, [TagID] ASC),
    CONSTRAINT [FK_BlogPost_ID__BlogTagsMapped_PostID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Blog_Post] ([ID]),
    CONSTRAINT [FK_BlogTags_ID__BlogTagsMapped_TagID] FOREIGN KEY ([TagID]) REFERENCES [dbo].[Blog_Tags] ([ID])
);

