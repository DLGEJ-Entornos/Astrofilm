## TODO
* Cambiar nombres/ocultar titulos y contenido tablas 
* Ajusta css layout y archivos acabado PRO. 
* Corrige users duplicados en Index Usuarios al añadir amigos
* Hacer nºelementos en lista
* Index LISTAS cambiar Apellidos por Propietario
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
