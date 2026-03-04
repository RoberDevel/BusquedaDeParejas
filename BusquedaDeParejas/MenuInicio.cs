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
    public partial class MenuInicio : Form
    {


        public static int dificultad;
        public static int Tiempo;
        public static int lengua = 1;

      



        public MenuInicio()
        {
            InitializeComponent();

            //Al iniciar el programa, la dificultad estará seleccionada en 0, que seria facil
            CBDificultad.SelectedIndex = 0;
        }

        private void MenuInicio_Load(object sender, EventArgs e)
        {

            //Cargamos como va a ser el boton Iniciar, Dificultad, Idioma, Ranking Y Salir, tambien se puede hacer desde Diseño, en propiedades del boton

            BtnIniciar.BackColor = Color.Transparent;
            BtnIniciar.ForeColor = Color.Black;
            BtnIniciar.FlatStyle = FlatStyle.Popup;

            BtnDificultad.BackColor = Color.Transparent;
            BtnDificultad.ForeColor = Color.Black;
            BtnDificultad.FlatStyle = FlatStyle.Popup;

            BtnIdioma.BackColor = Color.Transparent;
            BtnIdioma.ForeColor = Color.Black;
            BtnIdioma.FlatStyle = FlatStyle.Popup;

            BtnRanking.BackColor = Color.Transparent;
            BtnRanking.ForeColor = Color.Black;
            BtnRanking.FlatStyle = FlatStyle.Popup;

            BtnSalir.BackColor = Color.Transparent;
            BtnSalir.ForeColor = Color.Black;
            BtnSalir.FlatStyle = FlatStyle.Popup;

            //El formulario se pondrá en el centro de la pantalla
            this.CenterToScreen();

            //Cargamos dos jugadores 
            Jugador.lista1.Add(new Jugador
            {
                Nick = "Rober",
                Tiempo = 15
            });
            Jugador.lista1.Add(new Jugador
            {
                Nick = "Ruben",
                Tiempo = 17
            });




        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {

            //Al darle al boton Iniciar, si el combobox de dificultad está visible, lo pondremos en false para que cuando volvamos, no aparezca visible
            CBDificultad.Visible = false;
            
            //Iniciaremos el formulario de formJuego
            FormJuego formulario1 = new FormJuego();
            formulario1.Show();
            


        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //Se cerrará este formulario y el programa
            this.Close();
        }

     

        private void BtnDificultad_Click(object sender, EventArgs e)
        {
            //Al darle al boton de dificultad, se mostrará el combobox de dificultad
            CBDificultad.Visible = true;

        }

        //Idiomas: Para crear idiomas primero creamos una carpeta llamada idiomas y dentro de ella le damos a agregar - nuevo elemento - recursos, y lo llamamos generico

        private void CBIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //
            if (CBIdioma.SelectedIndex == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                lengua = 2;
            }
            else if (CBIdioma.SelectedIndex == 2)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                lengua = 3;
                
            }
            
            else { 
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                lengua = 1;
            }

             label1.Text = generico.label1;
            BtnDificultad.Text = generico.BtnDificultad;
            BtnIdioma.Text = generico.BtnIdioma;
            BtnIniciar.Text = generico.BtnIniciar;
            BtnSalir.Text = generico.BtnSalir;




        }



        private void BtnIdioma_Click(object sender, EventArgs e)
        {
            //Al darle al boton de idioma, se mostrará el combobox de idioma
            CBIdioma.Visible = true;
            
        }





        public void CBDificultad_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Aqui se elegirá el nivel de dificultad (tiempo) dependiendo que index es.
            if (CBDificultad.SelectedIndex == 0)
            {
                Tiempo = 120;
                dificultad = 1;

            }
            else if (CBDificultad.SelectedIndex == 1)
            {
                Tiempo = 60;
                dificultad = 2;
            }
            else if (CBDificultad.SelectedIndex == 2)
            {
                Tiempo = 30;
                dificultad = 3;
            }
            else if (CBDificultad.SelectedIndex == 3)
            {
                Tiempo = 15;
                dificultad = 4;
            }






        }

        private void BtnRanking_Click(object sender, EventArgs e)
        {
            //Al darle al boton Ranking, se abrirá el formulario de Ranking
            Ranking formulario2 = new Ranking();
            formulario2.Show();
        }
    }




}
