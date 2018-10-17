using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinook.UI.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            var client = new MantenimientoServices.MantenimientosServicesClient();
            var data = client.GetArtistByName(txtFiltro.Text.Trim());
            dgvDatos.DataSource = data;
            dgvDatos.Refresh();
        }
    }
}
