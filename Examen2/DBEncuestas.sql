
-- Crear la base de datos
CREATE DATABASE EncuestasDB;
GO

USE EncuestasDB;
GO

-- Crear la tabla de Encuestas
CREATE TABLE Encuestas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    correo VARCHAR(100) NOT NULL,
    carro_propio VARCHAR(3) NOT NULL CHECK (carro_propio IN ('Si', 'No')),
    fecha_creacion DATETIME DEFAULT GETDATE()
);
GO

select * from Encuestas

SELECT 
    COUNT(*) AS Total_de_encuestas,
    SUM(CASE WHEN carro_propio = 'Si' THEN 1 ELSE 0 END) AS Personas_con_carro_propio,
    SUM(CASE WHEN carro_propio = 'No' THEN 1 ELSE 0 END) AS Personas_sin_carro_propio
FROM 
    Encuestas;
