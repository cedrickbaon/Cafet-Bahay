CREATE TABLE [dbo].[tblSupplierTable]
(
	[Supplier ID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Supplier Name] VARCHAR (30) NULL,
	[Product Supplied] VARCHAR(20) NULL,
	[Contact Person] VARCHAR (30) NULL,
	[Contact Number] INT NULL,
	[Email Address] VARCHAR (40) NULL,
	[Address] VARCHAR (50) NULL,
	[Status] VARCHAR (20) NULL,
	[Notes/Remarks (Optional)] VARCHAR (20) NULL
)
