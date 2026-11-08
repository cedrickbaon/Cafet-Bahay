CREATE TABLE [dbo].[tblSupplierTable]
(
	[SupplierID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[SupplierName] VARCHAR (30) NULL,
	[ProductSupplied]  VARCHAR(20) NULL,
	[ContactPerson] VARCHAR (30) NULL,
	[ContactNumber] VARCHAR(20) NULL,
	[EmailAddress] VARCHAR (40) NULL,
	[Address] VARCHAR (50) NULL,
	[Status] VARCHAR (20) NULL,
	[Notes/Remarks(Optional)] VARCHAR (20) NULL
)
