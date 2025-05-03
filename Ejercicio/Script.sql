CREATE DATABASE Ejercicio
GO

USE Ejercicio
GO

CREATE TABLE cursos
(
	id int identity(1,1) NOT NULL,
	nombre varchar(20) NOT NULL

	CONSTRAINT pk_curso_id PRIMARY KEY (id)
)
GO
CREATE TABLE estudiantes
(
	id int identity(1,1) NOT NULL,
	nombre varchar(100) NOT NULL,
	apellido varchar(100) NOT NULL,
	genero varchar(20) NOT NULL,
	edad int NOT NULL,
	domicilio varchar(100) NOT NULL,
	correo varchar(100) NOT NULL

	CONSTRAINT pk_estudiante_id PRIMARY KEY (id)
)
GO
CREATE TABLE matriculas
(
	id int identity(1,1) NOT NULL,
	cursos_id int NOT NULL,
	estudiantes_id int NOT NULL,
	fecha datetime NOT NULL,
	estado varchar(20) NOT NULL

	CONSTRAINT pk_matricula_id PRIMARY KEY (id)

	CONSTRAINT fk_matriculas_cursos_id FOREIGN KEY (cursos_id)
	REFERENCES cursos(id),

	CONSTRAINT fk_matriculas_estudiantes_id FOREIGN KEY (estudiantes_id)
	REFERENCES estudiantes(id),

	CONSTRAINT chk_matricula_estado CHECK (estado IN ('ACTIVA', 'CANCELADA', 'FINALIZADA'))
)
GO

-- Datos para la tabla cursos
INSERT INTO cursos (nombre) VALUES 
('Matemáticas'),
('Historia'),
('Biología'),
('Inglés'),
('Física'),
('Química'),
('Programación'),
('Arte'),
('Geografía'),
('Filosofía');

-- Datos para la tabla estudiantes
INSERT INTO estudiantes (nombre, apellido, genero, edad, domicilio, correo) VALUES 
('Carlos', 'Ramírez', 'Masculino', 20, 'Calle 123, Ciudad A', 'carlos.ramirez@email.com'),
('Ana', 'López', 'Femenino', 22, 'Av. Siempre Viva 456', 'ana.lopez@email.com'),
('María', 'Gómez', 'Femenino', 19, 'Calle 789, Ciudad B', 'maria.gomez@email.com'),
('Juan', 'Pérez', 'Masculino', 21, 'Carrera 10, Ciudad C', 'juan.perez@email.com'),
('Luis', 'Martínez', 'Masculino', 23, 'Av. Central 345', 'luis.martinez@email.com'),
('Elena', 'Torres', 'Femenino', 20, 'Calle Luna 987', 'elena.torres@email.com'),
('Pedro', 'Sánchez', 'Masculino', 24, 'Av. del Sol 654', 'pedro.sanchez@email.com'),
('Laura', 'Mendoza', 'Femenino', 22, 'Calle Estrella 321', 'laura.mendoza@email.com'),
('Jorge', 'Castro', 'Masculino', 25, 'Pasaje Norte 111', 'jorge.castro@email.com'),
('Sofía', 'Herrera', 'Femenino', 20, 'Boulevard Sur 222', 'sofia.herrera@email.com');