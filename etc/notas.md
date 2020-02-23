## CREDENCIALES: ##

### ADMINISTRADORES

admin@empresa.com
admin123

pepe@gmail.com
pepe123

### USUARIO

ana@ana.com
ana123

----------------------------------------

## TODO
* Ajusta css layout y archivos acabado PRO. 
* Solucion para sinopsis
* Añadir peliculas a listas propias y Full Control desde admin

###BUGS CRASHES:
TIPO FALLOS:
	a:UNIQUE - Ya hay un Propietario del elemento.
	b:FK.

                  C: Create E: Edit
Según ROLES:
ADMIN | USUARIO |
=================
      |         | C  RESERVAS
      |         | E

  Xa  |   Xa    | C  LISTAS
  Xa  |   Xb    | E

      |         | C  CRITICAS
      |   Xb    | E


###Postergado:
* Hacer usuarios ADmin reales, enviar a bd ROles
* Crear critica desde details pelicula


