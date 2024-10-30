CREATE TABLE PurchaseLots (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Shares INT NOT NULL,
    CostPerShare DECIMAL(10, 2) NOT NULL,
    PurchaseDate DATE NOT NULL
);

-- Insert initial data
INSERT INTO PurchaseLots (Shares, CostPerShare, PurchaseDate)
VALUES 
(100, 20.00, '2023-01-01'),
(150, 30.00, '2023-02-01'),
(120, 10.00, '2023-03-01');
