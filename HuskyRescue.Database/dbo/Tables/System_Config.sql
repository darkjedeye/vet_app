CREATE TABLE [dbo].[System_Config] (
    [CategoryName] NVARCHAR (50)  NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Value]        NVARCHAR (500) NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    CONSTRAINT [PK_System_Config] PRIMARY KEY CLUSTERED ([CategoryName] ASC, [Name] ASC),
    CONSTRAINT [FK_ConfigCategory_Id___SystemConfigSystem_CategoryId] FOREIGN KEY ([CategoryName]) REFERENCES [dbo].[System_ConfigCategory] ([Name])
);





