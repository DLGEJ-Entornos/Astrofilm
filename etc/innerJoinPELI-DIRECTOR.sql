use [E:\SERVIDOR\SUPUESTOPRACTICOINTEGRADOR\ASTROFILM\APP_DATA\ASTROFILM.MDF]

select 
	P.Titulo, T.Nombre+' '+T.Apellido
from
	PELICULAS as P
	inner join
	PELI_TRABAJADOR as PT
	on P.IDPelicula = PT.IDPeliFK
	inner join
	TRABAJADORES as T
	on T.IDTrabajador = PT.IDTrabajadorFK
