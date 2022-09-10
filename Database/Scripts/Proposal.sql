USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[Proposal]    Script Date: 9/6/2022 7:22:23 AM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Proposal`(
	`Id` Char(36) NOT NULL,
	`Description` VARCHAR(200)  NULL,
	`CreatedBy` INT NULL,
	`CreatedOn` Datetime(6) NULL,
	`ProposalNo` VARCHAR(30) NOT NULL,
	`Remarks` VARCHAR(200)  NULL,
	`StatusId` int NOT NULL DEFAULT 0,
	`CustomerId` int NULL,
	`SalesOrderId` int NULL,
 CONSTRAINT `PK_Proposal` PRIMARY KEY 
(
	`Id` ASC
) 
);



ALTER TABLE `Proposal`  ADD  CONSTRAINT `FK_Proposal_SalesOrder_SalesOrderId` FOREIGN KEY(`SalesOrderId`)
REFERENCES `SalesOrder` (`SalesOrderId`);
 
 


