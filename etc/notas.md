## TODO
* Cambiar nombres/ocultar titulos y contenido tablas 
* Ajusta css layout y archivos acabado PRO. 
~~~~~~* Hacer usuarios ADmin reales, enviar a bd ROles
* Trabajadores 0 = Director
* Create y display criticas Usuario solo ve las suyas
* Mismo para listas
	* (Usuario) Add peli a lista
	* N elementos dinamico
* Edit Create Criticas para Usuarios limitar
--------------

A la tabla FUNCIONES añadirle el campo agregado plazas disponibles. (calc de tabla reserva y salas)
Tabla USUARIOS-AMIGOS en capa de negocio bloquear que mismo user sea amigo de si mismo.
En lugar de tipo de dato DATA => DATATIME

## Usuarios

- Index
- Reservas 
- About
- Listas
- Amigos
- Carrito
   
## Administrador

- TODO

## Cualquiera

- Index
- About

------------------------

## CONSULTA PARA SACAR PELIS DE 1 GENERO
select *
from
	PELICULAS as P
	INNER JOIN
		PELI_GENERO as PG
	ON
		PG.IDPeliFK = P.IDPelicula
where
	PG.IDGeneroFK = 2;

-----------------------

## MODIFICACIONES EN BD
)


## CREDENCIALES:
admin@empresa.com admin123
pepe@gmail.com pepe123

//Usuario: ana@ana.com ana123
