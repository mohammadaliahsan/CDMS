USE `CDMS`;
 

/* SQLINES DEMO *** le [dbo].[FileUpload]    Script Date: 9/4/2022 5:13:33 PM ******/
/* SET ANSI_NULLS ON */
 

/* SET QUOTED_IDENTIFIER ON */
 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `FileUpload`(
	`FileId` nvarchar(450) NOT NULL,
	`FileName` Longtext NULL,
	`FileUploadFileId` nvarchar(450) NULL,
	`FileUrl` Longtext NULL,
 CONSTRAINT `PK_FileUpload` PRIMARY KEY 
(
	`FileId` ASC
) 
);

ALTER TABLE `FileUpload`  ADD  CONSTRAINT `FK_FileUpload_FileUpload_FileUploadFileId` FOREIGN KEY(`FileUploadFileId`)
REFERENCES `FileUpload` (`FileId`);
 

ALTER TABLE `FileUpload` CHECK CONSTRAINT `FK_FileUpload_FileUpload_FileUploadFileId`;
 


