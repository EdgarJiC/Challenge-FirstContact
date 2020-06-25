using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge_First_Contact
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Dibujo_Principal();
        }

        private void Main_Configuration()
        {

        }


        private void Dibujo_Principal()
        {
            Bitmap MBackGround = new Bitmap(this.Width, this.Height);
            Graphics Grs = Graphics.FromImage(MBackGround);

            Rectangle ShadowCircule_Top = new Rectangle(-50, -10, this.Width + 100, 80);
            Rectangle Main_Rec = new Rectangle(90, 60, this.Width - 120, this.Height - 130);
            Rectangle LeftHeader = new Rectangle(0, 95, 80, 70);
            Rectangle MainHeader = new Rectangle(67, 80, this.Width - 98, 70);

            Pen pen = new Pen(Color.DimGray, 1);
            Brush brush = default(Brush);
            brush = new SolidBrush(Color.DimGray);

            // Top and Bottom Effect
            Grs.DrawLine(pen, 30, 40, this.Width - 30, 40);

            // Main BackGround
            pen = new Pen(Color.WhiteSmoke, 1);
            Grs.DrawRectangle(pen, Main_Rec);

            // Main Tab
            Grs.FillRectangle(brush, LeftHeader);
            Grs.FillRectangle(brush, MainHeader);

            pen = new Pen(Color.Gainsboro, 6); //Color.FromArgb(236,78,8)
            Grs.DrawLine(pen, 0, 162, 90, 162);
            Grs.DrawLine(pen, 67, 147, this.Width - 32, 147);
            pen = new Pen(Color.DimGray, 1);
            Grs.DrawLine(pen, 67, 80, 67, 144);

            //  -------- Draw Triangle ---------- //

            //Draw a triangle on the form.
            //first have to define an array of points.
            
            pen = new Pen(Color.Black);
            Point[] pnt = new Point[3];

            pnt[0].X = 68;
            pnt[0].Y = 150;

            pnt[1].X = 89;
            pnt[1].Y = 150;

            pnt[2].X = 89;
            pnt[2].Y = 163;

            Grs.DrawPolygon(pen, pnt);

            //Do a filled triangle
            //First create a brush

            
            brush = new SolidBrush(Color.Black);

            Grs.FillPolygon(brush, pnt);

            // -----------------

            Font font = new Font("Tahoma", 16);
            brush = new SolidBrush(Color.Silver);
            Grs.DrawString("First Contact",font,brush,30,11);
            Grs.DrawString("Aplicacion de Inventario", font, brush, this.Width - 260, 11);

            this.BackgroundImage = MBackGround;
            BackgroundImageLayout = ImageLayout.None;
        }


    }
}
