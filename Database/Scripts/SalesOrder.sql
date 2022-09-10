USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[SalesOrder]    Script Date: 9/6/2022 7:07:06 AM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `SalesOrder`(
	`SalesOrderId` int AUTO_INCREMENT NOT NULL,
	`SalesOrderNo` VARCHAR(20) NOT NULL,
	`Amount` Double NOT NULL,
	`BranchId` int NOT NULL,
	`CurrencyId` int NULL,
	`CustomerId` int NOT NULL,
	`CustomerRefNumber` VARCHAR(30) NULL,
	`DeliveryDate` Datetime(6) NOT NULL,
	`Discount` Double NULL DEFAULT 0,
	`Freight` Double NULL DEFAULT 0,
	`OrderDate` Datetime(6) NOT NULL,
	`Remarks` Longtext NULL,
	`SalesOrderName` Longtext NULL,
	`SalesTypeId` int NULL,
	`SubTotal` Double NOT NULL,
	`Tax` Double NULL DEFAULT 0,
	`Total` Double NOT NULL,
	`ProposalNo` Longtext NULL,
	`ProjectId` INT NULL,
 CONSTRAINT `PK_SalesOrder` PRIMARY KEY 
(
	`SalesOrderId` ASC
) 
);

 


