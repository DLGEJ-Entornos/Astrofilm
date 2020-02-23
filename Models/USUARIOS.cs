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

    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            this.CRITICAS = new HashSet<CRITICAS>();
            this.LISTAS = new HashSet<LISTAS>();
            this.RESERVA = new HashSet<RESERVA>();
            this.COLABORADORES_LISTAS = new HashSet<COLABORADORES_LISTAS>();
            this.USUARIOS_AMIGOS1 = new HashSet<USUARIOS_AMIGOS>();
        }
    
        public string FullName
        {
            get
            {
                return this.Nombre + " " + this.Apellidos;
            }
        }
        [Display(Name = "ID")]
        public int IDUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public System.DateTime FecNac { get; set; }
        [Display(Name = "Administrador")]
        public bool TipoUser { get; set; }
        public string Email { get; set; }
        public bool Premium { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRITICAS> CRITICAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTAS> LISTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVA> RESERVA { get; set; }
        public virtual USUARIOS_AMIGOS USUARIOS_AMIGOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLABORADORES_LISTAS> COLABORADORES_LISTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIOS_AMIGOS> USUARIOS_AMIGOS1 { get; set; }
    }
}
