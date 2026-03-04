using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusquedaDeParejas.Properties;
using System.IO;
using System.Threading;
using System.Globalization;
using BusquedaDeParejas.Idiomas;

namespace BusquedaDeParejas
{
    public partial class FormJuego : Form
    {
        //variable que indica el tiempo que falta para que termine el juego
        int tiempo;
        //array de lo valores dados para las imagenes, para entender ir a la linea 56
        string[] imagenes = new string[12];
        //array de imagenes con los elementos desordenados
        string[] imagenesFinal = new string[12];
        //variable que indica si la primera imagen está destapada
        bool imagen1Destapada=false;
       //variable que indicará el primer picturebox que se clicka
        string pb1;
        //variable que indicará el segundo picturebox que se clicka
        string pb2;
        //variable que indicará que imagen se ha puesto en el primer picturebox
        string im1;
        //variable que indicará que imagen se ha puesto en el segundo picturebox
        string im2;
        //variable que indica cuantas veces se han abierto dos picturebox iguales
        int cont;
        public static int tiempoResult;
        //variable que se usará como timer para cuando pulsas la segunda imagen y esta es distinta que la primera
        int tiempoTimer=1;
        //variable que se usará para la funcion barajar en la linea 101
        Random random = new Random();
        int num1=0;
            


        public FormJuego()
        {
            InitializeComponent();
            //Al iniciarse el formulario, TimerDificultad se activará
            TimerDificultad.Enabled = true;
            //La variable tiempo recogerá el valor de Tiempo, inicializada en MenuInicio
            tiempo = MenuInicio.Tiempo;
            //Se mostrará en el label Tiempo la variable tiempo.
            LblTiempo.Text = tiempo.ToString();
            


        }

        private void FormJuego_Load(object sender, EventArgs e)
        {
            //Al cargar el formulario,este aparecerá en el centro, y los botones tendrán esas caracteristicas
            this.CenterToScreen();
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.Black;
            button2.FlatStyle = FlatStyle.Popup;
            BtnSalirJuego.BackColor = Color.Transparent;
            BtnSalirJuego.ForeColor = Color.Black;
            BtnSalirJuego.FlatStyle = FlatStyle.Popup;

            //el array imagenes será un array con los valores de las imagenes, para entenderlo ir a la linea 79
            imagenes = cargarImagenes();
           
            //el array imagenesFinal será un array con los elementos del array imagenes desordenados, para eso se usa la funcion barajar, en la linea 103
            imagenesFinal = barajar(imagenes);

            //Se inicializa la variable a false
            imagen1Destapada = false;
            idioma(MenuInicio.lengua);


        }

        private void idioma(int lengua)
        {
            if (lengua == 2)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }else if (lengua == 3)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            button2.Text = generico.button2;
            BtnSalirJuego.Text = generico.BtnSalirJuego;


        }
        private string[] cargarImagenes()
        {
            //Funcion que servirá para crear un array con un valor que está relacionado con la imagen real
            //Por ejemplo, AA corresponde a la imagen AudiAmarillo
            string[] imagenes = new string[12];

            imagenes[0] = "AA";
            imagenes[1] = "AN";
            imagenes[2] = "AR";
            imagenes[3] = "FA";
            imagenes[4] = "FN";
            imagenes[5] = "FR";
            imagenes[6] = "AA";
            imagenes[7] = "AN";
            imagenes[8] = "AR";
            imagenes[9] = "FA";
            imagenes[10] = "FN";
            imagenes[11] = "FR";

            return imagenes;


        }

        private string[] barajar(string[] imagenes)
        {
            
            //Funcion que servirá para desordenar los elementos del array que se introduzca, en este caso imagenes

            int randomavalue; 
            string imagen;

            for(int i=0; i < imagenes.Length; i++)
            {
                randomavalue = random.Next(0, 11);
                imagen = imagenes[randomavalue];
                imagenes[randomavalue] = imagenes[i];
                imagenes[i] = imagen;

            }

            return imagenes;
        }
    
