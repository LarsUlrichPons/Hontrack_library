-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 15, 2024 at 03:45 AM
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
-- Table structure for table `book`
--

CREATE TABLE `book` (
  `ID` int(11) NOT NULL,
  `book_num` bigint(50) DEFAULT NULL,
  `bookTitle` varchar(100) DEFAULT NULL,
  `author` varchar(50) DEFAULT NULL,
  `published` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `book_stock` int(2) NOT NULL DEFAULT 0,
  `insert_date` date DEFAULT NULL,
  `update_date` date DEFAULT NULL,
  `delete_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`ID`, `book_num`, `bookTitle`, `author`, `published`, `status`, `book_stock`, `insert_date`, `update_date`, `delete_date`) VALUES
(10, 48044301, 'Malboro', 'Black', '2024-11-14', 'Available', 0, '2024-11-14', NULL, NULL),
(14, 748485700038, '555', 'tuna', '2024-11-14', 'Available', 0, '2024-11-14', NULL, NULL),
(16, 31212121, '222', '111', '2024-11-15', 'Available', 0, '2024-11-15', NULL, NULL),
(17, 33334, 'only', 'lee hi', '2024-11-15', 'Available', 0, '2024-11-15', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `fullname` varchar(50) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `usertype` varchar(50) DEFAULT NULL,
  `register_date` date DEFAULT current_timestamp(),
  `insert_date` date DEFAULT NULL,
  `update_date` date DEFAULT NULL,
  `delete_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `fullname`, `username`, `password`, `usertype`, `register_date`, `insert_date`, `update_date`, `delete_date`) VALUES
(1, 'John Doe', 'Admin', '@Admin123', 'Administrator', '2024-11-14', NULL, NULL, NULL),
(2, 'nigga tron', 'megatron', '@Kantotsahig1', 'Administrator', '2024-11-14', '2024-11-14', NULL, NULL),
(4, 'lee min ho', 'only', '@GlobeAtHome1', 'Administrator', '2024-11-14', '2024-11-14', '2024-11-14', NULL),
(6, 'Carl Jamero', 'Angelo', '!S3xdorrin', 'Administrator', '2024-11-14', '2024-11-14', NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `fullname` (`fullname`),
  ADD KEY `fullname_2` (`fullname`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `book`
--
ALTER TABLE `book`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
