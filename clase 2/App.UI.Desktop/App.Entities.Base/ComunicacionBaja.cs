using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public class ComunicacionBaja : DocumentoBase, IDocumento
    {
        public override string EnviarDocumento()
        {
            return "Se ha realizado la comunicacion de Baja";
        }
    }
}
