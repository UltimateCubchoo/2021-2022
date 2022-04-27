-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: bkstoredb
-- ------------------------------------------------------
-- Server version	8.0.22

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
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `book_id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  `author` varchar(45) DEFAULT NULL,
  `genre` varchar(45) DEFAULT NULL,
  `image` varchar(45) DEFAULT NULL,
  `rating` tinyint DEFAULT NULL,
  `coming` bit(1) DEFAULT b'0',
  PRIMARY KEY (`book_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (2,'test','test','test','test.jpg',5,_binary '\0'),(3,'asdf','asdf','asdf','asdf.jpg',3,_binary '\0'),(4,'reqw','reqw','rewq','reqw.jpg',4,_binary '\0'),(5,'litty','litty','litty','litty.jpg',6,_binary '\0'),(6,'unr','unr','unr','unr.png',5,_binary ''),(11,'a','a','sci-fi','a.png',0,_binary '\0'),(13,'qwer','qwer','sci-fi','qwer.png',2,_binary '\0'),(14,'idk','idk','idk','idk.jpg',3,_binary '\0'),(15,'dog man','idk','sci-fi','dog man.png',0,_binary '\0'),(16,'dog man','idk','sci-fi','dog man.png',0,_binary '\0'),(17,'dog man','idk','sci-fi','dog man.png',0,_binary '\0'),(18,'dog man','idk','sci-fi','dog man.png',0,_binary '\0'),(19,'test','test','thriller/horror','test.png',0,_binary '\0'),(20,'a','a','mystery','a.png',0,_binary '\0'),(21,'a','a','sci-fi','a.png',0,_binary '\0');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `fname` varchar(45) DEFAULT NULL,
  `lname` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (2,'undefined','undefined','undefined','undefined'),(3,'Alick','Baldhead','idk street','234141'),(4,'Gertruf','Nemoid','idk street','234141'),(5,'Litina','Creen','idk street','234141'),(6,'Jim','Re','123jklj;k','12312786'),(8,'John','Deere','I RIP YOU OFF ST.','123456789'),(9,'fdas','fdsa','fdsa','1232131');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rents`
--

DROP TABLE IF EXISTS `rents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rents` (
  `rent_id` int NOT NULL AUTO_INCREMENT,
  `indate` date DEFAULT NULL,
  `outdate` date DEFAULT NULL,
  PRIMARY KEY (`rent_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rents`
--

LOCK TABLES `rents` WRITE;
/*!40000 ALTER TABLE `rents` DISABLE KEYS */;
INSERT INTO `rents` VALUES (1,'2004-03-13','2004-03-14'),(2,'2023-05-12','2023-05-16'),(3,'2022-04-07','2022-06-17'),(4,'2022-03-27','2022-04-30'),(7,'2022-04-24','2022-04-27'),(8,'2022-04-24','2022-04-27'),(9,'2022-04-01','2022-04-30');
/*!40000 ALTER TABLE `rents` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22  7:39:08
