using Chinook.DataAccess;
using Chinook.Entities.Base;
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
            var repository = new ArtistRepository();
            //var artists = repository.GetArtists($"%{txtFiltroPorNombre.Text.Trim()}%");
            var artists = repository.GetArtistsWithSP($"%{txtFiltroPorNombre.Text.Trim()}%");

            //asignando el conjunto de datos al grid
            dgvListado.DataSource = artists;
            dgvListado.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var repository = new ArtistRepository();
            /*Sin manejo de transacciones*/
            /*
            var codigoGenerado = repository.InsertArtist(
            new Artist()
            {
                Name = txtNombreArtista.Text.Trim()
            });
            */

            //Con manejo de transaciones
            var codigoGenerado = repository.InsertArtistTX(
            new Artist()
            {
                Name = txtNombreArtista.Text.Trim()
            });

            MessageBox.Show($"Los datos del artista se han guardado correctamente con código {codigoGenerado}");

            btnBuscar_Click(null,null);


        }
    }
}
