using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }
        public Clientes? Clientes { get; set; }
        public string? Observacion { get; set; }
        public decimal Monto { get; set; }
        public ICollection<CotizacionesDetalle> CotizacionesDetalle { get; set; } = new List<CotizacionesDetalle>();
        public Articulos? Articulos { get; set; }
    }
}
