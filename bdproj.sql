-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2023 at 03:03 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bdproj`
--

-- --------------------------------------------------------

--
-- Table structure for table `autorstwo`
--

CREATE TABLE `autorstwo` (
  `id` int(11) NOT NULL,
  `autor` smallint(6) DEFAULT NULL,
  `id_ksiazki` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `autorstwo`
--

INSERT INTO `autorstwo` (`id`, `autor`, `id_ksiazki`) VALUES
(34, 11, 15),
(35, 11, 14),
(36, 12, 16),
(37, 13, 17),
(38, 14, 18),
(39, 15, 18),
(40, 16, 19),
(41, 17, 22),
(42, 17, 21),
(43, 17, 20),
(44, 18, 23),
(45, 20, 24),
(46, 19, 24);

-- --------------------------------------------------------

--
-- Table structure for table `autorzy`
--

CREATE TABLE `autorzy` (
  `id` smallint(6) NOT NULL,
  `imiona` varchar(50) DEFAULT NULL,
  `nazwisko` varchar(30) DEFAULT NULL,
  `data_urodzenia` smallint(4) DEFAULT NULL,
  `data_smierci` smallint(4) DEFAULT NULL,
  `narodowosc` varchar(24) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `autorzy`
--

INSERT INTO `autorzy` (`id`, `imiona`, `nazwisko`, `data_urodzenia`, `data_smierci`, `narodowosc`) VALUES
(11, 'Robert Cecil', 'Martin', 1952, NULL, 'amerykańska'),
(12, 'Jakub', 'Walczak', 1994, NULL, 'polska'),
(13, 'Benjamin', 'Labatut', 1980, NULL, 'chilijska'),
(14, 'Nicholas D.', 'Kristof', 1959, NULL, 'amerykańska'),
(15, 'Sheryl', 'WuDunn', 1959, NULL, 'amerykańska'),
(16, 'Aleksandra', 'Szyłło', 1981, NULL, 'polska'),
(17, 'Astrid', 'Lindgren', 1907, 2002, 'szwedzka'),
(18, 'Filip', 'Springer', 1982, NULL, 'polska'),
(19, 'Mirosław', 'Krzyszkowski', 1964, NULL, 'polska'),
(20, 'Bogdan', 'Wasztyl', 1964, NULL, 'polska');

-- --------------------------------------------------------

--
-- Table structure for table `kategorie`
--

CREATE TABLE `kategorie` (
  `id` smallint(4) NOT NULL,
  `nazwa` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kategorie`
--

INSERT INTO `kategorie` (`id`, `nazwa`) VALUES
(1, 'Fantastyka'),
(3, 'Science-Fiction'),
(4, 'Wojenne'),
(5, 'Romantyczny'),
(6, 'Komediowy'),
(10, 'Grzybiarstwo'),
(12, 'Programowanie'),
(13, 'Literatura piękna'),
(14, 'Literatura faktu'),
(15, 'Dla dzieci');

-- --------------------------------------------------------

--
-- Table structure for table `ksiazki`
--

