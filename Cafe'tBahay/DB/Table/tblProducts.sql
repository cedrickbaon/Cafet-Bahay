CREATE TABLE [dbo].[tblProducts]
(
	[Product ID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Product Name] VARCHAR (20) NULL,
	[Category ID] INT,
	[Supplier ID] INT,
	[Price] DECIMAL (4,2) NULL,
	[Stock Quantity] INT NULL,
	[Product Status] VARCHAR (8) NULL,

	FOREIGN KEY ([Category ID]) REFERENCES [tblCategory]([Category ID]),
	FOREIGN KEY ([Supplier ID]) REFERENCES [tblSupplierTable]([Supplier ID])

)
