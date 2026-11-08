CREATE TABLE dbo.SaleItems
    (
        SaleItemId BIGINT IDENTITY(1,1) PRIMARY KEY,
        SaleId BIGINT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(18,2) NOT NULL,
        Subtotal DECIMAL(18,2) NOT NULL,

        CONSTRAINT FK_SaleItems_Sales
            FOREIGN KEY (SaleId)
            REFERENCES dbo.Sales(SaleId)
    );