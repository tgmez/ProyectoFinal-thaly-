
/* LISTO */
CREATE TABLE CaracteristicaVariable(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(40)
);

/* LISTO */
CREATE TABLE HabilidadEspecial(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(40),
	Descripcion VARCHAR(40)
);

/* LISTO */
CREATE TABLE Clase(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(40),
	Descripcion VARCHAR(40)
);

/* LISTO */
CREATE TABLE Raza(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(40),
	Descripcion VARCHAR(40),
	Bonus INT,
	CaracteristicaVariableId INT FOREIGN KEY REFERENCES CaracteristicaVariable(Id)
);

/* LISTO */
CREATE TABLE Personaje(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(40) ,
	Nivel INT ,
	Fuerza INT ,
	Destreza INT ,
	Constitucion INT ,
	Inteligencia INT ,
	Sabiduria INT,
	Carisma INT,
	RazaId INT FOREIGN KEY REFERENCES Raza(Id),
	ClaseId INT FOREIGN KEY REFERENCES Clase(Id)
);

/*MAPEO DE HABILIDAD ESPECIAL Y PERSONAJE (RELACION N A N)*/
CREATE TABLE HabilidadEspecialPersonaje(
	Id INT PRIMARY KEY NOT NULL,
	PersonajeId INT FOREIGN KEY REFERENCES Personaje(Id),
	HabilidadEspecialId INT FOREIGN KEY REFERENCES HabilidadEspecial(Id)
);
/*MAPEO DE HABILIDAD ESPECIAL Y CLASE (RELACION N A N)*/
CREATE TABLE HabilidadEspecialClase(
	Id INT PRIMARY KEY NOT NULL,
	ClaseId INT FOREIGN KEY REFERENCES Clase(Id),
	HabilidadEspecialId INT FOREIGN KEY REFERENCES HabilidadEspecial(Id)
);

/* LISTO */
CREATE TABLE PersonajeCaracteristica(
	Id INT PRIMARY KEY NOT NULL,
	Valor INT,
	PersonajeId INT FOREIGN KEY REFERENCES Personaje(Id),
	CaracteristicaVariableId INT FOREIGN KEY REFERENCES CaracteristicaVariable(Id)
);

