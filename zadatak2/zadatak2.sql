-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 27, 2021 at 11:39 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `zadatak2`
--

-- --------------------------------------------------------

--
-- Table structure for table `kandidati`
--

CREATE TABLE `kandidati` (
  `id` int(11) NOT NULL,
  `ime` varchar(40) NOT NULL,
  `prezime` varchar(40) NOT NULL,
  `smer` varchar(40) NOT NULL,
  `izasao` varchar(40) NOT NULL,
  `bodovi` int(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kandidati`
--

INSERT INTO `kandidati` (`id`, `ime`, `prezime`, `smer`, `izasao`, `bodovi`) VALUES
(9, 'Dejan', 'Dejanovic RN', 'RN', 'on', 21),
(10, 'Milos', 'Dejanovic RI', 'RI', '0', 60),
(11, 'Petar', 'Mitic RI', 'RI', '1', 71),
(12, 'Darko', 'Lalic', 'S', '1', 52),
(13, 'Igor', 'Mandic', 'S', '', 41),
(14, 'Gojko', 'Karic', 'RN', '', 23),
(15, 'Milan', 'Vujic', 'RN', '', 35),
(16, 'Ime', 'Proba', 'S', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(40) NOT NULL,
  `password` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'root', 'root');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kandidati`
--
ALTER TABLE `kandidati`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `kandidati`
--
ALTER TABLE `kandidati`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
