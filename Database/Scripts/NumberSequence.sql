USE CDMS;

CREATE TABLE `NumberSequence`(
	`NumberSequenceId` int AUTO_INCREMENT NOT NULL,
	`LastNumber` int NOT NULL,
	`Module` Longtext NOT NULL,
	`NumberSequenceName` Longtext NOT NULL,
	`Prefix` Longtext NOT NULL,
 CONSTRAINT `PK_NumberSequence` PRIMARY KEY 
(
	`NumberSequenceId` ASC
) 
);
