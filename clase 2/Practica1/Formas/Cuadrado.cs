using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    public class Cuadrado : FormaBase
    {
        public Cuadrado()
        {
            this.TipoForma = "CUADRADO";
        }
        public override double CalculaArea()
        {
            int iArea = (this.nbase * this.nbase);
            return iArea;
        }
    }
}
