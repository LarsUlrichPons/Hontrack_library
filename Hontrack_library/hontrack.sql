-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 28, 2024 at 08:12 PM
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
  `book_stock` int(2) NOT NULL,
  `insert_date` date DEFAULT NULL,
  `update_date` date DEFAULT NULL,
  `delete_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`ID`, `book_num`, `bookTitle`, `author`, `published`, `status`, `book_stock`, `insert_date`, `update_date`, `delete_date`) VALUES
(26, 9780316469050, 'Ruination: A League of Legends Novel', 'Anthony Reynolds', '2022-09-06', 'Available', 99, '2024-11-29', NULL, NULL),
(27, 9781720193869, 'The Sword of Kaigen', 'M.L. Wang', '2019-02-19', 'Available', 100, '2024-11-29', NULL, NULL),
(28, 9781635575637, 'Piranesi', 'Susanna Clarke', '2020-09-15', 'Available', 100, '2024-11-29', NULL, NULL),
(29, 9780356511528, 'The Gutter Prayer', 'Gareth Hanrahan', '2019-01-17', 'Available', 99, '2024-11-29', NULL, NULL),
(30, 9780345497512, 'The City & The City', 'China Miéville', '2009-05-26', 'Available', 100, '2024-11-29', NULL, NULL),
(31, 9780316440882, 'Jade City', 'Fonda Lee', '2018-06-26', 'Available', 100, '2024-11-29', NULL, NULL),
(32, 9781534430990, 'This Is How You Lose The War', 'Amal El-Mohtar', '2019-07-16', 'Available', 99, '2024-11-29', NULL, NULL),
(33, 9780593873359, 'Blood Over Bright Haven', 'M.L. Wang', '2024-10-29', 'Available', 100, '2024-11-29', NULL, NULL),
(34, 9781728297866, 'This Ravenous Fate', 'Hayley Dennings', '2024-08-06', 'Available', 100, '2024-11-29', NULL, NULL),
(35, 9781645660989, 'Metal From Heaven', 'August Clarke', '2024-10-22', 'Available', 99, '2024-11-29', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `book_transactions`
--

CREATE TABLE `book_transactions` (
  `transaction_id` int(11) NOT NULL,
  `ID` int(11) NOT NULL,
  `bookTitle` varchar(50) DEFAULT NULL,
  `book_num` bigint(100) DEFAULT NULL,
  `user_name` varchar(100) DEFAULT NULL,
  `issue_date` date DEFAULT NULL,
  `borrow_date` datetime DEFAULT NULL,
  `return_due` datetime DEFAULT NULL,
  `return_date` datetime DEFAULT NULL,
  `delete_date` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book_transactions`
--

INSERT INTO `book_transactions` (`transaction_id`, `ID`, `bookTitle`, `book_num`, `user_name`, `issue_date`, `borrow_date`, `return_due`, `return_date`, `delete_date`, `status`) VALUES
(46, 0, 'This Is How You Lose The War', 9781534430990, 'lars', '2024-11-29', '2024-11-29 02:45:48', '2024-11-29 02:45:03', NULL, NULL, 'Borrowed'),
(47, 0, 'The Gutter Prayer', 9780356511528, 'vob', '2024-11-29', '2024-11-29 02:45:53', '2024-11-29 02:45:03', NULL, NULL, 'Borrowed'),
(48, 0, 'Ruination: A League of Legends Novel', 9780316469050, 'rey', '2024-11-29', '2024-11-29 02:46:00', '2024-11-29 02:45:03', NULL, NULL, 'Borrowed'),
(49, 0, 'Metal From Heaven', 9781645660989, 'hans', '2024-11-29', '2024-11-29 02:46:05', '2024-11-29 02:45:03', NULL, NULL, 'Borrowed');

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
(8, 'Hanni Pham', 'hannipham', '@Hanni123', 'Employee', '2024-11-26', '2024-11-26', NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `book_transactions`
--
ALTER TABLE `book_transactions`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `ID` (`ID`),
  ADD KEY `Book_id` (`ID`),
  ADD KEY `ID_2` (`ID`);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `book_transactions`
--
ALTER TABLE `book_transactions`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