        private void TimerDificultad_Tick(object sender, EventArgs e)
        {

            //Funcion del timer de dificultad, dependiendo la dificultad seleccionada, el timer empezará a contar hacia abajo
            tiempo = tiempo - 1;

            //el label tiempo irá mostrando la variable tiempo cada segundo
            LblTiempo.Text = tiempo.ToString();

            //cuando tiempo llegue a cero,
            if (tiempo == 0)
            {
                //se desactivará el timer
                TimerDificultad.Enabled = false;

                //se cerrará el formulario
                this.Close();

                //se abrirá el formulario perder
                perder formulario1 = new perder();
                formulario1.Show();

            }
        }

        private void BtnSalirJuego_Click(object sender, EventArgs e)
        {
            //Al pulsar el boton de Menu, este formulario se cerrará
            
            this.Close();
            
        }

        private void TimerMostrarImagen_Tick(object sender, EventArgs e)
        {
            //Funcion para cuando pulsas en la segunda imagen
            //tiempoTimer va restando de un segundo
            tiempoTimer = tiempoTimer - 1;
          
            //Cuando tiempoTimer llega a 0
            if (tiempoTimer == 0)
            {

                //Se llamará a la funcion ocultarImagen
                ocultarImagen1(pb1, pb2);
                //las variables im1 e im2 se borran
                im1 = "";
                im2 = "";
                //la variable imagen1Destapada se cambia a false, 
                imagen1Destapada = false;
                //El timer se para
                TimerMostrarImagen.Stop();
                //Y se vuelve a poner a 1 segundo
                tiempoTimer = 1;

                //Todos los picturebox se ponen en enabled= true para que el usuario pueda volver a pinchar sobre ellos
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
                pictureBox6.Enabled = true;
                pictureBox7.Enabled = true;
                pictureBox8.Enabled = true;
                pictureBox9.Enabled = true;
                pictureBox10.Enabled = true;
                pictureBox11.Enabled = true;
                pictureBox12.Enabled = true;

                //El TimerMostrarImagen se pone en enabled=false, para que no funcione
                TimerMostrarImagen.Enabled = false;             
            }        
        }

        private void ganador(int cont)
        {
            //Esta funcion lo que hace es abrir el formulario Ganador
            //Si la variable cont es igual a 6
            if (cont == 6)
            {
                //la variable tiempoResult será igual al valor dado por la funcion tiempoclasificacion, para entender ir a la linea 2574
                tiempoResult= tiempoclasificacion(tiempo);

                //Se abre el formulario Ganador
                Ganador formulario2 = new Ganador();
                
                //Se cierra este formulario
                this.Close();
               formulario2.Show();                      
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //PictureBox1 

            

            
            //Variable que servirá para indicar de que picturebox es
            

            //Si imagen1Destapada es false, significa que no hay una imagen ya destapada, esta seria la primera
            if ( imagen1Destapada== false)
            {
            num1 = 1;
              //Se llama a la funcion imagen, para entender ir a la linea 947
            imagen(num1, imagenesFinal);

                //imagen1Destapada se pone en true
                imagen1Destapada = true;

                //pb1 recoge el valor que devuelve la funcion pictureboxcual, para entender ir a la linea 1772
                pb1 = pictureboxCual(num1);
                
            }
            //Si imagen1Destapada es true, significa que es el segundo picturebox que se destapa
            else if (imagen1Destapada == true&&num1!=1)
            {
                num1 = 1;
                //Se llama a la funcion imagen, para entender ir a la linea 947
                imagen(num1, imagenesFinal);

                //pb2 recoge el valor que devuelve la funcion pictureboxcual, para entender ir a la linea 1772
                pb2 = pictureboxCual(num1);
                
                //Aqui se comparan las variables im1 e im2 (el array arrayFinal siempre hay dos elementos iguales), si im1 e im2 son distintas
                if (im1 != im2)
                {
                    //Si el timer que se usa para mostrar la segunda imagen está desactivado
                    if (TimerMostrarImagen.Enabled == false)
                    {
                        //Activamos el timer que se usa para mostrar la segunda imagen
                        TimerMostrarImagen.Enabled = true;
                        //Iniciamos el timer que se usa para mostrar la segunda imagen
                        TimerMostrarImagen.Start();

                        //Ponemos todos los pictureBox en Enabled=false para que el usuario no pueda destapar otros picturebox antes de que se acabe el timerMostrarImagen,
                        //ya que el timerMostrarImagen aun tiene que ejecutar el codigo necesario anterior a que el usuario vuelva a pinchar en otro picturebox
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                        
                    }
                    
                }

                //Si im1 e im2 son iguales..
                else { 
                    //imagen1Destapada se vuelve a resetear a false
                    imagen1Destapada = false;
                    //Se vuelven a poner im1 e im2 a 0
                    im1 = "";
                    im2 = "";
                    //La variable cont aumenta en 1
                    cont++;
                }
                
            }
            //Una vez echas todas las comprobaciones, se llama a la funcion ganador, para entender ir a la linea 197
            ganador(cont);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {
                num1 = 2;

                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);

            }

            else if (imagen1Destapada == true && num1 != 2)
            {
                num1 = 2;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                        
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }            
            }

