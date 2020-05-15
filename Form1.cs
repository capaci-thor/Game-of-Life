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

        public void Draw()
        {
            
        }


        public bool Status(int x, int y)
        {
            
            return true;
        }

        public int Count(int x, int y)
        {

            return 0;
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
