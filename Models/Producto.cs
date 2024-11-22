using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndumentariaIntimaWPF.Models
{
    [Table("Productos")] // Nombre de la tabla en la base de datos
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRODUCTO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string MARCA { get; set; }
        public decimal IMPORTE { get; set; }
        public string Descripcion { get; set; }

    }
}

