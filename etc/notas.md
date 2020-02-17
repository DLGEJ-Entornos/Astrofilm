## TODO
* Crear Front mínimo Archivo.
* Crear funcionalidad (filtrado, busqueda,etc) Para Archivo.
* Cambiar nombres/ocultar titulos y contenido tablas 
* Ajusta css boots layout y archivos. 



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
##
