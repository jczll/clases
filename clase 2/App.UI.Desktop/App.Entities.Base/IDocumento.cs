using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public interface IDocumento
    {
        string NroSerie { get; set; }
        string NroDocumento { get; set; }
        DateTime FechGeneracion { get; set; }
        Double MontoTotal { get; set; }
        string EnviarDocumento();
    }
}
