using BusquedaDeParejas.Idiomas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusquedaDeParejas
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.CenterToScreen();
            data1.DataSource = Jugador.lista1;
            data1.Columns[0].Width = 245;
            data1.Columns[1].Width = 244;
            idioma(MenuInicio.lengua);
        }

        private void idioma(int lengua)
        {
            if (lengua == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            else if (lengua == 3)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            Clasificacion.Text = generico.BtnRanking;
            button2.Text = generico.BtnSalir;

        }

    }
}
