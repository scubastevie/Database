CREATE TABLE Pricing (
    pricing_date varchar(8) NOT NULL,
    price DECIMAL(19,4) NOT NULL,
    last_update_Date DATETIME,
    PRIMARY KEY (pricing_date)
);

CREATE PROCEDURE [dbo].[SP_GET_LAST_PRICINGDATE]  
AS  
   SELECT MAX(CAST(pricing_date AS Int)) FROM FuelPrices.dbo.Pricing
GO;  




CREATE PROCEDURE [dbo].[SP_Insert_Price] @pricing_date varchar(8), @price int, @last_update_Date datetime
AS 
INSERT INTO dbo.Pricing ([pricing_date], [price], [last_update_Date])
VALUES (@pricing_date, @price, @last_update_Date)
GO
