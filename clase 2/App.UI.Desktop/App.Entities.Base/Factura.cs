using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public class Factura : DocumentoBase, IDocumento
    {
        public Factura()
        {
            this.TipoDocumento = "Factura";
        }
        public Double IGV { get; set; }
        public Double Subtotal { get; set; }
    }
}
