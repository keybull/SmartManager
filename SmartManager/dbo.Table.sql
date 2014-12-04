CREATE TABLE [dbo].[Tasks]
(
	[Id]    INT         NOT NULL,
    [Stage] NCHAR (255) NULL,
    [Task]  NCHAR (255) NULL,
    [Week]  NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
