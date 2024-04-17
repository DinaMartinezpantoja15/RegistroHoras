CREATE TABLE Ingreso(
    Id int  NOT NULL  PRIMARY KEY AUTO_INCREMENT,
    Hora_Ingreso TIME NOT NULL,
    Fecha_Ingreso DATE NOT NULL
)

CREATE TABLE Salida(
    Id int  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Hora_Salida TIME NOT NULL,
    Fecha_Salida DATE NOT NULL
)

DROP TABLE Registro;

DROP FOREIGN KEY Empleados_ibfk_9;

ALTER TABLE `Empleados` ADD FOREIGN KEY (Ingreso) REFERENCES Ingreso(Id)

ALTER TABLE `Empleados` ADD FOREIGN KEY (`Salida`) REFERENCES `Salida`(Id)


INSERT INTO `Tipo_documento` (`Nombre`) VALUES ("Cedula")

INSERT INTO `Tipo_documento` (`Nombre`) VALUES ("Tarjeta Identidad")

INSERT INTO `Tipo_documento` (`Nombre`) VALUES ("Pasaporte")


INSERT INTO `Salida`(`Hora_Salida`,`Fecha_Salida`) VALUES("08:30:15",'2024-04-09');

INSERT INTO `Area`(`Nombre`) VALUES ("Administrativa")

INSERT INTO `Area`(`Nombre`) VALUES ("Desarrollo")

INSERT INTO `Area`(`Nombre`) VALUES ("Produccion")


INSERT INTO `Cargo`(`Nombre`) VALUES ("Desarrollador")

INSERT INTO `Cargo`(`Nombre`) VALUES ("Administrador")

INSERT INTO `Cargo`(`Nombre`) VALUES ("Tecnico")

INSERT INTO `Ingreso`(`Hora_Ingreso`,`Fecha_Ingreso`) VALUES ("10:00","2020-11-16")


INSERT INTO `Empleados`(`Nombre`,`Apellido`,`Salida`,`Numero_documento`,`Contraseña`) VALUES('Pedro','Perez',1,'1234','123');