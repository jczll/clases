using Chinook.DataAccess;
using Chinook.Etities.Base;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var Repositor = new ArtistRepositor();
            //var artists = Repositor.GetArtists(txtFiltroxNombre.Text);
            //var artists = Repositor.GetArtists($"%{txtFiltroxNombre.Text.Trim()}%");
            var artists = Repositor.GetArtistsWithSp($"%{txtFiltroxNombre.Text.Trim()}%");

            //Asignando el conjunto de Datos al grid.
            dgvListado.DataSource = artists;
            dgvListado.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var repository = new ArtistRepositor();
            var codigoGenerado = repository.InsertArtistTX(
                new Artist()
                {
                    Name = txtNombreArtista.Text.Trim()
                }
                );
            MessageBox.Show($"Los Datos del artistas se han insertado correctamente con el Codigo {codigoGenerado}");
            btnBuscar_Click(null, null);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvListado.SelectedRows.Count>0)
                {
                    DialogResult dRespuesta;
                    int iArtistID = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["ClmCodigo"].Value);
                    dRespuesta = MessageBox.Show($"¿Desea realmente eliminar el Registro {iArtistID.ToString()} ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dRespuesta ==DialogResult.Yes)
                    {
                        var repository = new ArtistRepositor();
                        repository.DeleteArtist(iArtistID);
                        MessageBox.Show("Registro eliminado satisfactoriamente.", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnBuscar_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Se ha cancelado la eliminacion del Registro", "Informacicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No se ha seleccionado ningun Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
