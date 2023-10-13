-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2018 at 09:56 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `rpg`
--

-- --------------------------------------------------------

--
-- Table structure for table `abilitate`
--

CREATE TABLE IF NOT EXISTS `abilitate` (
  `cod_abilitate` int(11) NOT NULL AUTO_INCREMENT,
  `cod_c` int(3) DEFAULT NULL,
  `nume` varchar(70) NOT NULL,
  `cost` int(2) NOT NULL,
  `descriere` varchar(300) NOT NULL,
  `adr_poza` varchar(200) NOT NULL,
  `cod_nat` int(3) NOT NULL,
  `cod_af` int(3) NOT NULL,
  `durata` int(3) NOT NULL,
  `timp_reincarc` int(1) NOT NULL,
  PRIMARY KEY (`cod_abilitate`),
  KEY `cod_c` (`cod_c`),
  KEY `cod_c_2` (`cod_c`),
  KEY `cod_nat` (`cod_nat`),
  KEY `cod_nat_2` (`cod_nat`),
  KEY `cod_af` (`cod_af`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `abilitate`
--

INSERT INTO `abilitate` (`cod_abilitate`, `cod_c`, `nume`, `cost`, `descriere`, `adr_poza`, `cod_nat`, `cod_af`, `durata`, `timp_reincarc`) VALUES
(1, 1, 'Lovitură sabie', 0, 'Provoacă 15 daune fizice\r\nunui singur inamic\r\nCost: 0 energie\r\nReîncărcare: 0 ture', 'Razboinic\\Lovitura_sabie.jpg', 1, 1, 1, 0),
(2, 2, 'Lovitură săgeată', 0, 'Provoacă 15 daune fizice\r\nunui singur inamic\r\nCost: 0 energie\r\nReîncărcare: 0 ture', 'Arcas\\Lovitura_sageata.jpg', 1, 1, 1, 0),
(3, 3, 'Vindeca', 15, 'Vindecă un aliat sau pe sine\r\nrestaurând 20 puncte de viață\r\nCost: 15 energie\r\nReîncărcare: 0 ture', 'Tamaduitor\\Vindeca.jpg', 2, 2, 1, 0),
(4, 4, 'Sferă de foc', 25, 'Provoacă 20 pagube magice unui inamic\r\nși îi lasă arsuri care provoacă câte\r\n10 pagube magice ce ignoră scuturi în\r\nurmătoarele 2 ture.\r\nCost: 25 energie\r\nReîncărcare: 2 ture', 'Vrajitor\\Sfera_foc.jpg', 2, 1, 1, 3),
(6, NULL, 'Lovitură cuțit', 0, 'Provoacă 20 daune fizice', 'Necromant\\Atac_cutit.jpg', 1, 1, 1, 0),
(7, NULL, 'Muşcătură', 0, 'Provoacă 10 daune fizice\r\nşi cauzează o sângerare\r\nConsum:0 energie\r\nReîncărcare:0 ture', 'Lup/muscatura.jpg', 1, 1, 1, 0),
(8, NULL, 'Urlet de lup', 5, 'Scade punctele de atac fizice\r\na tuturor inamicilor cu 5 puncte\r\nCost: 5 energie\r\nReîncărcare: 0 ture', 'Lup/urlet.jpg', 1, 4, 1, 0),
(9, 1, 'Apărare scut', 0, 'Se apără pe sine sau un aliat\r\nreducând atacurile asupra\r\npersonajului apărat cu 20 de puncte\r\nCost: 0 energie\r\nReîncărcare: 0 ture', 'Razboinic\\Aparare_scut.jpg', 1, 2, 1, 0),
(10, 1, 'Placare', 20, 'Loveşte un inamic cu scutul\r\nprovocând 5 puncte de daune fizice\r\nşi paralizându-l.Abilitatea "Lovitură\r\nsabie" va provoca 10 puncte de daune fizice\r\nîn plus dacă e folosită tura următoare\r\nCost: 20 energie\r\nReîncărcare: 1 tură\r\n', 'Razboinic//Placare.jpg', 1, 1, 1, 1),
(11, 1, 'Strigăt de luptă', 5, 'Măreşte atacurile fizice ale\r\ntuturor aliaţilor cu 5 puncte\r\nîn tura folosirii şi imediat\r\nurmătoare.\r\nCost: 5 energie\r\nReîncărcare: 1 tură', 'Razboinic/Strigat_lupta.jpg', 1, 4, 1, 1),
(12, 2, 'Ţintire', 15, 'Ţinteşte un inamic,în următoarele\r\n2 ture "Lovitură săgeată" şi\r\n"Lovitură dublă săgeată" vor\r\ncauza +15 daune acelui inamic\r\nCost: 15 energie\r\nReîncărcare: 3 ture', 'Arcas/Tintire.jpg', 1, 1, 2, 3),
(13, 2, 'Lovitură dublă săgeată', 15, 'Loveşte un singur inamic de două\r\nori într-o singură tură,dar blochează\r\n"Lovitură săgeată" în tura următoare\r\nfolosirii acestei abilităţi\r\nNotă: Bonusul de atac de la abilitatea\r\n"Ţintire" se aplică doar pentru o\r\nlovitură din cele două.\r\nCost: 15 energie\r\nReîncărcare: 2 ture', 'Arcas/Lovitura_dubla.jpg', 1, 1, 1, 2),
(14, 2, 'Ploaie de săgeţi', 15, 'Arcaşul trage la întâmplare cu\r\nmai multe săgeţi asupra întregului\r\ngrup de inamici.Un inamic la\r\nîntâmplare va suferi 15 daune fizice,\r\naltul 10,iar cel de-al treilea 5.\r\nConsum: 15 energie\r\nReîncărare: 2 ture', 'Arcas/Ploaie_de_sageti.jpg', 1, 3, 1, 1),
(15, 3, 'Regenerare', 20, 'Timp de 3 ture,toate rănile\r\npersonajului se vor închide\r\niar acesta se va vindeca câte\r\n5 puncte/tură.\r\nConsum: 20 energie\r\nReîncărare: 3 ture', 'Tamaduitor\\Regenerare.jpg', 2, 2, 3, 3),
(16, 3, 'Vindecare în masă', 30, 'Vindecă fiecare personaj cu\r\ncâte 15 puncte de viaţă.\r\nCost: 30 energie\r\nReîncărcare: 2 ture\r\n', 'Tamaduitor\\Vindecare_mas.jpg', 2, 4, 1, 2),
(17, 4, 'Viscol', 30, 'Timp de 3 ture crează un viscol care\r\nprovoacă câte 10 daune/tură şi,din tura\r\nurmătoare folosirii viscolului,degerături\r\ntuturor inamicilor afectaţi de viscol\r\nInamicii afectaţi de degerături vor cauza\r\ncu 10 puncte mai puţin daune fizice.\r\nConsum: 30 energie\r\nReîncărare: 4 ture', 'Vrajitor\\Viscol.jpg', 2, 3, 3, 4),
(18, 4, 'Iederă agăţătoare', 20, 'Numeroase viţe de iederă tâşnesc\r\ndintr-o suprafaţă apropiată unui\r\ninamic şi îl paralizează timp de\r\n2 ture,îi cauzează 5 daune/tură şi\r\nîi fură câte 5 energie/tură.\r\nConsum: 20 energie\r\nReîncărare: 2 ture', 'Vrajitor\\Iedera.jpg', 2, 1, 2, 3),
(19, NULL, 'Lovitură toiag', 0, 'Loveşte un inamic provocând\r\n5 daune fizice\r\nConsum: 0 energie\r\nReîncărare: 0 ture', 'Vrajitor\\Lovitura_toiag.jpg', 1, 1, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `abilitate_afecteaza`
--

CREATE TABLE IF NOT EXISTS `abilitate_afecteaza` (
  `cod_afect` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(100) NOT NULL,
  PRIMARY KEY (`cod_afect`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `abilitate_afecteaza`
--

INSERT INTO `abilitate_afecteaza` (`cod_afect`, `nume`) VALUES
(1, 'un_inamic'),
(2, 'sine_sau_un_aliat'),
(3, 'toti_inamicii'),
(4, 'sine+toti_aliatii');

-- --------------------------------------------------------

--
-- Table structure for table `abilitate_inamic`
--

CREATE TABLE IF NOT EXISTS `abilitate_inamic` (
  `cod_ai` int(11) NOT NULL AUTO_INCREMENT,
  `cod_a` int(3) NOT NULL,
  `cod_i` int(3) NOT NULL,
  `nr_slot` int(1) NOT NULL,
  PRIMARY KEY (`cod_ai`),
  KEY `cod_a` (`cod_a`),
  KEY `cod_inm` (`cod_i`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `abilitate_inamic`
--

INSERT INTO `abilitate_inamic` (`cod_ai`, `cod_a`, `cod_i`, `nr_slot`) VALUES
(1, 6, 1, 4),
(2, 7, 2, 1),
(3, 8, 2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `abilitate_personaj`
--

CREATE TABLE IF NOT EXISTS `abilitate_personaj` (
  `id_ab_pers` int(3) NOT NULL AUTO_INCREMENT,
  `cod_a` int(3) NOT NULL,
  `cod_p` int(3) NOT NULL,
  `nr_slot` int(2) NOT NULL,
  PRIMARY KEY (`id_ab_pers`),
  KEY `cod_a` (`cod_a`),
  KEY `cod_p` (`cod_p`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `abilitate_personaj`
--

INSERT INTO `abilitate_personaj` (`id_ab_pers`, `cod_a`, `cod_p`, `nr_slot`) VALUES
(1, 19, 3, 1),
(2, 3, 3, 2),
(3, 16, 3, 3),
(4, 15, 3, 4),
(5, 2, 2, 1),
(6, 12, 2, 2),
(7, 13, 2, 3),
(8, 14, 2, 4),
(9, 9, 1, 2),
(10, 1, 1, 1),
(11, 10, 1, 3),
(12, 11, 1, 4),
(13, 19, 6, 1),
(14, 4, 6, 2),
(15, 17, 6, 3),
(16, 18, 6, 4),
(17, 19, 5, 1),
(18, 3, 5, 2),
(19, 16, 5, 3),
(20, 15, 5, 4),
(21, 9, 4, 2),
(22, 1, 4, 1),
(23, 10, 4, 3),
(24, 11, 4, 4);

-- --------------------------------------------------------

--
-- Table structure for table `clasa`
--

CREATE TABLE IF NOT EXISTS `clasa` (
  `cod_clasa` int(4) NOT NULL AUTO_INCREMENT,
  `nume` varchar(200) CHARACTER SET utf16 NOT NULL,
  `descriere` varchar(700) CHARACTER SET utf8 NOT NULL,
  `adr_poza` varchar(200) CHARACTER SET utf16 NOT NULL,
  PRIMARY KEY (`cod_clasa`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `clasa`
--

INSERT INTO `clasa` (`cod_clasa`, `nume`, `descriere`, `adr_poza`) VALUES
(1, 'Războinic', 'Clasă ce se specializează în lupta fizică\r\ncorp la corp.Poate folosi: săbii șiscuturi.', 'Razboinic.png'),
(2, 'Arcaș', 'Clasă ce se specializează în atacuri fizice\r\nde la distanță.', 'Arcas.png'),
(3, 'Tămăduitor', 'Clasă ce se specializează în susținerea aliaților\r\ncu vrăji de vindecare,binecuvântare,etc.', 'Tamaduitor.png'),
(4, 'Vrăjitor', 'Clasă ce se specializează\r\nîn vrăji ofensive ', 'Vrajitor.png');

-- --------------------------------------------------------

--
-- Table structure for table `efect`
--

CREATE TABLE IF NOT EXISTS `efect` (
  `cod_efect` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(50) NOT NULL,
  `atac` int(3) DEFAULT NULL,
  `atac_direct` int(3) DEFAULT NULL,
  `vindecare` int(3) DEFAULT NULL,
  `scut` int(3) DEFAULT NULL,
  `paraliz` int(1) DEFAULT NULL,
  `invul` int(1) DEFAULT NULL,
  `contra` int(1) DEFAULT NULL,
  `durata_efect` int(3) NOT NULL,
  `cod_af` int(1) NOT NULL,
  PRIMARY KEY (`cod_efect`),
  KEY `cod_af` (`cod_af`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `efect`
--

INSERT INTO `efect` (`cod_efect`, `nume`, `atac`, `atac_direct`, `vindecare`, `scut`, `paraliz`, `invul`, `contra`, `durata_efect`, `cod_af`) VALUES
(1, 'Dmg fizic 15', 15, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1),
(2, 'Dmg fizic 20', 20, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1),
(3, 'Vindeca 20', NULL, NULL, 20, NULL, NULL, NULL, NULL, 1, 2),
(4, 'Dmg magic 20', 20, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1),
(5, 'Arsura', NULL, 10, NULL, NULL, NULL, NULL, NULL, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `efect_afecteaza`
--

CREATE TABLE IF NOT EXISTS `efect_afecteaza` (
  `cod_afect` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(70) NOT NULL,
  PRIMARY KEY (`cod_afect`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `efect_afecteaza`
--

INSERT INTO `efect_afecteaza` (`cod_afect`, `nume`) VALUES
(1, 'un_inamic'),
(2, 'sine_sau_un_aliat'),
(3, 'toti_inamicii'),
(4, 'sine+toti_aliatii');

-- --------------------------------------------------------

--
-- Table structure for table `efect_al_abilitatii`
--

CREATE TABLE IF NOT EXISTS `efect_al_abilitatii` (
  `cod_a` int(3) NOT NULL,
  `cod_e` int(3) NOT NULL,
  KEY `cod_a` (`cod_a`,`cod_e`),
  KEY `cod_e` (`cod_e`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `efect_al_abilitatii`
--

INSERT INTO `efect_al_abilitatii` (`cod_a`, `cod_e`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(4, 5),
(6, 2);

-- --------------------------------------------------------

--
-- Table structure for table `grup`
--

CREATE TABLE IF NOT EXISTS `grup` (
  `cod_grup` int(3) NOT NULL AUTO_INCREMENT,
  `aur` int(7) NOT NULL,
  PRIMARY KEY (`cod_grup`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `grup`
--

INSERT INTO `grup` (`cod_grup`, `aur`) VALUES
(1, 500),
(2, 500);

-- --------------------------------------------------------

--
-- Table structure for table `inamic`
--

CREATE TABLE IF NOT EXISTS `inamic` (
  `cod_inamic` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(70) NOT NULL,
  `viata` int(3) NOT NULL,
  `viata_max` int(3) NOT NULL,
  `eng` int(3) NOT NULL,
  `eng_max` int(3) NOT NULL,
  `recompensa_exp` int(3) NOT NULL,
  `recompensa_aur` int(4) NOT NULL,
  `adr_poza` varchar(30) NOT NULL,
  `cod_ab` int(3) NOT NULL,
  `cod_itm` int(3) NOT NULL,
  PRIMARY KEY (`cod_inamic`),
  KEY `cod_ab` (`cod_ab`),
  KEY `cod_itm` (`cod_itm`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `inamic`
--

INSERT INTO `inamic` (`cod_inamic`, `nume`, `viata`, `viata_max`, `eng`, `eng_max`, `recompensa_exp`, `recompensa_aur`, `adr_poza`, `cod_ab`, `cod_itm`) VALUES
(1, 'Necromant', 200, 200, 200, 200, 1000, 5000, 'necromant.jpg', 0, 0),
(2, 'Lup', 50, 50, 50, 50, 100, 100, 'lup.jpg', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE IF NOT EXISTS `item` (
  `cod_item` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(30) NOT NULL,
  `atac` int(3) NOT NULL,
  `atac_direct` int(3) NOT NULL,
  `scut` int(2) NOT NULL,
  `vindecare` int(3) NOT NULL,
  `paraliz` int(1) NOT NULL,
  `invul` int(1) NOT NULL,
  `consumabil` int(1) NOT NULL,
  PRIMARY KEY (`cod_item`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `item_inamic`
--

CREATE TABLE IF NOT EXISTS `item_inamic` (
  `cod_itm` int(3) NOT NULL,
  `cod_inam` int(3) NOT NULL,
  `cantitate` int(4) NOT NULL,
  `nr_slot` int(11) NOT NULL,
  KEY `cod_itm` (`cod_itm`),
  KEY `cod_inam` (`cod_inam`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `item_personaj`
--

CREATE TABLE IF NOT EXISTS `item_personaj` (
  `cod_itm` int(3) NOT NULL,
  `cod_pers` int(3) NOT NULL,
  `cantitate` int(4) NOT NULL,
  `nr_slot` int(2) NOT NULL,
  KEY `cod_itm` (`cod_itm`,`cod_pers`),
  KEY `cod_itm_2` (`cod_itm`),
  KEY `cod_inam` (`cod_pers`),
  KEY `cod_pers` (`cod_pers`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Table structure for table `natura`
--

CREATE TABLE IF NOT EXISTS `natura` (
  `cod_natura` int(3) NOT NULL AUTO_INCREMENT,
  `nume` varchar(30) NOT NULL,
  PRIMARY KEY (`cod_natura`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `natura`
--

INSERT INTO `natura` (`cod_natura`, `nume`) VALUES
(1, 'fizica'),
(2, 'magica');

-- --------------------------------------------------------

--
-- Table structure for table `personaj`
--

CREATE TABLE IF NOT EXISTS `personaj` (
  `cod_pers` int(4) NOT NULL AUTO_INCREMENT,
  `nume` varchar(75) CHARACTER SET utf16 NOT NULL,
  `numar` int(1) NOT NULL,
  `cod_cl` int(4) NOT NULL,
  `cod_gr` int(3) NOT NULL,
  `cod_port` int(3) NOT NULL,
  `viata` int(4) NOT NULL,
  `viata_max` int(4) NOT NULL,
  `eng` int(4) NOT NULL,
  `eng_max` int(4) NOT NULL,
  `nivel` int(3) NOT NULL,
  `exp` int(4) NOT NULL,
  `exp_urm` int(4) NOT NULL,
  PRIMARY KEY (`cod_pers`),
  KEY `cod_port` (`cod_port`),
  KEY `cod_port_2` (`cod_port`),
  KEY `cod_cl` (`cod_cl`),
  KEY `cod_cl_2` (`cod_cl`),
  KEY `cod_gr` (`cod_gr`),
  KEY `cod_gr_2` (`cod_gr`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `personaj`
--

INSERT INTO `personaj` (`cod_pers`, `nume`, `numar`, `cod_cl`, `cod_gr`, `cod_port`, `viata`, `viata_max`, `eng`, `eng_max`, `nivel`, `exp`, `exp_urm`) VALUES
(1, 'Leontin', 1, 1, 1, 18, 120, 120, 50, 50, 1, 15, 50),
(2, 'Andrei', 2, 2, 1, 2, 80, 90, 75, 75, 1, 15, 50),
(3, 'Sergiu', 3, 3, 1, 8, 60, 70, 100, 100, 1, 15, 50),
(4, 'Marcel', 1, 1, 2, 19, 120, 120, 50, 50, 1, 0, 50),
(5, 'Dan', 2, 3, 2, 21, 70, 70, 100, 100, 1, 0, 50),
(6, 'Vasile', 3, 4, 2, 9, 70, 70, 100, 100, 1, 0, 50);

-- --------------------------------------------------------

--
-- Table structure for table `portret`
--

CREATE TABLE IF NOT EXISTS `portret` (
  `cod_portret` int(4) NOT NULL AUTO_INCREMENT,
  `adr_poza` varchar(200) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`cod_portret`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf32 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `portret`
--

INSERT INTO `portret` (`cod_portret`, `adr_poza`) VALUES
(1, 'Aileen.png'),
(2, 'Alec.png'),
(3, 'Andrew.png'),
(4, 'Ashita.png'),
(5, 'Bjin.png'),
(6, 'Branko.png'),
(7, 'Brendan.png'),
(8, 'Florent.png'),
(9, 'Fred.png'),
(10, 'Jeanne.png'),
(11, 'Joi.png'),
(12, 'Jonas.png'),
(13, 'Jord.png'),
(14, 'Jordan.png'),
(15, 'Kain.png'),
(16, 'Laura.png'),
(17, 'Leslie.png'),
(18, 'Lessig.png'),
(19, 'Linksvayer.png'),
(20, 'Marcos.png'),
(21, 'Markus.png'),
(22, 'Maxime.png');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `abilitate`
--
ALTER TABLE `abilitate`
  ADD CONSTRAINT `abilitate_ibfk_1` FOREIGN KEY (`cod_c`) REFERENCES `clasa` (`cod_clasa`),
  ADD CONSTRAINT `abilitate_ibfk_2` FOREIGN KEY (`cod_nat`) REFERENCES `natura` (`cod_natura`),
  ADD CONSTRAINT `abilitate_ibfk_3` FOREIGN KEY (`cod_af`) REFERENCES `abilitate_afecteaza` (`cod_afect`);

--
-- Constraints for table `abilitate_inamic`
--
ALTER TABLE `abilitate_inamic`
  ADD CONSTRAINT `abilitate_inamic_ibfk_1` FOREIGN KEY (`cod_a`) REFERENCES `abilitate` (`cod_abilitate`),
  ADD CONSTRAINT `abilitate_inamic_ibfk_2` FOREIGN KEY (`cod_i`) REFERENCES `inamic` (`cod_inamic`);

--
-- Constraints for table `abilitate_personaj`
--
ALTER TABLE `abilitate_personaj`
  ADD CONSTRAINT `abilitate_personaj_ibfk_1` FOREIGN KEY (`cod_a`) REFERENCES `abilitate` (`cod_abilitate`),
  ADD CONSTRAINT `abilitate_personaj_ibfk_2` FOREIGN KEY (`cod_p`) REFERENCES `personaj` (`cod_pers`);

--
-- Constraints for table `efect`
--
ALTER TABLE `efect`
  ADD CONSTRAINT `efect_ibfk_1` FOREIGN KEY (`cod_af`) REFERENCES `efect_afecteaza` (`cod_afect`);

--
-- Constraints for table `efect_al_abilitatii`
--
ALTER TABLE `efect_al_abilitatii`
  ADD CONSTRAINT `efect_al_abilitatii_ibfk_1` FOREIGN KEY (`cod_a`) REFERENCES `abilitate` (`cod_abilitate`),
  ADD CONSTRAINT `efect_al_abilitatii_ibfk_2` FOREIGN KEY (`cod_e`) REFERENCES `efect` (`cod_efect`);

--
-- Constraints for table `item_inamic`
--
ALTER TABLE `item_inamic`
  ADD CONSTRAINT `item_inamic_ibfk_1` FOREIGN KEY (`cod_itm`) REFERENCES `item` (`cod_item`),
  ADD CONSTRAINT `item_inamic_ibfk_2` FOREIGN KEY (`cod_inam`) REFERENCES `inamic` (`cod_inamic`);

--
-- Constraints for table `item_personaj`
--
ALTER TABLE `item_personaj`
  ADD CONSTRAINT `item_personaj_ibfk_1` FOREIGN KEY (`cod_itm`) REFERENCES `item` (`cod_item`),
  ADD CONSTRAINT `item_personaj_ibfk_2` FOREIGN KEY (`cod_pers`) REFERENCES `personaj` (`cod_pers`);

--
-- Constraints for table `personaj`
--
ALTER TABLE `personaj`
  ADD CONSTRAINT `personaj_ibfk_1` FOREIGN KEY (`cod_port`) REFERENCES `portret` (`cod_portret`),
  ADD CONSTRAINT `personaj_ibfk_2` FOREIGN KEY (`cod_cl`) REFERENCES `clasa` (`cod_clasa`),
  ADD CONSTRAINT `personaj_ibfk_3` FOREIGN KEY (`cod_gr`) REFERENCES `grup` (`cod_grup`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
