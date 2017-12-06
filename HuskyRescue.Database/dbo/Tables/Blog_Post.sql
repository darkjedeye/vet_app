CREATE TABLE [dbo].[Blog_Post] (
    [ID]               UNIQUEIDENTIFIER CONSTRAINT [DF_Blog_Post_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IsPublished]      BIT              NOT NULL,
    [IsCommentEnabled] BIT              NOT NULL,
    [IsDeleted]        BIT              NOT NULL,
    [DateCreated]      DATETIME         NOT NULL,
    [DateModified]     DATETIME         NULL,
    [OriginalAuthor]   UNIQUEIDENTIFIER NOT NULL,
    [LastModifyAuthor] UNIQUEIDENTIFIER NULL,
    [Title]            NVARCHAR (255)   NOT NULL,
    [Slug]             NVARCHAR (255)   NULL,
    [Description]      NVARCHAR (MAX)   NULL,
    [PostContent]      NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Blog_Post] PRIMARY KEY CLUSTERED ([ID] ASC)
);



