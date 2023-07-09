-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 10 Cze 2023, 14:19
-- Wersja serwera: 10.4.24-MariaDB
-- Wersja PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `users`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `id` bigint(20) NOT NULL,
  `password` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `voivodeships_id` bigint(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`id`, `password`, `username`, `voivodeships_id`) VALUES
(1, '$argon2i$v=19$m=65536,t=40,p=4$EYvHVJOA4WP2j1ixNa95TSaljkRcUPj85+EMdfCBDC5UMEsN+/yBg+SmEAtI9e+fUAg2Qx3ta5dKIqV0q45kMQ$MQsSn3tGu9sWuaMlBKq40XS1WtXF0tOwis66E68LxcjFbAhudfu5rjp0Myl6hvBVImVCnExDwraEieRMEWbE+Q', 'dolnośląskie', 1),
(2, '$argon2i$v=19$m=65536,t=40,p=4$axWmwTbYjGUCF/W1mX8pba/HmsP34pKV1X1G40ZulneSdVsZLFiu0nVLCjrmKZA2YQUGoFjuhXtHH9xxhmVn4g$ZLNnXt4bxyZNw5K0hUDYV/+4kEjLtDMOuSyZSIN/O502rDoTT8FrO4OiBw2K/rwIMdpQDljhB2OMRVq21ObGxw', 'kujawsko-pomorskie', 2),
(3, '$argon2i$v=19$m=65536,t=40,p=4$r0xSPpfgUrxddCRwqqJbX62/64b+uhV5FvuPUDfbTtu/E5yPhhHahwAQkGfUaNj6FHU06uguqIUz/lppw7/xpA$bMBV10Xs2WJa2BHXWKx+ai5gYIuCPOADXt/VB8Fwx92O4PlA5AaCk/+GG990ogrgmu30WbwL9IDoAkB6Lz4y3g', 'lubelskie', 3),
(4, '$argon2i$v=19$m=65536,t=40,p=4$21Oa6X/t3K7RaKN9DG6Zu2NLxww+U+f4dJBNgPSnUYXNJzoRriaAimsubs2YOKr497p5CGXG2BILBIwx5u5oAQ$UY6sdzE7xKjX8duRhLcoBBI5iEmhQC5a/50o5yq1p+Hys1Ql783Ia7k+vPyxXHb1JMGDAs9idWe1mFprNLIBxQ', 'lubuskie', 4),
(5, '$argon2i$v=19$m=65536,t=40,p=4$sYkH8ioT8BWCm5fvF2r7RTI+oxnPD9GmtrvpaQCQpKNT4q4fNIf5WWUvYE+4NudBkBVnuXIY13O5YmsNk2/Sbw$/qwC+C4RcUNj4Q9W4agAhE1La1RWT+GCjjj6w9OzTknre49p6k4yJiaL/zmm+UOrm8ivi0Ni18/KY0oFDM8RZQ', 'łódzkie', 5),
(6, '$argon2i$v=19$m=65536,t=40,p=4$xp54WR32kDE7gzR7kAbNJwwBKYLByM/ILTTNQ3GTOqtiuv5qoWQ7lgonCSg9y45WKSTYfJDG9Wxr/liLaGosww$mgCpZ59hgl7ai7ilgE7T5u5dw4d5MSSudPl+l+X+ajaVDo0tC6/ub+YjO6vkmIGwHo5tbWUj4B7bnuuc/ftwIA', 'małopolskie', 6),
(7, '$argon2i$v=19$m=65536,t=40,p=4$WC8EfDKTRCmFIgnHqmGCSQSm0eoRY/1LW7o+RhrQk1rWZJZW73pgqYUsdMyCiWQvLi2HRdsEGvrKaGQz/9iBoQ$AQWt5H1hj0GzZgL2J7h7kmiTWjStLosYmuTb2FRB8Y9DV2j5EQ5B5ltJPjL/7YRrQ9OqStz2w5gbYD4jGlgZPQ', 'mazowieckie', 7),
(8, '$argon2i$v=19$m=65536,t=40,p=4$58haRligxxxDVWO7lYcXWK4VvbrNX2oHJQ8IeAZi/4vIIOHAe9in0b2p5w2NIK40nO+1J8uaMlpRCiyPLdiX+w$t05FP4zaAr9CqYq+nkqfOPJS0kdO97u6WddM6PMo5D+y5l6ecvH+YLFsohtmk0MqmUN29PTt3suihB2T2PQJFA', 'opolskie', 8),
(9, '$argon2i$v=19$m=65536,t=40,p=4$Xe7lAJ8QX2NMT1vO98DZDz6ZQjT/4jlaKxvmtj/6r92aj+MR/QYyMM+PkrqK3i/l82YGsD6d1eJsbFda5aqLMg$apS1CowSn9bKpMrO28DYJXTriBuSJH2pik8QH6/EuenAgKONgYdxoUgo80BYhobEUjT3Ky1pLYbdR/pqbHFgzA', 'podkarpackie', 9),
(10, '$argon2i$v=19$m=65536,t=40,p=4$3yolNN8JW+/HOjTiBoOjHURve1WP2Rk43SIQTPdEhIyTTFxwupn84GXjrnfUxrUJhl504M7fWghtEHn/efdJjQ$M70Q7pG1lMfDyFCWFXgc5RlP6XF0rQciUsV4yGxLUqoeD3zSuGbk5PuIwxf+fWBWsd8EXWAscrSp4k2GgP+OWg', 'podlaskie', 10),
(11, '$argon2i$v=19$m=65536,t=40,p=4$G9c5z6yZsuJxHw30mJwybI4VQCpnOryelcMh880tT8m6fjg21bN9H9wd6CKpCLcBmsvSUCHK10zXQ+WELgTcCw$+K0pEwNc9OdtonUGh7IICabsWULcdYdQpTjO7p/x6oP1e6ETpbMsNZuOczJlgAqsBuPtDni+qqv+d0shwCnbOQ', 'pomorskie', 11),
(12, '$argon2i$v=19$m=65536,t=40,p=4$nBrysdNZ7Yv4bx8zxmJ9uDds1dU0WnKj0M7hkgXrzk2Hvjv68LXEaGRXWjZZ6bZItSK5LUQhHf9Bo3VbcLyG2Q$B1uqCuObF5VmIrN2GiDSXNapj5yaNLxvQfEXWsvcEbzqbmfqwiflKap5sFk0UW0DpjC+eFa1/ezIBYhgsQhUmg', 'śląskie', 12),
(13, '$argon2i$v=19$m=65536,t=40,p=4$tp+edE/8dEJSbGTL+KSO7gL0AgJC86DCA9HGE6+A6FgDp2JckTPGBp5IBRBLhwahdrvp2MWRVbXT7klzWDX0+w$t1JAm4pw+juSfpP2XnFWH3CnNiFfmhFSFXTI5XiGzZum8Nb7Xv/O1mN5yJAdAjkzdBLbVUv2T4vnh5paMS4aOA', 'świętokrzyskie', 13),
(14, '$argon2i$v=19$m=65536,t=40,p=4$ON1VmSgyBX9/d+lIZVXDWw5qeBL4W7On3XCXhIGW3M1q9SnsyWo9I/T05cX/RexvuhKt6qmQZSJJde4LSV8oUg$uLJb22NLmuG7RbGREG9cDD0D/xcL5ch1xQ9Y3V1Or9tWEu4UgtRKbWLkIDZ/tksZEuYGEYds67/jGugnm/1FHg', 'warmińsko-mazurskie', 14),
(15, '$argon2i$v=19$m=65536,t=40,p=4$xIV4RCwn+qMRIn8pUXL3O1jvETKUOiX6cLXKV5VfwfR4Zjkaw72wsZDFRq8wIW08Fikts+wa5f7MIbsouwwRwA$yHAaiXDuTg15svVniSKd+2T3zB8swqCO42Wir2jpDNB8r/8DhBnEsnjrlk9xN2U4fmPPC/sAbizthLnYqHdgvQ', 'wielkopolskie', 15),
(16, '$argon2i$v=19$m=65536,t=40,p=4$bQMtKVmfwHv5VF+W3ECRiMprYPX9if6LA7gJ5XmiXRV45YItZkUWIYaGMHcXnAry6PQ0ejzR8iTueIsk/dQ3gw$Lq8IrgjLfJ2B0qKsKZ2IFESc/b3VhZ82+v2+lWFfvBOcoEdC5ybyFKXs9zW1krQPKxO+F+Mgsg0fq+RXW31Qeg', 'zachodniopomorskie', 16);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `voivodeships`
--

