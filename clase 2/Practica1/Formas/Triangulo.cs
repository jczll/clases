using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    public class Triangulo : FormaBase
    {
        /*Constructor */
        public Triangulo()
        {
            this.TipoForma = "TRIANGULO";
        }

        public override double CalculaArea()
        {
            int iArea = (this.nbase * this.altura) / 2;
            return iArea;
        }
    }
}
