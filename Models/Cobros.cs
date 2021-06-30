using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Observaciones { get; set; } 
        public decimal Monto { get; private set; }

        [ForeignKey("CobroId")]
        public virtual List<CobrosDetalle> Detalles { get; set; }

        private void CalcularMonto()
        {
            Monto = 0;
            foreach (var cobroDetalle in Detalles)
            {
                Monto += cobroDetalle.Monto;
            }
        }

        public decimal ObtenerMonto()
        {
            CalcularMonto();
            return Monto;
        }

    }
}
