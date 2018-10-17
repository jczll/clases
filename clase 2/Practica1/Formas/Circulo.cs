using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    public class Circulo : FormaBase
    {
        public Circulo()
        {
            this.TipoForma = "CIRCULO";
        }
        public override double CalculaArea()
        {
            double iArea = (Math.PI * (this.nbase * this.nbase));
            return iArea;
        }
    }
}
