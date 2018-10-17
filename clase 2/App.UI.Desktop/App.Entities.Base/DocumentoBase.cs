using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public class DocumentoBase
    {
        protected string TipoDocumento = "";
        public string NroSerie { get; set; }
        public String NroDocumento { get; set; }
        public DateTime FechGeneracion { get; set; }
        public Double MontoTotal { get; set; }
        public DateTime? FechaPAgo { get; set; }

        public virtual string EnviarDocumento()
        {
            // Aplicando string Interpolation
            //Sintaxis : $ y {} 
            return $"Se ha enviado la {TipoDocumento} con Nro { NroSerie }-{NroDocumento}";
        }
    }
}
