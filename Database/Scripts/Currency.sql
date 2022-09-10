USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[Currency]    Script Date: 9/4/2022 5:16:11 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Currency`(
	`CurrencyId` int AUTO_INCREMENT NOT NULL,
	`CurrencyCode` Longtext NOT NULL,
	`CurrencyName` Longtext NOT NULL,
	`Description` Longtext NULL,
 CONSTRAINT `PK_Currency` PRIMARY KEY 
(
	`CurrencyId` ASC
) 
);


