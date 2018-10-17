using DataAccess;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
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
            Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void Buscar()
        {
            var repository = new ArtistRepository();
            var artists = repository.GetArtistsWithSP($"%{txtFiltroPorNombre.Text.Trim()}%");

            //asignando el conjunto de datos al grid
            dgvListado.DataSource = artists;
            dgvListado.Refresh();
        }
        private void Eliminar()
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el Registro?", "Pregunta", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question, defaultButton: MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dgvListado.SelectedRows != null)
                {
                    var artist = (Artist)dgvListado.SelectedRows[0].DataBoundItem;
                    var repository = new ArtistRepository();
                    var result = repository.DeleteArtist(artist.ArtistId);
                    if (result)
                    {
                        MessageBox.Show("Registro Eliminado Satisfactoriamente");
                        Buscar();
                    }
                }
            }
        }
    }
}
