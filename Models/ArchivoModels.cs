using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astrofilm.Models
{
    public class ArchivoModels
    {
        //PELICULAS
        public IEnumerable<PELICULAS>Peliculas { get; set; }
        public IEnumerable<TRABAJADORES> Trabajadores { get; set; }
        public IEnumerable<GENEROS> Generos { get; set; }
        public IEnumerable<LISTAS> Listas { get; set; }

        //public static void InnerJoinEx()
        //{
        //    var query = from peli in PELICULAS
        //                join trabajador in Trabajadores on
        //                peli equals trabajador.


        //}
    }
}