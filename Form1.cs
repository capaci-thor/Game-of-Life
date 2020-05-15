using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace game_of_life
{
    public partial class Form1 : Form
    {
        Image<Gray, byte> img = new Image<Gray, byte>(70, 70, new Gray(255));
        Image<Gray, byte> img2;

        public Form1()
        {
            InitializeComponent();
        }

        /* Reglas
         * Una célula muerta con exactamente 3 células vecinas vivas "nace" (es decir, al turno siguiente estará viva).
         * Una célula viva con 2 o 3 células vecinas vivas sigue viva, en otro caso muere (por "soledad" o "superpoblación").
         * 
         * Celulas blancas -> Vivas
         * Celulas negras -> Muertas
         */
        public void Draw()
        {
            for(int i = 0; i < img.Width - 1; i++)
            {
                for(int j = 0; j < img.Width -1; j++)
                {
                    if(Status(i, j))//Si es negro
                    {
                        if(Count(j, i) != 2 || Count(j, i) != 3)
                        {
                            ;
                        }
                        else
                        {
                            img.Data[j, i, 0] = 255; //Muere
                        }
                    }
                    else
                    {
                        if(Count(j, i) == 3)
                        {
                            img.Data[j, i, 0] = 0;
                        }
                    }


                }
            }
            
        }


        public bool Status(int x, int y)//Regresa true si celula viva(negra) y false si celula muerta(blanca)
        {
            if( img.Data[y,x,0] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int Count(int x, int y) //Regresa el numero de celulas vivas al rededor de una coordenada
        {

            int count = 0;
            if (x > 0)
            {
                count = img.Data[y, x - 1, 0] == 0 ? count++ : count; //Izquierda
            }
            if (x < img.Width)
            { 
                count = img.Data[y, x + 1, 0] == 0 ? count++ : count; //Derecha
            }
            if (y > 0)
            {
                count = img.Data[y - 1, x, 0] == 0 ? count++ : count; // Arriba
            }
            if (y < img.Height)
            {
                count = img.Data[y + 1, x, 0] == 0 ? count++ : count; // Abajo
            }
            if ( y > 0 && x > 0)
            {
                count = img.Data[y - 1, x - 1, 0] == 0 ? count++ : count; // Izquierda - arriba
            }
            if ( y < img.Height && x < img.Width)
            {
                count = img.Data[y - 1, x + 1, 0] == 0 ? count++ : count; // Derecha - arriba
            }
            if (y < img.Width && x > 0)
            {
                count = img.Data[y + 1, x - 1, 0] == 0 ? count++ : count; // Izquierda - abajo
            }
            if (y < img.Height && x < img.Width)
            {
                count = img.Data[y + 1, x + 1, 0] == 0 ? count++ : count; // Derecha - abajo
            }

            return count;
        }

        private void Juego_Click(object sender, EventArgs e)
        {
                      
            MouseEventArgs p = (MouseEventArgs)e;

            Point mousepos = p.Location;

            double xpos = (double)mousepos.X / Juego.Height;
            double ypos = (double)mousepos.Y / Juego.Width;

            double x = xpos * img.Height;
            double y = ypos * img.Width;

            img.Data[ Convert.ToInt32(y) , Convert.ToInt32(x) , 0] = 0;
            Juego.Image = img.ToBitmap();
            img2 = img.Copy();
        }
    }
}
