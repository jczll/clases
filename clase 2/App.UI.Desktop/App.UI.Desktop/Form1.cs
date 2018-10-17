using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using App.Entities.Base;

namespace App.UI.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LBLIGV.Text = ConfigurationManager.AppSettings["IGV"]; 
        }

        private void btnEnviarDocumento_Click(object sender, EventArgs e)
        {
            Factura documento = new Factura();
            documento.NroSerie = "F001";
            documento.NroDocumento = "000001";

            Factura Documento = new Factura();
            Documento.NroSerie = "F002";
            Documento.NroDocumento = "000002";
            MessageBox.Show(Documento.EnviarDocumento());

            var Boleta = new Boleta();
            Boleta.NroSerie = "B001";
            Boleta.NroDocumento = "000003";
            MessageBox.Show(Boleta.EnviarDocumento());

            var Baja = new ComunicacionBaja();
            MessageBox.Show(Baja.EnviarDocumento());

            IDocumento documentoGenerico = new Boleta();
            documentoGenerico.NroSerie = "B001";
            documentoGenerico.NroDocumento = "000011";
            MessageBox.Show(documentoGenerico.EnviarDocumento());

            IDocumento documentoBaja = new ComunicacionBaja();
            MessageBox.Show(documentoBaja.EnviarDocumento());

        }

        private void btnElvis_Click(object sender, EventArgs e)
        {
            Factura documento=null;
            //Validando el Dato en tres lineas de codigo
            if (documento != null && documento.NroDocumento !=null)
            {
                string nroDocumento = documento.NroDocumento;
            }
            //Elvis Operator ? Es la clave 
            string nroDoc2 = documento?.NroDocumento;
        }
    }
}
