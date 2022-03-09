-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 09, 2022 at 08:48 AM
-- Server version: 10.7.3-MariaDB
-- PHP Version: 8.1.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbmorpionline`
--

-- --------------------------------------------------------

--
-- Table structure for table `stats`
--

CREATE TABLE `stats` (
  `idStats` int(11) NOT NULL,
  `win` int(11) NOT NULL,
  `tied` int(11) NOT NULL,
  `lose` int(11) NOT NULL,
  `idUser` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `idUser` int(11) NOT NULL,
  `username` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(95) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`idUser`, `username`, `password`) VALUES
(1, 'thelegend27', '$argon2i$v=19$m=4096,t=3,p=1$KNmjA80Htg0qMBHU8SKfLg$AtoidxyhN2rsj2bi94jeVA8ppcoDtvZLEoa6UEmd034'),
(2, 'Darius', '$argon2i$v=19$m=4096,t=3,p=1$XBHdqv95/QmAV+mM+YymrA$nZV3RCU1Y3PnkpGgYKSDGD4l2RFRqZp5ukJEVehPq34'),
(3, 'Sejuani', '$argon2i$v=19$m=4096,t=3,p=1$FKTDzpjMciOsdJ5sLimFQg$1GYOL/0LJQkRIFb/vQutQyksfWafINcYQKgPdLfvVmI'),
(4, 'Kevin', '$argon2i$v=19$m=4096,t=3,p=1$3q1yjtpQ6vR4MNnzI6TsJw$p1i9mM/gflfrO11EQmy4XurxA3vIPlicuss/pTDxMR0'),
(5, 'GigaChad', '$argon2i$v=19$m=4096,t=3,p=1$Saz/2HUXpL9uiqK4S92SQA$FiXWoHkUXW5W+pRUfO7ZsexOmi8YyoQH4NAxNsXYMQM'),
(6, 'Michel', '$argon2i$v=19$m=4096,t=3,p=1$Oob72YwS+KWN/240Qy5vzQ$cXbGiubATe6Uk6DDLGur7Sz6XYixKZ/It0CzL6hJq+Y'),
(7, 'Booba', '$argon2i$v=19$m=4096,t=3,p=1$X/v0s1QVchBoshuN4bkCHQ$fWmwDuTdKFpe/UUyYzXpbGvOfHU0/YVmwBYh/r67hg0'),
(8, 'Rat', '$argon2i$v=19$m=4096,t=3,p=1$sRK72tDiCV+EvBv3eWJprA$0W08On9eSzaFVknPUS8Wne44pqg6b1mKoW9fiTZiZQo'),
(9, 'Hugo', '$argon2i$v=19$m=4096,t=3,p=1$HBlC1YQOspWsSPvI08R6bQ$MDMAVhOge8AtHTzRwWBvBp/XjZHvKTcxQvf4ksGKuXk');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `stats`
--
ALTER TABLE `stats`
  ADD PRIMARY KEY (`idStats`),
  ADD KEY `idUser` (`idUser`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`idUser`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `stats`
--
ALTER TABLE `stats`
  MODIFY `idStats` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `stats`
--
ALTER TABLE `stats`
  ADD CONSTRAINT `stats_ibfk_1` FOREIGN KEY (`idUser`) REFERENCES `users` (`idUser`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
