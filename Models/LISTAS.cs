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
    using System.ComponentModel.DataAnnotations;

    public partial class LISTAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LISTAS()
        {
            this.PELICULAS = new HashSet<PELICULAS>();
        }
        public int TotPelis()
        {
            int total = 0;
            foreach (var peli in PELICULAS)
            {
                if (peli.IDPelicula == IDLista)
                {
                    total++;
                }
            }
            return total;
        }
    
        [Display(Name = "ID")]
        public int IDLista { get; set; }
        public string Titulo { get; set; }
        public bool Publica { get; set; }
        [Display(Name = "Nº Elementos")]
        public Nullable<int> NElementos { get; set; }
        [Display(Name = "ID Propietario")]
        public int PropietarioFK { get; set; }
    
        public virtual COLABORADORES_LISTAS COLABORADORES_LISTAS { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PELICULAS> PELICULAS { get; set; }

    }
}
