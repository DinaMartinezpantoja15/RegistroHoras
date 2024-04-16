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