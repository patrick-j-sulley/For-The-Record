
CREATE DATABASE `sdv701` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;


CREATE TABLE `artist` (
  `Name` varchar(50) NOT NULL,
  `Label` varchar(50) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `album` (
  `Name` varchar(50) NOT NULL,
  `Type` varchar(5) NOT NULL,
  `ArtistName` varchar(50) NOT NULL,
  `Genre` varchar(10) NOT NULL,
  `Price` decimal(4,2) NOT NULL,
  `LastModified` date NOT NULL,
  `Tracks` int(2) NOT NULL,
  `Stock` int(3) NOT NULL,
  `Discs` int(1) DEFAULT NULL,
  `Single` tinyint(1) DEFAULT NULL,
  `Sides` int(1) DEFAULT NULL,
  `Limited` tinyint(1) DEFAULT NULL,
  `BoxSet` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Name`,`Type`),
  KEY `FKAlbum722846` (`ArtistName`),
  CONSTRAINT `FKAlbum722846` FOREIGN KEY (`ArtistName`) REFERENCES `artist` (`Name`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `order` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `AlbumName` varchar(50) NOT NULL,
  `AlbumType` varchar(5) NOT NULL,
  `Status` varchar(10) NOT NULL,
  `Quantity` int(3) NOT NULL,
  `TotalPrice` decimal(19,2) NOT NULL,
  `DateTime` date NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `CustomerAddress` varchar(100) NOT NULL,
  `CustomerEmail` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FKOrder558985` (`AlbumName`,`AlbumType`),
  CONSTRAINT `FKOrder558985` FOREIGN KEY (`AlbumName`, `AlbumType`) REFERENCES `album` (`Name`, `Type`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

#_________________________________________________________________________________________________
# Demonstration of populating your database using SQL code and/or importing CSV files. 
#_________________________________________________________________________________________________
  
INSERT INTO `sdv701`.`artist`
(`Name`, `Label`)
VALUES
("David Bowie", "Sony");

INSERT INTO `sdv701`.`artist`
(`Name`, `Label`)
VALUES
("ACDC", "Virgin Records");

INSERT INTO `sdv701`.`artist`
(`Name`, `Label`)
VALUES
("Michael Jackson", "EMI");

INSERT INTO `sdv701`.`album`
(`Name`, `Type`, `ArtistName`, `Genre`, `Price`, `LastModified`, `Tracks`, `Stock`, `Discs`, `Single`)
VALUES
("Thriller", "CD", "Michael Jackson", "Pop", "24.99", current_date(), "9", "9", "9", "0");

INSERT INTO `sdv701`.`order`
(`AlbumName`, `AlbumType`, `Status`, `Quantity`, `TotalPrice`, `DateTime`, `CustomerName`, `CustomerAddress`, `CustomerEmail`)
VALUES
("Thriller", "CD", "Pending", "1", "24.99", current_date(), "John Smith", "123 Fake Street, Nelson", "JohnSmith@gmail.com");


#_________________________________________________________________________________________________
# Demonstration of at least 5 queries, essential in your application, using DML/SQL code.
#_________________________________________________________________________________________________

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ChangeOrderStatus`(IN prID int,
									  IN prStatus VARCHAR(10))
BEGIN
UPDATE `sdv701`.`order`
SET
`Status` = prStatus
WHERE `ID` = prID;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateNewOrder`(prAlbumName varchar (50),
								prAlbumType varchar (5),
								prQuantity int,
                                prTotalPrice decimal,
                                prDateTime datetime,
                                prCustomerName VARCHAR(100),
                                prCustomerAddress VARCHAR(100),
                                prCustomerEmail VARCHAR(50))
BEGIN
INSERT INTO `sdv701`.`order`
(`AlbumName`, `AlbumType`, `Status`, `Quantity`, `TotalPrice`, `DateTime`, `CustomerName`, `CustomerAddress`, `CustomerEmail`)
VALUES
(prAlbumName, prAlbumType, "Pending", prTotalPrice, prDateTime, prCustomerName, prCustomerAddress, prCustomerEmail);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAlbum`(IN prName varchar(50),
								IN prType varchar(5))
BEGIN
DELETE FROM `sdv701`.`album`
WHERE `Name` = prName
AND `Type` = prType;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteOrder`(IN prID int)
BEGIN
DELETE FROM `sdv701`.`order`
WHERE ID = prID;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAlbumDetails`(prName VARCHAR(50),
									prType VARCHAR(20))
BEGIN
SELECT *
FROM `sdv701`.`album`
WHERE `Name` = prName
AND
`Type` = prType;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAlbumPricePerUnit`(IN prName VARCHAR (50),
										IN prType VARCHAR (5))
BEGIN
SELECT 
    `album`.`Price` as PricePerUnit
FROM `sdv701`.`album`
WHERE `Name` = prName
AND
`Type` = prType;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllOrders`()
BEGIN
SELECT *
FROM `sdv701`.`order`;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetArtist`(IN prName VARCHAR (50))
BEGIN
SELECT * FROM artist
WHERE `Name` = prName;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetArtistsAlbums`(IN prName VARCHAR (50))
BEGIN
IF EXISTS
(
SELECT ArtistName FROM album
WHERE ArtistName = prName
)
THEN
SELECT * FROM album
WHERE ArtistName = prName;
END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetArtistsAlbums_Customer`(IN prName VARCHAR (50))
BEGIN
IF EXISTS
(
SELECT ArtistName FROM album
WHERE ArtistName = prName
)
THEN
SELECT `Name`, `Type`, `Stock`, `Price` FROM album
WHERE ArtistName = prName;
END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTotalArtistStock`(IN prName VARCHAR (50))
BEGIN
IF EXISTS
(
SELECT ArtistName
FROM album
WHERE ArtistName = prName
)
THEN
SELECT SUM(Stock) as totalStock
FROM album
WHERE ArtistName = prName;

ELSE

SELECT 0 as totalStock;
END IF;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTotalCostOfOrders`()
BEGIN
SELECT 
    SUM(`TotalPrice`) as TotalCostOfOrders
FROM `sdv701`.`order`;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertNewAlbum`(IN prName varchar(50),
								   IN prType varchar(5),
                                   IN prArtistName varchar(50),
                                   IN prGenre varchar(10),
                                   IN prPrice decimal(4, 2),
                                   IN prLastModified datetime,
                                   IN prTracks int(2),
                                   IN prStock int(3),
                                   IN prDiscs int(1),
                                   IN prSingle tinyint(1),
                                   IN prSides int(1),
                                   IN prLimited tinyint(1),
                                   IN prBoxSet tinyint(1))
BEGIN								
INSERT INTO `sdv701`.`album`
(`Name`, `Type`,`ArtistName`, `Genre`, `Price`, `LastModified`, `Tracks`, `Stock`, `Discs`, `Single`, `Sides`, `Limited`, `BoxSet`)
VALUES
(prName, prType, prArtistName, prGenre, prPrice, prLastModified, prTracks, prStock, prDiscs, prSingle, prSides, prLimited, prBoxSet);

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertNewArtist`(IN prName VARCHAR (50),
									IN prLabel VARCHAR (50))
BEGIN
INSERT INTO `sdv701`.`artist`
(`Name`, `Label`)
VALUES
(prName, prLabel);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertNewOrder`(IN prAlbumName VARCHAR(50),
									IN prAlbumType VARCHAR(5),
                                    IN prStatus VARCHAR(10),
                                    IN prQuantity int(3),
                                    IN prTotalPrice decimal(19,2),
                                    IN prDateTime datetime,
                                    IN prCustomerName VARCHAR(100),
                                    IN prCustomerAddress VARCHAR(100),
                                    IN prCustomerEmail VARCHAR(50))
BEGIN
INSERT INTO `sdv701`.`order`
(`AlbumName`, `AlbumType`, `Status`, `Quantity`, `TotalPrice`, `DateTime`, `CustomerName`, `CustomerAddress`, `CustomerEmail`)
VALUES
( prAlbumName, prAlbumType, prStatus, prQuantity, prTotalPrice, prDateTime, prCustomerName, prCustomerAddress, prCustomerEmail);

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `LocateArtist`(IN prName VARCHAR (50))
BEGIN
SELECT `Name` FROM artist
WHERE `Name` = prName;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `LocateOrder`(IN prID int)
BEGIN
SELECT `ID` FROM sdv701.order
WHERE `ID` = prID;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ShowAllArtists`()
BEGIN

SELECT `Name` FROM artist
ORDER BY `Name` ASC;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateAlbum`(IN prName varchar(50),
								   IN prType varchar(5),
                                   IN prGenre varchar(10),
                                   IN prPrice decimal(4, 2),
                                   IN prLastModified datetime,
                                   IN prTracks int(2),
                                   IN prStock int(3),
                                   IN prDiscs int(1),
                                   IN prSingle tinyint(1),
                                   IN prSides int(1),
                                   IN prLimited tinyint(1),
                                   IN prBoxSet tinyint(1))
BEGIN
UPDATE `sdv701`.`album`
SET `Genre` = prGenre, `Price` = prPrice, `LastModified` = prLastModified, `Tracks` = prTracks, `Stock` = prStock, `Discs` = prDiscs, `Single` = prSingle, `Sides` = prSides, `Limited` = prLimited, `BoxSet` = prBoxSet
WHERE `Name` = prName AND `Type` = prType;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateAlbumStock`(prAlbumName varchar(50),
									prAlbumType varchar(5),
									prStock int)
BEGIN
UPDATE `sdv701`.`album`
SET
`Stock` = prStock
WHERE `Name` = prAlbumName AND `Type` = prAlbumType;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateArtist`(IN prName VARCHAR (50),
								 IN prLabel VARCHAR (50))
BEGIN
UPDATE `sdv701`.`artist`
SET
`Label` = prLabel
WHERE `Name` = prName;
END$$
DELIMITER ;
