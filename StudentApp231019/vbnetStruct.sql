-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2019 at 06:43 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vbnet`
--
CREATE DATABASE IF NOT EXISTS `vbnet` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `vbnet`;

-- --------------------------------------------------------

--
-- Table structure for table `delete`
--

CREATE TABLE `delete` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(30) NOT NULL,
  `MARK` double NOT NULL,
  `DEPART` int(11) NOT NULL,
  `time` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `logging`
--

CREATE TABLE `logging` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(30) NOT NULL,
  `MARK` double NOT NULL,
  `DEPART` int(11) NOT NULL,
  `time` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(30) NOT NULL,
  `MARK` double NOT NULL,
  `DEPART` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
