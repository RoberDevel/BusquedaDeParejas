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
    public partial class Ganador : Form
    {
        //Aqui es donde se almacenan los datos que van al datagrid
        BindingList<Jugador> lista = new BindingList<Jugador>();
        //Objeto de la clase Jugador
        Jugador jugador = new Jugador();
        //Variable que toma el valor del nick introducido por el usuario
        string Nick;
       
        

        public Ganador()
        {
            InitializeComponent();
        }

        private void Ganador_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.CenterToScreen();

            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.Black;
            button1.FlatStyle = FlatStyle.Popup;
            BtnContinuar.BackColor = Color.Transparent;
            BtnContinuar.ForeColor = Color.Black;
            BtnContinuar.FlatStyle = FlatStyle.Popup;
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.Black;
            button2.FlatStyle = FlatStyle.Popup;

            Clasificacion.Hide();
            
            data.Hide();
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
            ganador1.Text = generico.ganador1;
            Clasificacion.Text = generico.BtnRanking;
            label1.Text = generico.label12;
            BtnContinuar.Text = generico.BtnContinuar;
            button1.Text = generico.BtnSalirJuego;
            button2.Text = generico.BtnSalir;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            //Al darle al boton continuar, se almacena el nick introducido por el usuario en el textbox TBNick en la variable Nick
            Nick = TBNick.Text;
            //Se llama a la funcion continuar, para entender ir a la linea 96
            continuar(Nick);
            //Se crea un List, que servirá para poder ordenar el datagrid, en este caso, segun el elemento tiempo de menor a mayor 
            //Para eso la lista list será igual al bindinglist lista1
            List<Jugador> list = Jugador.lista1.ToList();
            //Aqui ordenamos la lista segun la variable tiempo
            list = list.OrderBy(x => x.Tiempo).ToList();
            //En este punto si tenemos 12 jugadores..
            if (list.Count == 12)
            {
                //eliminaremos el ultimo, para que en el datagrid solo aparezcan 11 elementos
                list.RemoveAt(11);
            }
            //Aqui el bindinglist lista1 será igual a la lista list
            Jugador.lista1 = new BindingList<Jugador>(list);
            //aqui ponemos en el datagrid los elementos de lista1
            data.DataSource = Jugador.lista1;
            //le damos el ancho a las columnas del datagrid para que ocupen todo el ancho del datagrid
            data.Columns[0].Width = 245;
            data.Columns[1].Width = 244;
         
        }

        private void TBNick_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Esta funcion lo que hace es, al pulsar la tecla enter del teclado
            char tecla = e.KeyChar;
            if (tecla == '\r')
            {
                //hará lo mismo que hace el boton continuar, para entender ir a la linea 58
                Nick = TBNick.Text;
                continuar(Nick);
                data.DataSource = Jugador.lista1;
                data.Columns[0].Width = 245;
                data.Columns[1].Width = 245;
              
            }
        }

        private void continuar(string Nick)
            
            //Esta funcion lo que hace es
        {
            //Si Nick es nada o Introduce tu Nick
            if (Nick == ""||Nick== "Introduce tu Nick")
            {
                //llama a errorprovider1 y pone el mensaje..
                errorProvider1.SetError(TBNick, "Introduce tu nick");
                
                //en el textbox TBNick aparecerá el mensaje..
                TBNick.Text = "Introduce tu Nick";
                //Este metodo lo que hace es que el foco se entrará en el boton continuar, y no en el textbox TBNick, asi el usuario tendrá que clicar en el textbox y asi se ejecutará el codigo de TBNick_MouseClick
                BtnContinuar.Focus();
            }
            //Si Nick no está vacio
            else
            {
                //la variable Nick de la clase Jugador será igual a la variable Nick de esta clase
                jugador.Nick = this.Nick;
                //Se añade un objeto jugador al bindinglist de la clase Jugador
                Jugador.lista1.Add(new Jugador
                {
                    //con estas variables
                    Nick = this.Nick,
                    Tiempo = FormJuego.tiempoResult
                });
                //se elimina errorProvider1 y apareceran los elementos con .show y se esconderan los elementos con .Hide 
                errorProvider1.Clear();
                Clasificacion.Show();
                data.Show();
                BtnContinuar.Hide();
                label1.Hide();
                TBNick.Hide();
                PBGif.Hide();
                ganador1.Hide();
                pictureBox1.Hide();

            }

        }
        private void TBNick_MouseClick(object sender, MouseEventArgs e)
        {
            //Esta funcion lo que hace es que, cuando clickas en el textbox TBNick..
            //Si hay un texto en TBNick igual al mensaje..
            if (TBNick.Text== "Introduce tu Nick")
            {
                //Borrará el mensaje
                TBNick.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
