//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Astrofilm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PELICULAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PELICULAS()
        {
            this.LISTAS = new HashSet<LISTAS>();
            this.GENEROS = new HashSet<GENEROS>();
            this.TRABAJADORES = new HashSet<TRABAJADORES>();
        }
    
        public int IDPelicula { get; set; }
        public string Titulo { get; set; }
        public System.DateTime Año { get; set; }
        public decimal PuntMedia { get; set; }
        public string Email { get; set; }
        public bool Premium { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTAS> LISTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GENEROS> GENEROS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRABAJADORES> TRABAJADORES { get; set; }
    }
}
