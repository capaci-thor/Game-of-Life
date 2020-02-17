using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//OpenCV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Pruebas_de_IA_imagen
{
    public partial class Form1 : Form
    {
        static int contador = 0;
        static int count;
        static int Xcord;
        static int Ycord;
        // static int cuadros_inicio[2500][2]; 
        Image<Bgr, Byte> img;

        public Form1()
        {
            InitializeComponent();
            img = new Image<Bgr, Byte>(50, 50, new Bgr(255, 255, 255));
            pictureBox1.Image = img.ToBitmap();
        }

        private void Draw()
        {
            Boolean bandera = false;
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(400, 200, new Bgr(255, 255, 255));
            for (int i = 0; i < img.Width - 1; i++)
            {
                for (int j = 0; j < img.Height - 1; j++)
                {
                    if (bandera == false)
                    {
                        img.Data[j, i, 0] = 0;
                        img.Data[j, i, 1] = 0;
                        img.Data[j, i, 2] = 0;
                        bandera = true;
                    }
                    else
                    {
                        img.Data[j, i, 0] = 255;
                        img.Data[j, i, 1] = 255;
                        img.Data[j, i, 2] = 255;
                        bandera = false;

                    }

                }
            }
            pictureBox1.Image = img.ToBitmap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            //int negros = 0;
            int blancos = 0;
            label1.Text = count.ToString();
            Image<Bgr, Byte> img2 = img.Clone();
            for (int i = 0; i < img.Width - 1; i++)
            {
                for (int j = 0; j < img.Height - 1; j++)
                {
                    try
                    {
                        if (img.Data[j, i, 0] == 0)//Si es negro
                        {
                            if (img.Data[j, i + 1, 0] == 255)//abajo
                            {
                                blancos++;
                            }
                            if (img.Data[j, i - 1, 0] == 255)//arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i, 0] == 255)//izquierda
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i, 0] == 255)//derecha
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i - 1, 0] == 255)//Izquierda arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i - 1, 0] == 255)//Derecha arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i + 1, 0] == 255)//Izquierda abajo
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i + 1, 0] == 255)//Derecha abajo
                            {
                                blancos++;
                            }
                            if (blancos <= 1 || blancos >= 4)
                            {
                                img2.Data[j, i, 0] = 255;
                                img2.Data[j, i, 1] = 255;
                                img2.Data[j, i, 2] = 255;
                            }
                        }
                        ///////////////////////////////////////
                        else if (img.Data[j, i, 0] == 255)//Si es blanco
                        {
                            if (img.Data[j, i + 1, 0] == 255)//abajo
                            {
                                blancos++;
                            }
                            if (img.Data[j, i - 1, 0] == 255)//arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i, 0] == 255)//izquierda
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i, 0] == 255)//derecha
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i - 1, 0] == 255)//Izquierda arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i - 1, 0] == 255)//Derecha arriba
                            {
                                blancos++;
                            }
                            if (img.Data[j - 1, i + 1, 0] == 255)//Izquierda abajo
                            {
                                blancos++;
                            }
                            if (img.Data[j + 1, i + 1, 0] == 255)//Derecha abajo
                            {
                                blancos++;
                            }
                            if (blancos == 5)
                            {
                                img2.Data[j, i, 0] = 0;
                                img2.Data[j, i, 1] = 0;
                                img2.Data[j, i, 2] = 0;
                            }
                            blancos = 0;

                        }
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine("Fuera de los limites");
                    }
                    img = img2.Clone();
                    pictureBox1.Image = img.ToBitmap();
                }
            }
        }

            private void button1_Click(object sender, EventArgs e)
            {

                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                else
                {
                    timer1.Start();

                }

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates;
                coordinates = me.Location;
                double Xposicion;
                double Yposicion;
                Console.WriteLine(coordinates.ToString());

                double x = (double)coordinates.X;
                double y = (double)coordinates.Y;
                Xposicion = 0.084175 * x;
                Yposicion = 0.11737089201 * y;
                Xcord = (int)Xposicion;
                Ycord = (int)Yposicion;

                Console.WriteLine(Xcord.ToString());
                Console.WriteLine(Ycord.ToString());
                /* 594, 426
                 *  X real 50
                 *  x box  594
                 *  X = (50/594)*xpos;
                 */
                //cuadros_inicio[contador][0] = Xcord;
                //cuadros_inicio[contador][1] = Ycord;
                img.Data[Ycord, Xcord, 0] = 0;
                img.Data[Ycord, Xcord, 1] = 0;
                img.Data[Ycord, Xcord, 2] = 0;
                pictureBox1.Image = img.ToBitmap();
                contador++;
            }
        
    }
}