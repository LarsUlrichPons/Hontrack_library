@ -0,0 +1,184 @@
-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 02, 2024 at 11:37 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hontrack`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_book`
--

CREATE TABLE `tbl_book` (
  `ID` int(11) NOT NULL,
  `bookTitle` varchar(100) NOT NULL,
  `bookISBN` bigint(13) DEFAULT NULL,
  `bookAuthor` varchar(50) NOT NULL,
  `datePublished` date DEFAULT NULL,
  `bookStatus` enum('available','outofstock') NOT NULL DEFAULT 'available',
  `bookStock` int(4) DEFAULT NULL,
  `insertDate` date DEFAULT NULL,
  `updateDate` date DEFAULT NULL,
  `deleteDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_book`
--

INSERT INTO `tbl_book` (`ID`, `bookTitle`, `bookISBN`, `bookAuthor`, `datePublished`, `bookStatus`, `bookStock`, `insertDate`, `updateDate`, `deleteDate`) VALUES
(1, 'Ruination: A League of Legends Novel', 9780316469050, 'Anthony Reynolds', '2022-09-06', 'available', 98, '2024-11-29', NULL, NULL),
(2, 'The Sword of Kaigen', 9781720193869, 'M.L. Wang', '2019-02-19', 'available', 99, '2024-11-29', NULL, NULL),
(3, 'Piranesi', 9781635575637, 'Susanna Clarke', '2020-09-15', 'available', 99, '2024-11-29', NULL, NULL),
(4, 'The Gutter Prayer', 9780356511528, 'Gareth Hanrahan', '2019-01-17', 'available', 98, '2024-11-29', NULL, NULL),
(5, 'The City & The City', 9780345497512, 'China Miéville', '2009-05-26', 'available', 99, '2024-11-29', NULL, NULL),
(6, 'Jade City', 9780316440882, 'Fonda Lee', '2018-06-26', 'available', 98, '2024-11-29', NULL, NULL),
(7, 'This Is How You Lose The War', 9781534430990, 'Amal El-Mohtar', '2019-07-16', 'available', 98, '2024-11-29', NULL, NULL),
(8, 'Blood Over Bright Haven', 9780593873359, 'M.L. Wang', '2024-10-29', 'available', 99, '2024-11-29', NULL, NULL),
(9, 'This Ravenous Fate', 9781728297866, 'Hayley Dennings', '2024-08-06', 'available', 99, '2024-11-29', NULL, NULL),
(10, 'Metal From Heaven', 9781645660989, 'August Clarke', '2024-10-22', 'available', 98, '2024-11-29', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_booktransac`
--

CREATE TABLE `tbl_booktransac` (
  `transac_id` int(11) NOT NULL,
  `bookISBN` bigint(13) NOT NULL,
  `bookTitle` varchar(100) NOT NULL,
  `borrowerName` varchar(50) NOT NULL,
  `borrowDate` datetime DEFAULT NULL,
  `returnDue` datetime DEFAULT NULL,
  `returnDate` datetime DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_booktransac`
--

INSERT INTO `tbl_booktransac` (`transac_id`, `bookISBN`, `bookTitle`, `borrowerName`, `borrowDate`, `returnDue`, `returnDate`, `deleteDate`, `Status`) VALUES
(1, 9780316440882, 'Jade City', 'kayle', '2024-11-30 21:48:35', '2024-11-30 21:48:11', NULL, NULL, 'Borrowed'),
(2, 9781720193869, 'The Sword of Kaigen', 'charlie', '2024-11-30 22:18:52', '2024-11-30 22:18:34', '2024-11-30 22:20:07', NULL, 'Returned'),
(3, 9781720193869, 'The Sword of Kaigen', 'ykim', '2024-11-30 22:27:50', '2024-11-30 22:27:43', '2024-11-30 22:41:26', NULL, 'Returned'),
(4, 9780316469050, 'Ruination: A League of Legends Novel', 'skz', '2024-12-01 21:48:29', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(5, 9781720193869, 'The Sword of Kaigen', 'skz', '2024-12-01 21:48:33', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(6, 9781635575637, 'Piranesi', 'skz', '2024-12-01 21:48:38', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(7, 9780356511528, 'The Gutter Prayer', 'skz', '2024-12-01 21:48:42', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(8, 9780345497512, 'The City & The City', 'skz', '2024-12-01 21:48:46', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(9, 9780316440882, 'Jade City', 'skz', '2024-12-01 21:48:50', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(10, 9781534430990, 'This Is How You Lose The War', 'skz', '2024-12-01 21:48:54', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(11, 9780593873359, 'Blood Over Bright Haven', 'skz', '2024-12-01 21:48:58', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(12, 9781728297866, 'This Ravenous Fate', 'skz', '2024-12-01 21:49:02', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed'),
(13, 9781645660989, 'Metal From Heaven', 'skz', '2024-12-01 21:49:06', '2024-12-01 21:47:48', NULL, NULL, 'Borrowed');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_users`
--

CREATE TABLE `tbl_users` (
  `ID` int(11) NOT NULL,
  `fullname` varchar(100) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `usertype` enum('Librarian','Staff') NOT NULL,
  `regdate` date DEFAULT current_timestamp(),
  `insertdate` date DEFAULT NULL,
  `updatedate` date DEFAULT NULL,
  `deletedate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_users`
--

INSERT INTO `tbl_users` (`ID`, `fullname`, `username`, `password`, `usertype`, `regdate`, `insertdate`, `updatedate`, `deletedate`) VALUES
(1, 'John Doe', 'Admin', '@Admin123', 'Librarian', '2024-11-30', NULL, NULL, NULL),
(2, 'cigarettes afer sex', 'radiohead', '@iloveCAS143', 'Staff', '2024-11-30', '2024-11-30', '2024-11-30', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_book`
--
ALTER TABLE `tbl_book`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `bookISBN` (`bookISBN`),
  ADD UNIQUE KEY `bookISBN_3` (`bookISBN`),
  ADD KEY `bookISBN_2` (`bookISBN`);

--
-- Indexes for table `tbl_booktransac`
--
ALTER TABLE `tbl_booktransac`
  ADD PRIMARY KEY (`transac_id`),
  ADD KEY `bookISBN` (`bookISBN`);

--
-- Indexes for table `tbl_users`
--
ALTER TABLE `tbl_users`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fullname` (`fullname`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_book`
--
ALTER TABLE `tbl_book`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tbl_booktransac`
--
ALTER TABLE `tbl_booktransac`
  MODIFY `transac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tbl_users`
--
ALTER TABLE `tbl_users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_booktransac`
--
ALTER TABLE `tbl_booktransac`
  ADD CONSTRAINT `tbl_booktransac_ibfk_1` FOREIGN KEY (`bookISBN`) REFERENCES `tbl_book` (`bookISBN`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;