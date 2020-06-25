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

        Dictionary<int, Producto> Productos;

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Get_Data();
            Main_Configuration();
            Dibujo_Principal();
        }

        private void Main_Configuration()
        {
            Main_Grid.ColumnCount = 7;

            Main_Grid.Columns[0].HeaderText = "id";
            Main_Grid.Columns[1].HeaderText = "Producto";
            Main_Grid.Columns[2].HeaderText = "Descripcion";
            Main_Grid.Columns[3].HeaderText = "Propetario";
            Main_Grid.Columns[4].HeaderText = "Precio($)";
            Main_Grid.Columns[5].HeaderText = "Fecha de compra";
            Main_Grid.Columns[6].HeaderText = "Cantidad";


            Main_Grid.Columns[0].Width = 40;
            Main_Grid.Columns[1].Width = 100;
            Main_Grid.Columns[2].Width = 300;
            Main_Grid.Columns[3].Width = 200;
            Main_Grid.Columns[4].Width = 60;
            Main_Grid.Columns[5].Width = 200;
            Main_Grid.Columns[6].Width = 60;

            int DCount;

            Main_Grid.Rows.Add(Productos.Count);

            for (DCount = 0; DCount < Productos.Count; DCount++)
            {
                Main_Grid[0, DCount].Value = Productos.Values.ElementAt(DCount).idProducto;
                Main_Grid[1, DCount].Value = Productos.Values.ElementAt(DCount).Nombre_Producto ;
                Main_Grid[2, DCount].Value = Productos.Values.ElementAt(DCount).Descripcion;
                if (Productos.Values.ElementAt(DCount).Propetario != "") Main_Grid[3, DCount].Value = Productos.Values.ElementAt(DCount).Propetario;
                else Main_Grid[3, DCount].Value = "Propetario Desconocido";

                Main_Grid[4, DCount].Value = Productos.Values.ElementAt(DCount).Precio;

                if (Productos.Values.ElementAt(DCount).Fecha_Compra != Convert.ToDateTime("01/12/1970")) Main_Grid[5, DCount].Value = Productos.Values.ElementAt(DCount).Fecha_Compra;
                else Main_Grid[5, DCount].Value = "Fecha de compra Desconocida";

                Main_Grid[6, DCount].Value = Productos.Values.ElementAt(DCount).Cantidad;
            }

            ToolTip ToolTipPicbox = new ToolTip();
            ToolTipPicbox.SetToolTip(this.PicAdd, "Añadir Nueva Compra");
            ToolTipPicbox.SetToolTip(this.PicRemove, "Remover Compra");
            ToolTipPicbox.SetToolTip(this.PicEdit, "Editar Compra");

        }

        private void Dibujo_Principal()
        {
            Bitmap MBackGround = new Bitmap(this.Width, this.Height);
            Graphics Grs = Graphics.FromImage(MBackGround);

            Rectangle ShadowCircule_Top = new Rectangle(-50, -10, this.Width + 100, 80);
            Rectangle Main_Rec = new Rectangle(20, 60, this.Width - 60, this.Height - 130);
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

            Font font = new Font("Tahoma", 16);
            brush = new SolidBrush(Color.Silver);
            Grs.DrawString("First Contact",font,brush,30,11);
            Grs.DrawString("Aplicacion de Inventario", font, brush, this.Width - 260, 11);

            this.BackgroundImage = MBackGround;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void Get_Data()
        {
            // Conexion SQL
            // Ejemplo de Query para obtener los datos

            /*
             * string Query = "Select * from Tabla_Principal id,Producto, Descripcion, comprador, Propetario, Precio, Fecha, Cantidad";
            // while Recorsed()
                {// Llenar los registros en el diccionario en un solo ciclo

                }
            */

            // Datos Ejemplo
            Productos = new Dictionary<int, Producto>();
            Producto Prr = new Producto()
            {
                idProducto = 0,
                Nombre_Producto = "Computadora Dell",
                Descripcion = "CPU I5 2.4Ghz 16 RAM 500HDD de tipo SSD Sin OS",
                Propetario = "",
                Precio = 200,
                Fecha_Compra = Convert.ToDateTime("05/25/2019"),
                Cantidad = 2
            };

            Productos.Add(Prr.idProducto, Prr);

            Prr = new Producto()
            {
                idProducto = 1,
                Nombre_Producto = "Diadema MPOW",
                Descripcion = "Diadema MPOW sin adaptador USB",
                
                Propetario = "",
                Precio = 89,
                Fecha_Compra = Convert.ToDateTime("02/21/2019"),
                Cantidad = 1
            };

            Productos.Add(Prr.idProducto, Prr);

            Prr = new Producto()
            {
                idProducto = 2,
                Nombre_Producto = "Computadora Apple",
                Descripcion = "Computadora Apple MAC de 2019 16 RAM Intel Core i7",
                Propetario = "Osiris Lopez",
                Precio = 89,
                Fecha_Compra = Convert.ToDateTime("01/12/1970"),
                Cantidad = 1
            };

            Productos.Add(Prr.idProducto, Prr);

            Prr = new Producto()
            {
                idProducto = 3,
                Nombre_Producto = "Diadema Dañada",
                Descripcion = "Diadema Dañada MPOW sin adaptador USB",
                Propetario = "",
                Precio = 0,
                Fecha_Compra = Convert.ToDateTime("04/21/2019"),
                Cantidad = 1
            };

            Productos.Add(Prr.idProducto, Prr);

            Prr = new Producto()
            {
                idProducto = 4,
                Nombre_Producto = "Computadoras HP",
                Descripcion = "CPU I5 1.4Ghz 4 RAM 500HDD  Windows 10 Pro En la posicion FKF01P05",
                Propetario = "",
                Precio = 0,
                Fecha_Compra = Convert.ToDateTime("01/12/1970"),
                Cantidad = 1
            };

            Productos.Add(Prr.idProducto, Prr);

            Prr = new Producto()
            {
                idProducto = 5,
                Nombre_Producto = "Telefono Polycom",
                Descripcion = "",
                Propetario = "Sala de Juntas Principal",
                Precio = 0,
                Fecha_Compra = Convert.ToDateTime("03/15/2019"),
                Cantidad = 1
            };

            Productos.Add(Prr.idProducto, Prr);


        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            PictureBox Pic = (PictureBox)sender;

            switch (Pic.Name)
            {
                case "PicAdd":
                    break;
                case "PicEdit":
                    break;
                case "PicRemove":
                    if(Main_Grid.CurrentRow.Index >= 0) Main_Grid.Rows.RemoveAt(Main_Grid.CurrentRow.Index);
                    break;
            }

        }
    }
}
