CREATE TABLE [dbo].[Blog_Comments] (
    [ID]                     UNIQUEIDENTIFIER CONSTRAINT [DF_Blog_Comments_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [PostID]                 UNIQUEIDENTIFIER NOT NULL,
    [ParentCommentID]        UNIQUEIDENTIFIER NULL,
    [IsDeleted]              BIT              NOT NULL,
    [IsSpam]                 BIT              NOT NULL,
    [DateCreated]            DATETIME2 (7)    NOT NULL,
    [AuthorIP]               NVARCHAR (50)    NULL,
    [ModeratedByUserID]      UNIQUEIDENTIFIER NULL,
    [ModeratedDate]          DATETIME2 (7)    NULL,
    [AuthorRegisteredUserID] UNIQUEIDENTIFIER NULL,
    [AuthorName]             NVARCHAR (255)   NULL,
    [AuthorEmail]            NVARCHAR (255)   NULL,
    [AuthorWebsite]          NVARCHAR (255)   NULL,
    [Comment]                NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Blog_Comments] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_BlogComments_ID__BlogComments_ParentComentID] FOREIGN KEY ([ParentCommentID]) REFERENCES [dbo].[Blog_Comments] ([ID]),
    CONSTRAINT [FK_BlogPost_ID__BlogComments_PostID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Blog_Post] ([ID])
);



