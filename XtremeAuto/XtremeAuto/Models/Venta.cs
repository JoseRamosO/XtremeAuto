//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XtremeAuto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.Transaccion = new HashSet<Transaccion>();
        }
    
        public int IDVenta { get; set; }
        public bool Financiamiento { get; set; }
        public decimal Intereses { get; set; }
        public decimal Total { get; set; }
        public int Meses { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Aprobacion { get; set; }
        public string IDCliente { get; set; }
        public int IDCarro { get; set; }
        public string IDEmpleado { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual Carro Carro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
