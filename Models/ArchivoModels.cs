using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astrofilm.Models
{
    public class ArchivoModels
    {
        //PELICULAS
        public int IDPelicula { get; set; }
        public int Titulo { get; set; }
        //TRABAJADORES
        public int IDTrabajador { get; set; } 
        public int Tipo { get; set; }
        //GENEROS
        public int IDGenero{ get; set; } 
        public int Nombre { get; set; }
        //LISTAS
        public int IDLista { get; set; } 
        public int Titutlo { get; set; }
    }
}