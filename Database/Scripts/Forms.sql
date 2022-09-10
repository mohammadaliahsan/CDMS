USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[AspNetRoles]    Script Date: 9/4/2022 5:06:50 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Forms`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`ConcurrencyStamp` Longtext NULL,
	`Name` nvarchar(256) NULL,
	`NormalizedName` nvarchar(256) NULL,
 CONSTRAINT `PK_AspNetRoles` PRIMARY KEY 
(
	`Id` ASC
) 
);


