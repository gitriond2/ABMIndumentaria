using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace IndumentariaIntimaWPF.Models
{
    [Table("Ventas")] // Nombre de la tabla en la base de datos
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_VENTA { get; set; }

        public DateTime FECHA { get; set; }
        public int CLIENTE { get; set; }
        public decimal IMPORTE { get; set; }
        public string TIPODEPAGO { get; set; }

        // Propiedades de navegación
        [ForeignKey("CLIENTE")]
        public virtual Cliente ClienteEntidad { get; set; }

        public virtual ICollection<VentasItem> VentasItems { get; set; } // Relación uno a muchos con VentasItems
    }
}






