-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 10, 2024 at 10:48 AM
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
  `bookGenre` varchar(100) NOT NULL,
  `bookStatus` enum('Available','Unavailable') NOT NULL DEFAULT 'Available',
  `bookStock` int(4) DEFAULT NULL,
  `bookCondition` enum('New','Good','Fair') NOT NULL,
  `insertDate` date DEFAULT NULL,
  `updateDate` date DEFAULT NULL,
  `deleteDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_book`
--

INSERT INTO `tbl_book` (`ID`, `bookTitle`, `bookISBN`, `bookAuthor`, `datePublished`, `bookGenre`, `bookStatus`, `bookStock`, `bookCondition`, `insertDate`, `updateDate`, `deleteDate`) VALUES
(1, 'Ruination: A League of Legends Novel', 9780316469050, 'Anthony Reynolds', '2022-09-06', 'Fiction, Adventure', 'Available', 100, 'Good', '2024-11-29', NULL, NULL),
(2, 'The Sword of Kaigen', 9781720193869, 'M.L. Wang', '2019-02-19', 'Fiction, Military', 'Available', 98, 'Good', '2024-11-29', NULL, NULL),
(3, 'Piranesi', 9781635575637, 'Susanna Clarke', '2020-09-15', 'Fiction, Mystery', 'Available', 99, 'Good', '2024-11-29', NULL, NULL),
(4, 'The Gutter Prayer', 9780356511528, 'Gareth Hanrahan', '2019-01-17', 'Fiction, Dark Fantasy', 'Available', 98, 'New', '2024-11-29', NULL, NULL),
(5, 'The City & The City', 9780345497512, 'China Miéville', '2009-05-26', 'Sci-Fi, Mystery', 'Available', 98, 'New', '2024-11-29', NULL, NULL),
(6, 'Jade City', 9780316440882, 'Fonda Lee', '2018-06-26', 'Fiction, Urban Fantasy', 'Available', 98, 'Good', '2024-11-29', '2024-12-08', NULL),
(7, 'This Is How You Lose The War', 9781534430990, 'Amal El-Mohtar', '2019-07-16', 'Sci-Fi, Romance', 'Available', 98, 'New', '2024-11-29', NULL, NULL),
(8, 'Blood Over Bright Haven', 9780593873359, 'M.L. Wang', '2024-10-29', 'Fiction, Adventure', 'Available', 99, 'Good', '2024-11-29', '2024-12-08', NULL),
(9, 'This Ravenous Fate', 9781728297866, 'Hayley Dennings', '2024-08-06', 'Fiction, Horror', 'Available', 99, 'New', '2024-11-29', NULL, NULL),
(10, 'Metal From Heaven', 9781645660989, 'August Clarke', '2024-10-22', 'Sci-Fi, Thriller', 'Available', 98, 'New', '2024-11-29', '2024-12-06', NULL),
(18, 'Backburner', 81274817421, 'Niki', '2024-12-07', 'Romance, Horror', 'Available', 8, 'Good', '2024-12-07', '2024-12-08', NULL),
(19, 'I Love You So', 3124412, 'The Walters', '2024-12-07', 'Sad Romance', 'Available', 32, 'Good', '2024-12-07', '2024-12-08', NULL),
(20, 'Hair Polish', 4800119131581, 'Stylex', '2024-12-05', 'Fantasy, Fiction', 'Available', 1, '', '2024-12-07', '2024-12-08', NULL),
(21, '555 Tuna Caldereta', 748485700038, 'Century Pacifuc Food Inc', '2024-12-08', 'Fiction', 'Unavailable', 0, 'Fair', '2024-12-08', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_booktransac`
--

CREATE TABLE `tbl_booktransac` (
  `transac_id` int(11) NOT NULL,
  `bookISBN` bigint(13) NOT NULL,
  `bookTitle` varchar(100) NOT NULL,
  `borrowerID` varchar(50) NOT NULL,
  `borrowDate` datetime DEFAULT NULL,
  `returnDue` datetime DEFAULT NULL,
  `returnDate` datetime DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `bookGenre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_booktransac`
--

INSERT INTO `tbl_booktransac` (`transac_id`, `bookISBN`, `bookTitle`, `borrowerID`, `borrowDate`, `returnDue`, `returnDate`, `deleteDate`, `Status`, `bookGenre`) VALUES
(17, 9781720193869, 'The Sword of Kaigen', 'a12353', '2024-12-06 19:03:46', '2024-12-06 19:03:38', '2024-12-08 01:44:51', NULL, 'Returned', 'Fiction, Military'),
(18, 81274817421, 'Backburner', 'a123521', '2024-12-07 02:26:47', '2024-12-07 02:25:51', '2024-12-08 01:42:04', NULL, 'Returned', 'romance'),
(19, 4800119131581, 'Hair Polish', 'a4111234', '2024-12-07 02:55:03', '2024-12-07 02:53:28', NULL, NULL, 'Borrowed', 'Fantasy'),
(21, 9780316469050, 'Ruination: A League of Legends Novel', 'a104241231', '2024-12-31 00:00:00', '2025-01-15 00:00:00', '2024-12-08 01:28:26', NULL, 'Returned', 'Fiction, Adventure'),
(22, 9780316469050, 'Ruination: A League of Legends Novel', 'a104241231', '2024-11-03 00:00:00', '2025-01-15 00:00:00', '2024-12-08 01:28:26', NULL, 'Returned', 'Fiction, Adventure'),
(23, 4800119131581, 'Hair Polish', 'a123411', '2024-12-07 20:40:32', '2024-12-07 20:40:17', NULL, NULL, 'Borrowed', 'Fantasy'),
(24, 4800119131581, 'Hair Polish', 'a13213', '2024-12-07 20:40:38', '2024-12-07 20:40:17', '2024-12-08 01:45:10', NULL, 'Returned', 'Fantasy'),
(25, 9780316469050, 'Ruination: A League of Legends Novel', 'a123441', '2024-12-08 01:25:29', '2024-12-08 01:25:21', '2024-12-08 01:28:26', NULL, 'Returned', 'Fiction, Adventure'),
(26, 9780345497512, 'The City & The City', 'a123412', '2024-12-08 01:51:05', '2024-12-08 01:50:44', NULL, NULL, 'Borrowed', 'Sci-Fi, Mystery'),
(27, 748485700038, '555 Tuna Caldereta', 'a132512', '2024-12-08 15:38:36', '2024-12-08 15:33:43', NULL, NULL, 'Borrowed', 'Fiction');

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
  `accountStatus` enum('Active','Suspended') NOT NULL DEFAULT 'Active',
  `regdate` date DEFAULT current_timestamp(),
  `insertdate` date DEFAULT NULL,
  `updatedate` date DEFAULT NULL,
  `deletedate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_users`
--

INSERT INTO `tbl_users` (`ID`, `fullname`, `username`, `password`, `usertype`, `accountStatus`, `regdate`, `insertdate`, `updatedate`, `deletedate`) VALUES
(1, 'John Doe', 'Admin', '@Admin123', 'Librarian', 'Active', '2024-11-30', NULL, NULL, NULL),
(2, 'Cigarettes Afer Sex', 'ArticMonkeys', '@iloveCAS143', 'Staff', 'Suspended', '2024-11-30', '2024-11-30', '2024-12-08', NULL),
(3, 'Twice', 'iloveTwice', '@ifwTwice9', 'Staff', 'Active', '2024-12-08', '2024-12-08', NULL, NULL),
(4, 'Bibi', 'shibainu', '@ifwRakk1', 'Librarian', 'Active', '2024-12-08', '2024-12-08', '2024-12-08', NULL);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tbl_booktransac`
--
ALTER TABLE `tbl_booktransac`
  MODIFY `transac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `tbl_users`
--
ALTER TABLE `tbl_users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
