using EF.CodeFirstData.DataAcces;
using EF.CodeFirstData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF.CodeFirstData.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            var artistDA = new ArtistDA();
            var data = artistDA.GetArtists(txtBuscarxNombre.Text.Trim());
            //Enlazando los datos del Grid
            dgvListado.DataSource = data;
            dgvListado.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }
        private void Agregar()
        {
            var artistDA = new ArtistDA();
            var artist = new Artist();
            artist.Name = txtNombreArtista.Text;
            var CodigoGenerado = artistDA.InsertArtist(artist);

            MessageBox.Show($"Los datos del artista se han guardado correctamente con código {CodigoGenerado}");
            Buscar(); 
        }
    }
}
