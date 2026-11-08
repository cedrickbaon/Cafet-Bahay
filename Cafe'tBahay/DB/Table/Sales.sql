 CREATE TABLE dbo.Sales
    (
        SaleId BIGINT IDENTITY(1,1) PRIMARY KEY,
        TransactionNumber NVARCHAR(50) NOT NULL UNIQUE,
        SoldAtUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CashierId INT NOT NULL,
        Total DECIMAL(18,2) NOT NULL,
        Payment DECIMAL(18,2) NOT NULL,
        [Change] DECIMAL(18,2) NOT NULL
    );
