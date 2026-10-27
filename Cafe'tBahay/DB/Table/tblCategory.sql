CREATE TABLE [dbo].[tblCategory]
(
	[Category ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Category Name] VARCHAR(20) NULL,
	[Description] VARCHAR (20) NULL,
	[Notes/Remarks (Optional)] VARCHAR (20) NULL
)
