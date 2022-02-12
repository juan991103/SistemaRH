-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-02-2022 a las 04:51:09
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sistemarh`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `Id` int(11) NOT NULL,
  `Cedula` varchar(11) NOT NULL,
  `Nombre` varchar(50) DEFAULT NULL,
  `Fecha_Ingreso` datetime NOT NULL,
  `Departamento` varchar(50) DEFAULT NULL,
  `Puesto` varchar(50) DEFAULT NULL,
  `Salario_Mensual` float NOT NULL,
  `Estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`Id`, `Cedula`, `Nombre`, `Fecha_Ingreso`, `Departamento`, `Puesto`, `Salario_Mensual`, `Estado`) VALUES
(1, '4056879932', 'Antonio', '2022-02-10 00:00:00', 'Informatica (TI)', 'Soporte de Redes', 30000, 1),
(2, '4048923467', 'Luis', '2022-02-14 00:00:00', 'Oficina Administrativa', 'Soporte de Redes', 30000, 1),
(3, '6095679210', 'Antonio', '2022-02-19 00:00:00', 'Oficina Administrativa', 'Soporte Tecnico Profesional', 45000, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `empleados`
--
ALTER TABLE `empleados`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
