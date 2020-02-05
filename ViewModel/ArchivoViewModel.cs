using Astrofilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astrofilm.ViewModel
{
    public class ArchivoViewModel
    {
        public IEnumerable<PELICULAS> PELICULAS{ get; set; }
        public IEnumerable<LISTAS> LISTAS{ get; set; }
        public IEnumerable<GENEROS> GENEROS{ get; set; }
        public IEnumerable<TRABAJADORES> TRABAJADORES{ get; set; }
    }
}