            ganador(cont);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
            

            if (imagen1Destapada == false)
            {
                num1 = 3;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 3)
            {
                num1 = 3;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }      
            }
            ganador(cont);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {
                num1 = 4;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 4)
            {
                num1 = 4;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }       
            }
            ganador(cont);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
            

            if (imagen1Destapada == false)
            {
                num1 = 5;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 5)
            {
                num1 = 5;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }            
            }
            ganador(cont);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {
                num1 = 6;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 6)
            {
                num1 = 6;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }          
            }
            ganador(cont);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
            

            if (imagen1Destapada == false)
            {

                num1 = 7;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 7)
            {
                num1 = 7;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }                
            }
            ganador(cont);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {
                num1 = 8;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 8)
            {
                num1 = 8;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }            
            }
            ganador(cont);
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {

                num1 = 9;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 9)
            {
                num1 = 9;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }               
            }
            ganador(cont);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {

                num1 = 10;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 10)
            {
                num1 = 10;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }              
            }

            ganador(cont);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
            

            if (imagen1Destapada == false)
            {

                num1 = 11;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 11)
            {
                num1 = 11;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }             
            }
            ganador(cont);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //Mirar picturebox1 para entender
             

            if (imagen1Destapada == false)
            {
                num1 = 12;
                imagen(num1, imagenesFinal);
                imagen1Destapada = true;
                pb1 = pictureboxCual(num1);
            }

            else if (imagen1Destapada == true && num1 != 12)
            {
                num1 = 12;
                imagen(num1, imagenesFinal);
                pb2 = pictureboxCual(num1);

                if (im1 != im2)
                {

                    if (TimerMostrarImagen.Enabled == false)
                    {
                        TimerMostrarImagen.Enabled = true;
                        TimerMostrarImagen.Start();
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;
                        pictureBox7.Enabled = false;
                        pictureBox8.Enabled = false;
                        pictureBox9.Enabled = false;
                        pictureBox10.Enabled = false;
                        pictureBox11.Enabled = false;
                        pictureBox12.Enabled = false;
                    }
                }
                else
                {
                    imagen1Destapada = false;
                    im1 = "";
                    im2 = "";
                    cont++;
                }
            }
           
            ganador(cont);
        }

        private void imagen(int num1, string[] imagenesFinal)
        {
            //Esta funcion pinta la imagen en el picturebox en el que se esté

            //Si num1 es 1, significa que estamos en el picturebox1
            if (num1 == 1)
            {
                //Si el elemento 0 del array es igual a AA
                if (imagenesFinal[0] == "AA")
                {
                    //Se pone la imagen correspondiente
                    pictureBox1.Image = Resources.audiAmarillo;
                    //Si la variable im1 está vacia
                    if (im1 == "")
                    {
                        //im1 será igual al elemento 0 del array, en este caso im1 será igual a AA.
                        im1 = imagenesFinal[0];
                    }

                    //Si im1 ya tiene un valor, significa que estamos dando click en el segundo picturebox
                    else
                    {
                        //im2 será igual al elemento 0 del array, en este caso im2 será igual a AA
                        im2=imagenesFinal[0];
                    }
                }
                else if (imagenesFinal[0] == "AN")
                {
                    pictureBox1.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[0];
                    }
                    else
                    {
                        im2 = imagenesFinal[0];
                    }
                }
                else if (imagenesFinal[0] == "AR")
                {
                    pictureBox1.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[0];
                    }
                    else
                    {
                        im2 = imagenesFinal[0];
                    }
                }
                else if (imagenesFinal[0] == "FA")
                {
                    pictureBox1.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[0];
                    }
                    else
                    {
                        im2 = imagenesFinal[0];
                    }
                }
                else if (imagenesFinal[0] == "FN")
                {
                    pictureBox1.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[0];
                    }
                    else
                    {
                        im2 = imagenesFinal[0];
                    }
                }
                else if (imagenesFinal[0] == "FR")
                {
                    pictureBox1.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[0];
                    }
                    else
                    {
                        im2 = imagenesFinal[0];
                    }
                }

            }
            else if (num1 == 2)
            {
                if (imagenesFinal[1] == "AA")
                {
                    pictureBox2.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }
                else if (imagenesFinal[1] == "AN")
                {
                    pictureBox2.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }
                else if (imagenesFinal[1] == "AR")
                {
                    pictureBox2.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }
                else if (imagenesFinal[1] == "FA")
                {
                    pictureBox2.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }
                else if (imagenesFinal[1] == "FN")
                {
                    pictureBox2.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }
                else if (imagenesFinal[1] == "FR")
                {
                    pictureBox2.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[1];
                    }
                    else
                    {
                        im2 = imagenesFinal[1];
                    }
                }

            }
            else if (num1 == 3)
            {
                if (imagenesFinal[2] == "AA")
                {
                    pictureBox3.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }
                else if (imagenesFinal[2] == "AN")
                {
                    pictureBox3.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }
                else if (imagenesFinal[2] == "AR")
                {
                    pictureBox3.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }
                else if (imagenesFinal[2] == "FA")
                {
                    pictureBox3.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }
                else if (imagenesFinal[2] == "FN")
                {
                    pictureBox3.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }
                else if (imagenesFinal[2] == "FR")
                {
                    pictureBox3.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[2];
                    }
                    else
                    {
                        im2 = imagenesFinal[2];
                    }
                }

            }
            else if (num1 == 4)
            {
                if (imagenesFinal[3] == "AA")
                {
                    pictureBox4.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }
                else if (imagenesFinal[3] == "AN")
                {
                    pictureBox4.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }
                else if (imagenesFinal[3] == "AR")
                {
                    pictureBox4.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }
                else if (imagenesFinal[3] == "FA")
                {
                    pictureBox4.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }
                else if (imagenesFinal[3] == "FN")
                {
                    pictureBox4.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }
                else if (imagenesFinal[3] == "FR")
                {
                    pictureBox4.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[3];
                    }
                    else
                    {
                        im2 = imagenesFinal[3];
                    }
                }

            }
            else if (num1 == 5)
            {
                if (imagenesFinal[4] == "AA")
                {
                    pictureBox5.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }
                else if (imagenesFinal[4] == "AN")
                {
                    pictureBox5.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }
                else if (imagenesFinal[4] == "AR")
                {
                    pictureBox5.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }
                else if (imagenesFinal[4] == "FA")
                {
                    pictureBox5.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }
                else if (imagenesFinal[4] == "FN")
                {
                    pictureBox5.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }
                else if (imagenesFinal[4] == "FR")
                {
                    pictureBox5.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[4];
                    }
                    else
                    {
                        im2 = imagenesFinal[4];
                    }
                }

            }
            else if (num1 == 6)
            {
                if (imagenesFinal[5] == "AA")
                {
                    pictureBox6.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }
                else if (imagenesFinal[5] == "AN")
                {
                    pictureBox6.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }
                else if (imagenesFinal[5] == "AR")
                {
                    pictureBox6.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }
                else if (imagenesFinal[5] == "FA")
                {
                    pictureBox6.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }
                else if (imagenesFinal[5] == "FN")
                {
                    pictureBox6.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }
                else if (imagenesFinal[5] == "FR")
                {
                    pictureBox6.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[5];
                    }
                    else
                    {
                        im2 = imagenesFinal[5];
                    }
                }

            }
            else if (num1 == 7)
            {
                if (imagenesFinal[6] == "AA")
                {
                    pictureBox7.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }
                else if (imagenesFinal[6] == "AN")
                {
                    pictureBox7.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }
                else if (imagenesFinal[6] == "AR")
                {
                    pictureBox7.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }
                else if (imagenesFinal[6] == "FA")
                {
                    pictureBox7.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }
                else if (imagenesFinal[6] == "FN")
                {
                    pictureBox7.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }
                else if (imagenesFinal[6] == "FR")
                {
                    pictureBox7.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[6];
                    }
                    else
                    {
                        im2 = imagenesFinal[6];
                    }
                }

            }
            else if (num1 == 8)
            {
                if (imagenesFinal[7] == "AA")
                {
                    pictureBox8.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }
                else if (imagenesFinal[7] == "AN")
                {
                    pictureBox8.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }
                else if (imagenesFinal[7] == "AR")
                {
                    pictureBox8.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }
                else if (imagenesFinal[7] == "FA")
                {
                    pictureBox8.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }
                else if (imagenesFinal[7] == "FN")
                {
                    pictureBox8.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }
                else if (imagenesFinal[7] == "FR")
                {
                    pictureBox8.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[7];
                    }
                    else
                    {
                        im2 = imagenesFinal[7];
                    }
                }

            }
            else if (num1 == 9)
            {
                if (imagenesFinal[8] == "AA")
                {
                    pictureBox9.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }
                else if (imagenesFinal[8] == "AN")
                {
                    pictureBox9.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }
                else if (imagenesFinal[8] == "AR")
                {
                    pictureBox9.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }
                else if (imagenesFinal[8] == "FA")
                {
                    pictureBox9.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }
                else if (imagenesFinal[8] == "FN")
                {
                    pictureBox9.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }
                else if (imagenesFinal[8] == "FR")
                {
                    pictureBox9.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[8];
                    }
                    else
                    {
                        im2 = imagenesFinal[8];
                    }
                }

            }
            else if (num1 == 10)
            {
                if (imagenesFinal[9] == "AA")
                {
                    pictureBox10.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }
                else if (imagenesFinal[9] == "AN")
                {
                    pictureBox10.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }
                else if (imagenesFinal[9] == "AR")
                {
                    pictureBox10.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }
                else if (imagenesFinal[9] == "FA")
                {
                    pictureBox10.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }
                else if (imagenesFinal[9] == "FN")
                {
                    pictureBox10.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }
                else if (imagenesFinal[9] == "FR")
                {
                    pictureBox10.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[9];
                    }
                    else
                    {
                        im2 = imagenesFinal[9];
                    }
                }

            }
            else if (num1 == 11)
            {
                if (imagenesFinal[10] == "AA")
                {
                    pictureBox11.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }
                else if (imagenesFinal[10] == "AN")
                {
                    pictureBox11.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }
                else if (imagenesFinal[10] == "AR")
                {
                    pictureBox11.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }
                else if (imagenesFinal[10] == "FA")
                {
                    pictureBox11.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }
                else if (imagenesFinal[10] == "FN")
                {
                    pictureBox11.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }
                else if (imagenesFinal[10] == "FR")
                {
                    pictureBox11.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[10];
                    }
                    else
                    {
                        im2 = imagenesFinal[10];
                    }
                }

            }
            else if (num1 == 12)
            {
                if (imagenesFinal[11] == "AA")
                {
                    pictureBox12.Image = Resources.audiAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }
                else if (imagenesFinal[11] == "AN")
                {
                    pictureBox12.Image = Resources.audiNegro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }
                else if (imagenesFinal[11] == "AR")
                {
                    pictureBox12.Image = Resources.audiRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }
                else if (imagenesFinal[11] == "FA")
                {
                    pictureBox12.Image = Resources.ferrariAmarillo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }
                else if (imagenesFinal[11] == "FN")
                {
                    pictureBox12.Image = Resources.ferrariNEgro;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }
                else if (imagenesFinal[11] == "FR")
                {
                    pictureBox12.Image = Resources.ferrariRojo;
                    if (im1 == "")
                    {
                        im1 = imagenesFinal[11];
                    }
                    else
                    {
                        im2 = imagenesFinal[11];
                    }
                }

            }

        }


        private string pictureboxCual(int num1)
        {
            //Esta funcion devuelve cual es el primer picturebox que se destapa, para ello recoge num1
            string pictureboxCual = num1.ToString();



            return pictureboxCual;
        }

        private void ocultarImagen1(string pb1, string pb2)
        {
            //Esta funcion lo que hace es ocultar las imagenes 
            //Si pb1 es 1, significa que el primer picturebox que se clickó es el picturebox1
            if (pb1 == "1")
            {
                //Entonces se pondrá la imagen de interrogacion en el picturebox1
                pictureBox1.Image = Resources.interrogacion1;

                //Y si pb2 es igual a 1, significa que el segundo picturebox que se clickó es el picturebox1
                if (pb2 == "1")
                {
                    //Entonces se pondrá la imagen de interrogacion en el picturebox1
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }





            } else if (pb1 == "2")
            {
                pictureBox2.Image= Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "3")
            {
                pictureBox3.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "4")
            {
                pictureBox4.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "5")
            {
                pictureBox5.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "6")
            {
                pictureBox6.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "7")
            {
                pictureBox7.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "8")
            {
                pictureBox8.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "9")
            {
                pictureBox9.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "10")
            {
                pictureBox10.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "11")
            {
                pictureBox11.Image = Resources.interrogacion1;
                if (pb2 == "1")
                {
                    pictureBox1.Image = Resources.interrogacion1;

                }
                else if (pb2 == "2")
                {
                    pictureBox2.Image = Resources.interrogacion1;

                }
                else if (pb2 == "3")
                {
                    pictureBox3.Image = Resources.interrogacion1;

                }
                else if (pb2 == "4")
                {
                    pictureBox4.Image = Resources.interrogacion1;

                }
                else if (pb2 == "5")
                {
                    pictureBox5.Image = Resources.interrogacion1;

                }
                else if (pb2 == "6")
                {
                    pictureBox6.Image = Resources.interrogacion1;

                }
                else if (pb2 == "7")
                {
                    pictureBox7.Image = Resources.interrogacion1;

                }
                else if (pb2 == "8")
                {
                    pictureBox8.Image = Resources.interrogacion1;

                }
                else if (pb2 == "9")
                {
                    pictureBox9.Image = Resources.interrogacion1;

                }
                else if (pb2 == "10")
                {
                    pictureBox10.Image = Resources.interrogacion1;

                }
                else if (pb2 == "11")
                {
                    pictureBox11.Image = Resources.interrogacion1;

                }
                else if (pb2 == "12")
                {
                    pictureBox12.Image = Resources.interrogacion1;

                }
            }
            else if (pb1 == "12")
            {
                pictureBox12.Image = Resources.interrogacion1;
                
            }

            if (pb2 == "1")
            {
                pictureBox1.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "2")
            {
                pictureBox2.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "3")
            {
                pictureBox3.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "4")
            {
                pictureBox4.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "5")
            {
                pictureBox5.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "6")
            {
                pictureBox6.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "7")
            {
                pictureBox7.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "8")
            {
                pictureBox8.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "9")
            {
                pictureBox9.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "10")
            {
                pictureBox10.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "11")
            {
                pictureBox11.Image = Resources.interrogacion1;
                
            }
            else if (pb2 == "12")
            {
                pictureBox12.Image = Resources.interrogacion1;
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Al pulsar en el boton Salir, se cerrará toda la aplicacion
            Application.Exit();
        }

        private int tiempoclasificacion(int tiempo)
            //Esta funcion devuelve el tiempo que se a tardado en terminar el juego
        {
            //Si la variable dificultad es 1, significa que la dificultad es facil, y que la variable tiempo es 120
            if (MenuInicio.dificultad == 1)
            {
                //tiempoResult será igual a tiempo
                tiempoResult = tiempo;
                //tiempoResult será igual a 120 menos tiempoResult
                tiempoResult = 120 - tiempoResult;

            }
          
            else if (MenuInicio.dificultad == 2)
            {
                tiempoResult = tiempo;
                tiempoResult = 60 - tiempoResult;
            }
            else if (MenuInicio.dificultad == 3)
            {
                tiempoResult = tiempo;
                tiempoResult = 30 - tiempoResult;
            }
            else if (MenuInicio.dificultad == 4)
            {
                tiempoResult = tiempo;
                tiempoResult = 15 - tiempoResult;
            }
            return tiempoResult;
        }
        
    }
}
