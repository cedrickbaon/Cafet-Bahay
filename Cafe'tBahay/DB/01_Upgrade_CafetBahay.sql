-- Run once against the SAME (localdb)\MSSQLLocalDB / CafetBahay instance used by AppServices.
-- Non-destructive: no DROP, DELETE, TRUNCATE, or IDENTITY reseeding.
USE [CafetBahay];
GO
IF OBJECT_ID('dbo.tblUser','U') IS NULL OR OBJECT_ID('dbo.tblProducts','U') IS NULL
  OR OBJECT_ID('dbo.tblCategory','U') IS NULL OR OBJECT_ID('dbo.tblSupplierTable','U') IS NULL
    THROW 50001, 'Required base tables not found. Confirm the CafetBahay database.', 1;
GO
-- Extend originally undersized columns; existing data is preserved.
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN SupplierName VARCHAR(150) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN ProductSupplied VARCHAR(500) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN ContactPerson VARCHAR(150) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN ContactNumber VARCHAR(30) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN EmailAddress VARCHAR(254) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN [Address] VARCHAR(500) NULL;
ALTER TABLE dbo.tblSupplierTable ALTER COLUMN [Notes/Remarks(Optional)] VARCHAR(1000) NULL;
ALTER TABLE dbo.tblCategory ALTER COLUMN CategoryName VARCHAR(100) NULL;
ALTER TABLE dbo.tblCategory ALTER COLUMN [Description] VARCHAR(500) NULL;
ALTER TABLE dbo.tblCategory ALTER COLUMN [Notes/Remarks(Optional)] VARCHAR(1000) NULL;
ALTER TABLE dbo.tblProducts ALTER COLUMN ProductName VARCHAR(150) NULL;
ALTER TABLE dbo.tblProducts ALTER COLUMN Price DECIMAL(18,2) NULL;
ALTER TABLE dbo.tblUser ALTER COLUMN Username VARCHAR(100) NULL;
ALTER TABLE dbo.tblUser ALTER COLUMN [Password] VARCHAR(128) NULL;
GO
IF COL_LENGTH('dbo.tblProducts','RowVersion') IS NULL
    ALTER TABLE dbo.tblProducts ADD RowVersion ROWVERSION;
GO
IF OBJECT_ID('dbo.Sales','U') IS NULL
BEGIN
    CREATE TABLE dbo.Sales
    (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TransactionNumber VARCHAR(32) NOT NULL UNIQUE,
        SoldAtUtc DATETIME2(3) NOT NULL,
        CashierId INT NOT NULL,
        Total DECIMAL(18,2) NOT NULL,
        Payment DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_Sales_Users FOREIGN KEY(CashierId) REFERENCES dbo.tblUser(UserID),
        CONSTRAINT CK_Sales_Amounts CHECK (Total >= 0 AND Payment >= Total)
    );
END;
GO
IF OBJECT_ID('dbo.SaleItems','U') IS NULL
BEGIN
    CREATE TABLE dbo.SaleItems
    (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        SaleId BIGINT NOT NULL,
        ProductId INT NOT NULL,
        ProductName VARCHAR(150) NOT NULL,
        Quantity INT NOT NULL CHECK(Quantity > 0),
        UnitPrice DECIMAL(18,2) NOT NULL CHECK(UnitPrice >= 0),
        CONSTRAINT FK_SaleItems_Sales FOREIGN KEY(SaleId) REFERENCES dbo.Sales(Id),
        CONSTRAINT FK_SaleItems_Products FOREIGN KEY(ProductId) REFERENCES dbo.tblProducts(ProductID)
    );
END;
GO
PRINT 'CafetBahay schema upgrade completed. Existing records were preserved.';
