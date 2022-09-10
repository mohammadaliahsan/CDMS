USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[UserFormsAccess]    Script Date: 9/4/2022 5:08:35 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `UserFormsAccess`(
	`UserId` INT NOT NULL,
	`Formd` INT NOT NULL,
 CONSTRAINT `PK_UserFormsAccess` PRIMARY KEY 
(
	`UserId` ASC,
	`FormId` ASC
) 
);

ALTER TABLE `UserFormsAccess`  ADD  CONSTRAINT `FK_UserFormsAccess_Forms_FormId` FOREIGN KEY(`FormId`)
REFERENCES `Forms` (`Id`)
ON DELETE CASCADE;
 

ALTER TABLE `UserFormsAccess` CHECK CONSTRAINT `FK_UserFormsAccess_Forms_FormId`;
 

ALTER TABLE `UserFormsAccess`  ADD  CONSTRAINT `FK_UserFormsAccess_Users_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`Id`)
ON DELETE CASCADE;
 

ALTER TABLE `UserFormsAccess` CHECK CONSTRAINT `FK_UserFormsAccess_Users_UserId`;
 


