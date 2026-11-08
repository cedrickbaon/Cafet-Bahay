CREATE TABLE [dbo].[tblProducts]
(
	[ProductID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[ProductName] VARCHAR (20) NULL,
	[CategoryID] INT,
	[SupplierID] INT,
	[Price] DECIMAL (4,2) NULL,
	[StockQuantity] INT NULL,
	[ProductStatus] VARCHAR (8) NULL,
	[RowVersion] ROWVERSION NOT NULL

	FOREIGN KEY ([CategoryID]) REFERENCES [tblCategory]([CategoryID]),
	FOREIGN KEY ([SupplierID]) REFERENCES [tblSupplierTable]([SupplierID])

)
