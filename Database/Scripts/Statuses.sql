USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[Statuses]    Script Date: 9/6/2022 7:20:46 AM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Statuses`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Description` Longtext NULL,
	`StatusFor` Longtext NOT NULL,
	`Value` int NOT NULL,
 CONSTRAINT `PK_Statuses` PRIMARY KEY 
(
	`Id` ASC
) 
);
 


