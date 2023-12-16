CREATE DATABASE encuesta
GO
USE encuesta
GO
CREATE TABLE llenarencuesta
(
	numeroencuesta INT IDENTITY (1,1),
	nombre VARCHAR (50) NOT NULL,
	edad INT NOT NULL,
	correo VARCHAR (50) NOT NULL,
	partidopolitico VARCHAR(5)
	CONSTRAINT pk_numeroencuesta PRIMARY KEY(numeroencuesta),
)

CREATE PROCEDURE agregarparticipante
@nombre VARCHAR(50),
@edad INT,
@correo VARCHAR(50),
@partidopolitico VARCHAR(5)
AS
	BEGIN
	INSERT INTO llenarencuesta (nombre,edad,correo,partidopolitico) VALUES(@nombre,@edad,@correo,@partidopolitico)
	END

EXECUTE agregarparticipante 'Ana','40','ana@hotmail.com','PAC'

CREATE PROCEDURE consultaencuesta
@numeroencuesta INT
AS
	BEGIN
	SELECT * FROM llenarencuesta WHERE numeroencuesta=@numeroencuesta
	END

EXECUTE consultaencuesta 2


SELECT * FROM llenarencuesta