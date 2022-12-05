-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-12-2022 a las 06:22:11
-- Versión del servidor: 10.4.21-MariaDB
-- Versión de PHP: 8.0.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `segundoparcial`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujo`
--

CREATE TABLE `flujo` (
  `flujo` varchar(4) DEFAULT NULL,
  `proceso` varchar(4) DEFAULT NULL,
  `proceso_siguiente` varchar(4) DEFAULT NULL,
  `tipo` varchar(2) DEFAULT NULL,
  `rol` varchar(20) DEFAULT NULL,
  `pantalla` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `flujo`
--

INSERT INTO `flujo` (`flujo`, `proceso`, `proceso_siguiente`, `tipo`, `rol`, `pantalla`) VALUES
('F1', 'P1', 'P2', 'I', 'Alumno', 'inicial'),
('F1', 'P2', 'P3', 'P', 'Alumno', 'datos'),
('F1', 'P3', 'P4', 'P', 'Alumno', 'envio'),
('F1', 'P4', '-', 'C', 'Kardex', 'revision'),
('F1', 'P5', 'P2', 'P', 'Kardex', 'no'),
('F1', 'P6', 'P7', 'P', 'Kardex', 'si'),
('F1', 'P7', NULL, 'F', 'Alumno', 'inscripcion');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujocondicion`
--

CREATE TABLE `flujocondicion` (
  `flujo` varchar(3) DEFAULT NULL,
  `proceso` varchar(3) DEFAULT NULL,
  `procesoSI` varchar(3) DEFAULT NULL,
  `procesoNO` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `flujocondicion`
--

INSERT INTO `flujocondicion` (`flujo`, `proceso`, `procesoSI`, `procesoNO`) VALUES
('F1', 'P4', 'P6', 'P5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujotramite`
--

CREATE TABLE `flujotramite` (
  `Flujo` varchar(5) DEFAULT NULL,
  `proceso` varchar(5) DEFAULT NULL,
  `nro_tramite` varchar(10) DEFAULT NULL,
  `fechaini` datetime DEFAULT NULL,
  `fechafin` datetime DEFAULT NULL,
  `usuario` varchar(30) DEFAULT NULL,
  `usuario_tarea` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `flujotramite`
--

INSERT INTO `flujotramite` (`Flujo`, `proceso`, `nro_tramite`, `fechaini`, `fechafin`, `usuario`, `usuario_tarea`) VALUES
('F1', 'P1', '1000', '2022-11-23 23:55:00', '2022-12-05 06:19:15', 'FuryAlumno', 'FuryAlumno'),
('F1', 'P1', '1001', '2022-10-23 21:55:00', NULL, 'FuryAlumno', 'FuryAlumno'),
('F1', 'P1', '1002', '2022-11-29 13:55:00', NULL, 'FuryAlumno', 'FuryAlumno'),
('F1', 'P2', '2001', '2020-09-22 13:35:00', NULL, 'OsvaldoAlumno', 'OsvaldoAlumno'),
('F1', 'P1', '2002', '2019-06-21 11:45:00', NULL, 'OsvaldoAlumno', 'OsvaldoAlumno'),
('F1', 'P1', '2003', '2018-12-21 23:55:00', NULL, 'OsvaldoAlumno', 'OsvaldoAlumno'),
('F1', 'P3', '3001', '2020-11-20 15:00:00', NULL, 'TouristAlumno', 'TouristAlumno'),
('F1', 'P1', '3002', '2021-02-17 11:02:00', NULL, 'TouristAlumno', 'TouristAlumno'),
('F1', 'P1', '3003', '2022-01-17 19:03:00', NULL, 'TouristAlumno', 'TouristAlumno'),
('F1', 'P2', '1000', '2022-12-05 06:19:15', '2022-12-05 06:19:31', 'FuryAlumno', 'FuryAlumno'),
('F1', 'P3', '1000', '2022-12-05 06:19:31', '2022-12-05 06:19:49', 'FuryAlumno', 'FuryAlumno'),
('F1', 'P4', '1000', '2022-12-05 06:19:49', '2022-12-05 06:20:02', 'JuanKardex', 'FuryAlumno'),
('F1', 'P6', '1000', '2022-12-05 06:20:02', '2022-12-05 06:20:03', 'JuanKardex', 'JuanKardex'),
('F1', 'P7', '1000', '2022-12-05 06:20:03', '2022-12-05 06:20:12', 'FuryAlumno', 'JuanKardex');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE `rol` (
  `id` varchar(11) NOT NULL,
  `descipcion` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`id`, `descipcion`) VALUES
('1', 'Alumno'),
('2', 'Kardex'),
('3', 'Prefas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rolusuario`
--

CREATE TABLE `rolusuario` (
  `IdRol` varchar(11) DEFAULT NULL,
  `IdUsuario` varchar(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `rolusuario`
--

INSERT INTO `rolusuario` (`IdRol`, `IdUsuario`) VALUES
('1', '1'),
('1', '2'),
('1', '3'),
('2', '4'),
('3', '5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id` varchar(11) NOT NULL,
  `descripcion` varchar(20) DEFAULT NULL,
  `pass` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `descripcion`, `pass`) VALUES
('1', 'FuryAlumno', '7c4a8d09ca3762af61e59520943dc26494f8941b'),
('2', 'OsvaldoAlumno', '7c4a8d09ca3762af61e59520943dc26494f8941b'),
('3', 'TouristAlumno', '7c4a8d09ca3762af61e59520943dc26494f8941b'),
('4', 'JuanKardex', '7c4a8d09ca3762af61e59520943dc26494f8941b'),
('5', 'AlanPrefas', '7c4a8d09ca3762af61e59520943dc26494f8941b');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
