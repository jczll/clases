using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    public class FormaBase
    {
        protected string TipoForma = "";
        public int nbase { get; set; }
        public int altura { get; set; }

        public virtual double CalculaArea()
        {
            return 0;
        }
    }
}