CREATE TABLE `ksiazki` (
  `id_ksiazki` int(11) NOT NULL,
  `tytul` varchar(50) NOT NULL,
  `wydawnictwo` smallint(6) DEFAULT NULL,
  `seria` varchar(11) DEFAULT NULL,
  `rok_wydania` smallint(4) DEFAULT NULL,
  `rok_1wydania` smallint(4) DEFAULT NULL,
  `strony` smallint(6) NOT NULL,
  `jezyk` varchar(24) NOT NULL,
  `jezyk_oryginalny` varchar(24) DEFAULT NULL,
  `tlumaczenie` varchar(30) DEFAULT NULL,
  `tytul_oryginalny` varchar(50) DEFAULT NULL,
  `kategoria` smallint(4) NOT NULL,
  `ISBN` bigint(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ksiazki`
--

INSERT INTO `ksiazki` (`id_ksiazki`, `tytul`, `wydawnictwo`, `seria`, `rok_wydania`, `rok_1wydania`, `strony`, `jezyk`, `jezyk_oryginalny`, `tlumaczenie`, `tytul_oryginalny`, `kategoria`, `ISBN`) VALUES
(14, 'Czysty kod. Podręcznik dobrego programisty', 41, NULL, 2010, 2008, 424, 'polski', 'angielski', 'Paweł Gonera', 'Clean Code: A Handbook of Agile Software Craftsman', 12, 9788328313996),
(15, 'Czysty Agile. Powrót do podstaw', 41, NULL, 2020, 2019, 184, 'polski', 'angielski', 'Wojciech Moch', 'Clean Agile: Back to Basics', 12, 9788328363045),
(16, 'Elementy inżynierii oprogramowania w Pythonie', 41, NULL, 2023, NULL, 168, 'polski', NULL, NULL, NULL, 12, 9788328394469),
(17, 'Straszliwa zieleń', 42, 'Powieści', 2023, NULL, 232, 'polski', 'hiszpański', 'Tomasz Pindel', 'Un verdor terrible', 13, 9788381916615),
(18, 'Biedni w bogatym kraju', 42, 'Amerykańska', 2022, NULL, 344, 'polski', 'angielski', 'Anna Gralak', 'Tightrope: Americans Reaching for Hope', 14, 9788381914819),
(19, 'Godzina wychowawcza', 42, 'Poza serią', 2017, NULL, 160, 'polski', NULL, NULL, NULL, 14, 9788380494916),
(20, 'Mio, mój Mio', 46, NULL, 2023, NULL, 160, 'polski', 'szwedzki', 'Maria Olszańska', 'Mio, min Mio', 15, 9788310136916),
(21, 'Dzieci z Bullerbyn', 46, NULL, 2022, NULL, 352, 'polski', 'szwedzki', 'Irena Szuch-Wyszomirska', 'Alla vi barn i Bullerbyn', 15, 9788310139221),
(22, 'Dzieci z ulicy Awanturników', 46, NULL, 2022, NULL, 128, 'polski', 'szwedzki', 'Anna Węgleńska', 'Barnen på Bråkmakargatan', 15, 9788310138392),
(23, '13 pięter', 44, NULL, 2020, NULL, 304, 'polski', NULL, NULL, NULL, 14, 9788366147348),
(24, 'Nas nie złamią', 43, NULL, 2022, NULL, 320, 'polski', NULL, NULL, NULL, 4, 9788324042029);

-- --------------------------------------------------------

--
-- Table structure for table `recenzje`
--

CREATE TABLE `recenzje` (
  `id` int(11) NOT NULL,
  `ocena` int(1) DEFAULT NULL,
  `tresc` text DEFAULT NULL,
  `id_uzytkownika` int(11) DEFAULT NULL,
  `id_ksiazki` int(11) DEFAULT NULL,
  `data` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `recenzje`
--

INSERT INTO `recenzje` (`id`, `ocena`, `tresc`, `id_uzytkownika`, `id_ksiazki`, `data`) VALUES
(2, 4, 'ysysysciufciuf', 2, NULL, '1999-06-04');

-- --------------------------------------------------------

--
-- Table structure for table `uzytkownicy`
--

CREATE TABLE `uzytkownicy` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(24) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `haslo` varchar(16) DEFAULT NULL,
  `uprawnienia` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `uzytkownicy`
--

INSERT INTO `uzytkownicy` (`id`, `nazwa`, `email`, `haslo`, `uprawnienia`) VALUES
(1, 'admin', 'admin@mail.com', '87654321', 1),
(2, 'user', 'user@mail.com', '12345678', 0),
(7, 'Szpachlarz', 'klkolakowska@gmail.com', 'Arek', 0);

-- --------------------------------------------------------

--
-- Table structure for table `wydawnictwa`
--

CREATE TABLE `wydawnictwa` (
  `id` smallint(6) NOT NULL,
  `nazwa` varchar(30) NOT NULL,
  `adres` varchar(30) DEFAULT NULL,
  `miasto` varchar(30) DEFAULT NULL,
  `kraj` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `wydawnictwa`
--

INSERT INTO `wydawnictwa` (`id`, `nazwa`, `adres`, `miasto`, `kraj`) VALUES
(41, 'Helion', 'Kościuszki 1c', 'Gliwice', 'Polska'),
(42, 'Czarne', 'Wołowiec 11', 'Sękowa', 'Polska'),
(43, 'Znak', 'Tadeusza Kościuszki 37', 'Kraków', 'Polska'),
(44, 'Karakter', 'Grabowskiego 13/1', 'Kraków', 'Polska'),
(46, 'Nasza Księgarnia', 'Apteczna 6', 'Warszawa', 'Polska');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `autorstwo`
--
ALTER TABLE `autorstwo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_autora` (`autor`),
  ADD KEY `id_ksiazki` (`id_ksiazki`),
  ADD KEY `ISBN` (`id_ksiazki`);

--
-- Indexes for table `autorzy`
--
ALTER TABLE `autorzy`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kategorie`
--
ALTER TABLE `kategorie`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `ksiazki`
--
ALTER TABLE `ksiazki`
  ADD PRIMARY KEY (`id_ksiazki`),
  ADD KEY `autor` (`wydawnictwo`,`kategoria`),
  ADD KEY `kategoria` (`kategoria`);

--
-- Indexes for table `recenzje`
--
ALTER TABLE `recenzje`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_uzytkownika` (`id_uzytkownika`,`id_ksiazki`),
  ADD KEY `id_ksiazki` (`id_ksiazki`);

--
-- Indexes for table `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `wydawnictwa`
--
ALTER TABLE `wydawnictwa`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `autorstwo`
--
ALTER TABLE `autorstwo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT for table `autorzy`
--
ALTER TABLE `autorzy`
  MODIFY `id` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `kategorie`
--
ALTER TABLE `kategorie`
  MODIFY `id` smallint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `ksiazki`
--
ALTER TABLE `ksiazki`
  MODIFY `id_ksiazki` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `recenzje`
--
ALTER TABLE `recenzje`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `wydawnictwa`
--
ALTER TABLE `wydawnictwa`
  MODIFY `id` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `autorstwo`
--
ALTER TABLE `autorstwo`
  ADD CONSTRAINT `autorstwo_ibfk_2` FOREIGN KEY (`autor`) REFERENCES `autorzy` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `autorstwo_ibfk_3` FOREIGN KEY (`id_ksiazki`) REFERENCES `ksiazki` (`id_ksiazki`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `ksiazki`
--
ALTER TABLE `ksiazki`
  ADD CONSTRAINT `ksiazki_ibfk_1` FOREIGN KEY (`kategoria`) REFERENCES `kategorie` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `ksiazki_ibfk_2` FOREIGN KEY (`wydawnictwo`) REFERENCES `wydawnictwa` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `recenzje`
--
ALTER TABLE `recenzje`
  ADD CONSTRAINT `recenzje_ibfk_2` FOREIGN KEY (`id_uzytkownika`) REFERENCES `uzytkownicy` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `recenzje_ibfk_3` FOREIGN KEY (`id_ksiazki`) REFERENCES `ksiazki` (`id_ksiazki`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
