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
        static int count;
        Image<Bgr, Byte> img;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Draw()
        {
            Boolean bandera = false;
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(400, 200, new Bgr(255, 255, 255));
            for(int i = 0; i< img.Width - 1; i++)
            {
                for(int j = 0;  j<img.Height - 1; j++)
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
            label1.Text = count.ToString();
            img = new Image<Bgr, Byte>(400, 200, new Bgr(255, 255, 255));
            pictureBox1.Image = img.ToBitmap();
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
    }
}
