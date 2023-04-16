-- MySQL dump 10.16  Distrib 10.1.48-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: db
-- ------------------------------------------------------
-- Server version	10.1.48-MariaDB-0+deb9u2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Autorzy`
--

DROP TABLE IF EXISTS `Autorzy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Autorzy` (
  `id` tinyint(4) DEFAULT NULL,
  `imiona` varchar(5) DEFAULT NULL,
  `nazwisko` varchar(9) DEFAULT NULL,
  `data_urodzenia` varchar(19) DEFAULT NULL,
  `data_smierci` varchar(19) DEFAULT NULL,
  `narodowosc` varchar(9) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Autorzy`
--

LOCK TABLES `Autorzy` WRITE;
/*!40000 ALTER TABLE `Autorzy` DISABLE KEYS */;
INSERT INTO `Autorzy` VALUES (1,'Terry','Pratchett','1938-04-28 00:00:00','2015-03-12 00:00:00','Brytyjska'),(2,'Jerzy','Grębocz','','','Polska');
/*!40000 ALTER TABLE `Autorzy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ksiazki`
--

DROP TABLE IF EXISTS `Ksiazki`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ksiazki` (
  `tytul` varchar(17) DEFAULT NULL,
  `autor` tinyint(4) DEFAULT NULL,
  `wydawnictwo` tinyint(4) DEFAULT NULL,
  `seria` varchar(11) DEFAULT NULL,
  `rok_wydania` smallint(6) DEFAULT NULL,
  `rok_1wydania` smallint(6) DEFAULT NULL,
  `strony` smallint(6) DEFAULT NULL,
  `jezyk` varchar(6) DEFAULT NULL,
  `jezyk_oryginalny` varchar(9) DEFAULT NULL,
  `tlumaczenie` varchar(16) DEFAULT NULL,
  `tytul_oryginalny` varchar(14) DEFAULT NULL,
  `kategoria` varchar(10) DEFAULT NULL,
  `ISBN` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ksiazki`
--

LOCK TABLES `Ksiazki` WRITE;
/*!40000 ALTER TABLE `Ksiazki` DISABLE KEYS */;
INSERT INTO `Ksiazki` VALUES ('Wyprawa czarownic',1,1,'Świat Dysku',2001,1998,264,'polski','angielski','Piotr W. Cholewa','Witches Abroad','Fantastyka','\r\n9788374692168'),('Opus Magnum C++11',2,2,'',2020,2017,1650,'polski','','','','Podręcznik','9788383223940');
/*!40000 ALTER TABLE `Ksiazki` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Recenzje`
--

DROP TABLE IF EXISTS `Recenzje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Recenzje` (
  `id` varchar(0) DEFAULT NULL,
  `ocena` varchar(0) DEFAULT NULL,
  `tresc` varchar(0) DEFAULT NULL,
  `id_uzytkownika` varchar(0) DEFAULT NULL,
  `id_ksiazki` varchar(0) DEFAULT NULL,
  `data` varchar(0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Recenzje`
--

LOCK TABLES `Recenzje` WRITE;
/*!40000 ALTER TABLE `Recenzje` DISABLE KEYS */;
/*!40000 ALTER TABLE `Recenzje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Uzytkownicy`
--

DROP TABLE IF EXISTS `Uzytkownicy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Uzytkownicy` (
  `id` tinyint(4) DEFAULT NULL,
  `nazwa` varchar(5) DEFAULT NULL,
  `email` varchar(14) DEFAULT NULL,
  `haslo` int(11) DEFAULT NULL,
  `uprawnienia` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Uzytkownicy`
--

LOCK TABLES `Uzytkownicy` WRITE;
/*!40000 ALTER TABLE `Uzytkownicy` DISABLE KEYS */;
INSERT INTO `Uzytkownicy` VALUES (1,'admin','admin@mail.com',87654321,1),(2,'user','user@mail.com',12345678,0);
/*!40000 ALTER TABLE `Uzytkownicy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Wydawnictwa`
--

DROP TABLE IF EXISTS `Wydawnictwa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Wydawnictwa` (
  `id` tinyint(4) DEFAULT NULL,
  `nazwa` varchar(17) DEFAULT NULL,
  `adres` varchar(17) DEFAULT NULL,
  `miasto` varchar(8) DEFAULT NULL,
  `kraj` varchar(6) DEFAULT NULL,
  `kod_pocztowy` varchar(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Wydawnictwa`
--

LOCK TABLES `Wydawnictwa` WRITE;
/*!40000 ALTER TABLE `Wydawnictwa` DISABLE KEYS */;
INSERT INTO `Wydawnictwa` VALUES (1,'Prószyński i S-ka','ul. Garażowa 7','Warszawa','Polska','02-651'),(2,'Helion','ul. Kościuszki 1c','Gliwice','Polska','44-100');
/*!40000 ALTER TABLE `Wydawnictwa` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-27 22:44:46