CREATE TABLE `voivodeships` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `voivodeships`
--

INSERT INTO `voivodeships` (`id`, `name`) VALUES
(1, 'dolnośląskie'),
(2, 'kujawsko-pomorskie'),
(3, 'lubelskie'),
(4, 'lubuskie'),
(5, 'łódzkie'),
(6, 'małopolskie'),
(7, 'mazowieckie'),
(8, 'opolskie'),
(9, 'podkarpackie'),
(10, 'podlaskie'),
(11, 'pomorskie'),
(12, 'śląskie'),
(13, 'świętokrzyskie'),
(14, 'warmińsko-mazurskie'),
(15, 'wielkopolskie'),
(16, 'zachodniopomorskie');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UK_r43af9ap4edm43mmtq01oddj6` (`username`) USING HASH,
  ADD KEY `IDXr43af9ap4edm43mmtq01oddj6` (`username`(250)),
  ADD KEY `FKdavwyfjcg8r3s6m3n02mkpjer` (`voivodeships_id`);

--
-- Indeksy dla tabeli `voivodeships`
--
ALTER TABLE `voivodeships`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UK_6edxpb9vslvkn2u855cotajrw` (`name`) USING HASH;

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT dla tabeli `voivodeships`
--
ALTER TABLE `voivodeships`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
