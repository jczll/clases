using Formas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormas
{
    public partial class Formas : Form
    {
        public Formas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangulo Area = new Triangulo();
            Area.nbase = Convert.ToInt32(txtBase.Text);
            Area.altura =Convert.ToInt32(txtAltura.Text);
            MessageBox.Show("El Area del Triangulo es " + Area.CalculaArea().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cuadrado Area = new Cuadrado();
            Area.nbase = Convert.ToInt32(txtBase.Text);
            MessageBox.Show("El Area del Cuadrado es " + Area.CalculaArea().ToString());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Circulo Area = new Circulo();
            Area.nbase = Convert.ToInt32(txtBase.Text);
            MessageBox.Show("El Area del Cuadrado es " + Area.CalculaArea().ToString());
        }
    }
}
