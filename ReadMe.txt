Create Table Script

CREATE TABLE Pricing (
    pricing_date varchar(8) NOT NULL,
    price DECIMAL(19,4) NOT NULL,
    last_update_Date TIMESTAMP,
    PRIMARY KEY (pricing_date)
);

CREATE PROCEDURE [dbo].[SP_GET_LAST_PRICINGDATE]  
AS  
   SELECT MAX(CAST(pricing_date AS Int)) FROM FuelPrices.dbo.Pricing
GO;  


