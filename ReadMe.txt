CREATE TABLE Pricing (
    PriceDate varchar(8) NOT NULL,
    Price DECIMAL(19,4) NOT NULL,
    LastUpdateDate DATETIME,
    PRIMARY KEY (PriceDate)
);

CREATE PROCEDURE [dbo].[SP_GET_LAST_PRICINGDATE]  
AS  
   SELECT MAX(CAST(PriceDate AS Int)) FROM FuelPrices.dbo.Pricing
GO;  




CREATE PROCEDURE [dbo].[SP_Insert_Price] @PriceDate varchar(8), @Price int, @LastUpdateDate datetime
AS 
INSERT INTO dbo.Pricing ([PriceDate], [Price], [LastUpdateDate])
VALUES (@PriceDate, @Price, @LastUpdateDate)
GO
