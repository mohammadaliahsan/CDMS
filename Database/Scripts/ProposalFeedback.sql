USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[ProposalFeedback]    Script Date: 9/6/2022 7:26:47 AM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `ProposalFeedback`(
	`Id` Char(36) NOT NULL,
	`CreatedBy` Longtext NULL,
	`CreatedOn` Datetime(6) NOT NULL,
	`ProposalNo` VARCHAR(30) NOT NULL,
	`ProposalId` INT NOT NULL,
	`Remarks` VARCHAR(300) NULL,
	`Description` VARCHAR(100) NULL,
 CONSTRAINT `PK_ProposalFeedback` PRIMARY KEY 
(
	`Id` ASC
) 
);