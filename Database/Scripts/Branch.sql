USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[Branch]    Script Date: 9/4/2022 5:16:02 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Branch`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Address` Longtext NULL,
	`BranchName` Longtext NOT NULL,
	`ContactPerson` Longtext NULL,
	`CompanyId` int NOT NULL,
	`Description` Longtext NULL,
	`Email` Longtext NULL,
	`Phone` Longtext NULL,
	`State` Longtext NULL,
	`ZipCode` Longtext NULL,
 CONSTRAINT `PK_Branch` PRIMARY KEY 
(
	`Id` ASC
) 
);


