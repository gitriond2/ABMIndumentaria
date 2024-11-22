using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndumentariaIntimaWPF.Models
{
    [Table("VentasItems")] // Nombre de la tabla en la base de datos
    public class VentasItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDVenta { get; set; } // Clave foránea

        public int IDProducto { get; set; } // Clave foránea

        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }

        // Propiedades de navegación
        [ForeignKey("IDVenta")]
        public virtual Venta Venta { get; set; }

        [ForeignKey("IDProducto")]
        public virtual Producto Producto { get; set; }
    }
}



