CREATE TABLE [dbo].[tblUser]
(
    [UserID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Username] VARCHAR(30) NULL,
    [Password] VARCHAR(30) NULL,
    [Role] VARCHAR(20) NULL,
    [IsLocked] BIT NOT NULL DEFAULT 0,
    [FailedAttempts] INT NOT NULL DEFAULT 0
)
