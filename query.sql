
CREATE TABLE Empleado(
    Id int  NOT NULL  PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(255),
    Apellido VARCHAR(255),
    Tipo_documento VARCHAR(255),
    Numero_documento VARCHAR(255),
    Area VARCHAR (255),
    Cargo VARCHAR (255),
    Contraseña VARCHAR (255),
    Registro_id int 
)

CREATE TABLE Registro(
    Id int  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Hora_Salida TIME,
    Fecha_Salida DATE,
    Hora_entrada TIME,
    Fecha_entrada DATE
)





DROP TABLE `Empleado`;


DROP FOREIGN KEY Empleados_ibfk_9;

ALTER TABLE `Empleado` ADD FOREIGN KEY (Registro_id) REFERENCES Registro(Id)

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