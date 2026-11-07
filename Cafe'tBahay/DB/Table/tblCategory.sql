CREATE TABLE [dbo].[tblCategory]
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CategoryName] VARCHAR(20) NULL,
	[Description] VARCHAR (20) NULL,
	[Notes/Remarks(Optional)] VARCHAR (20) NULL
)
