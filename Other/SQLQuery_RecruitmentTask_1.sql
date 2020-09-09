GO

DROP TABLE IF EXISTS Prices;

GO

CREATE TABLE Prices(
	Id INT PRIMARY KEY IDENTITY (1,1),
	PriceFrom DECIMAL(10,2) NOT NULL,
	PriceTo DECIMAL(10,2) NOT NULL,
	ValueEnding DECIMAL(10,2) NOT NULL,
	ValueEndingFrom DECIMAL(10,2) NOT NULL,
	ValueEndingTo DECIMAL(10,2) NOT NULL,
);

GO

INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.19,0.0,0.25);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.29,0.25,0.35);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.39,0.35,0.45);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.49,0.45,0.55);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.59,0.55,0.65);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.69,0.65,0.75);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.79,0.75,0.85);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (0.0,7.0,0.99,0.85,1.0);

INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (7.0,15.0,0.29,0.0,0.39);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (7.0,15.0,0.49,0.39,0.64);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (7.0,15.0,0.79,0.64,0.89);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (7.0,15.0,0.99,0.89,1);

INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (15,30,0.49,0,0.5);
INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (15,30,0.99,0.5,1);

INSERT INTO Prices (PriceFrom,PriceTo,ValueEnding,ValueEndingFrom,ValueEndingTo)
VALUES (30,99999,0.99,0,1);

GO

DROP FUNCTION IF EXISTS FixValueEnding;

GO

CREATE FUNCTION FixValueEnding
(
	@value DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @intPart DECIMAL(10,2)
	SET @intPart = FLOOR(@value)

	DECLARE @decimalPart DECIMAL(10,2)
	SET @decimalPart = @value - FLOOR(@value)

	RETURN @intPart + (SELECT p.ValueEnding  
						FROM Prices p 
						WHERE p.PriceFrom <= @intPart AND p.PriceTo> @intPart AND 
							  p.ValueEndingFrom <= @decimalPart AND p.ValueEndingTo > @decimalPart)
END
GO

SELECT dbo.FixValueEnding(8.42)