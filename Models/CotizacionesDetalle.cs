using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class CotizacionesDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CotizacionId { get; set; }

        [ForeignKey("CotizacionId")]
        public Cotizaciones? Cotizaciones { get; set; }

        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulos? Articulos { get; set; }

        public int Cantidad { get; set; } 

        public decimal Precio { get; set; }
    }
}
