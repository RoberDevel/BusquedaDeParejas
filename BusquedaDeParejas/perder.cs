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
    public partial class perder : Form
    {
        public perder()
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

        private void perder_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.Black;
            button1.FlatStyle = FlatStyle.Popup;
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.Black;
            button2.FlatStyle = FlatStyle.Popup;
            button3.BackColor = Color.Transparent;
            button3.ForeColor = Color.Black;
            button3.FlatStyle = FlatStyle.Popup;

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
            LblPerdiste.Font = new Font(LblPerdiste.Font.Name, 70);
            
            LblPerdiste.Text = generico.LblPerdiste;
            button1.Text = generico.BtnSalirJuego;
            button2.Text = generico.BtnSalir;
            button3.Text = generico.Reintentar;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FormJuego formulario1 = new FormJuego();
            formulario1.Show();
        }
    }
}
