USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[Customer]    Script Date: 9/5/2022 9:39:24 AM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Customer`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Address` varchar(200) NULL,
	`ContactPerson` nvarchar(20) NULL,
	`CustomerName` varchar(100) NOT NULL,
	`CustomerTypeId` int NOT NULL,
	`Email` nvarchar(100) NULL,
	`Phone` nvarchar(20) NULL,
	`State` nvarchar(50) NULL,
	`ZipCode` nvarchar(20) NULL,
CONSTRAINT `PK_Customer` PRIMARY KEY 
(
	`Id` ASC
) 
);



