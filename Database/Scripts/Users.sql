USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[AspNetUsers]    Script Date: 9/4/2022 5:00:52 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Users`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`AccessFailedCount` int NOT NULL,
	`ConcurrencyStamp` VARCHAR(200) NULL,
	`Email` nvarchar(200) NULL,
	`EmailConfirmed` Tinyint NOT NULL,
	`LockoutEnabled` Tinyint NOT NULL,
	`LockoutEnd` Datetime(6) NULL,
	`NormalizedEmail` nvarchar(200) NULL,
	`NormalizedUserName` nvarchar(256) NULL,
	`PasswordHash` VARCHAR(200) NULL,
	`PhoneNumber` VARCHAR(30) NULL,
	`PhoneNumberConfirmed` Tinyint NOT NULL,
	`SecurityStamp` VARCHAR(200) NULL,
	`TwoFactorEnabled` Tinyint NOT NULL,
	`UserName` nvarchar(256) NULL,
    `CompanyId` INT NULL,
    `BranchI` INT NULL,
    `UserType` TINYINT NULL DEFAULT 0,
 CONSTRAINT `PK_Users` PRIMARY KEY 
(
	`Id` ASC
) 
);


