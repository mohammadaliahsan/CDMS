-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: cdms
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `salesorder`
--

DROP TABLE IF EXISTS `salesorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salesorder` (
  `SalesOrderId` int NOT NULL AUTO_INCREMENT,
  `SalesOrderNo` varchar(20) NOT NULL,
  `Amount` double NOT NULL,
  `BranchId` int DEFAULT NULL,
  `CurrencyId` int DEFAULT NULL,
  `CustomerId` int NOT NULL,
  `CustomerRefNumber` varchar(30) DEFAULT NULL,
  `DeliveryDate` datetime(6) NOT NULL,
  `Discount` double DEFAULT '0',
  `Freight` double DEFAULT '0',
  `OrderDate` datetime(6) NOT NULL,
  `Remarks` longtext,
  `SalesOrderName` longtext,
  `SalesTypeId` int DEFAULT NULL,
  `SubTotal` double NOT NULL,
  `Tax` double DEFAULT '0',
  `Total` double NOT NULL,
  `ProposalNo` longtext,
  `ProjectId` int DEFAULT NULL,
  `CreatedBy` int DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CompanyId` int DEFAULT NULL,
  PRIMARY KEY (`SalesOrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salesorder`
--

LOCK TABLES `salesorder` WRITE;
/*!40000 ALTER TABLE `salesorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `salesorder` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-08 11:13:57
