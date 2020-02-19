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

    public partial class RESERVA
    {
        [Display(Name = "ID")]
        public int IDReserva { get; set; }
        [Display(Name = "Fecha de Reserva")]
        public System.DateTime FecReserva { get; set; }
        [Display(Name = "Butaca")]
        public int NumButaca { get; set; }
        [Display(Name = "ID Usuario")]
        public int IDUserFK { get; set; }
        [Display(Name = "ID Función")]
        public int IDFuncionFK { get; set; }
        [Display(Name = "Precio")]
        public decimal PrecioNeto { get; set; }
    
        public virtual FUNCIONES FUNCIONES { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}
