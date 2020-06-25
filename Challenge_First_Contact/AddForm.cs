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
    public partial class AddForm : Form
    {

        Producto Elprod;
        public int idProd { get; set; } = 0;

        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            MonthCalendar.SetDate(DateTime.Now);
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            Elprod = new Producto
            {
                Nombre_Producto = TxtProducto.Text,
                Descripcion = TxtDescripcion.Text,
                Propetario = TxtPropetario.Text,
                Cantidad = Convert.ToInt32(TxtCantidad.Text),
                Precio = Convert.ToInt32(TxtPrecio.Text),
                Fecha_Compra = Convert.ToDateTime(MonthCalendar.SelectionStart),
                idProducto = (idProd + 1)
            };
        }
    }
}
