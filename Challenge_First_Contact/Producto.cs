using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_First_Contact
{
    class Producto
    {
        public int idProducto;
        public int Cantidad;
        public string Nombre_Producto;
        public string Descripcion;
        public string Comprador;
        public string Propetario;
        public double Precio;
        public DateTime Fecha_Compra;

        public Producto()
        {
            Nombre_Producto = "";
            Descripcion = "";
            Comprador = "";
            Propetario = "No Asignado";
            Precio = 0;
            Fecha_Compra = Convert.ToDateTime("12/31/1970");
            Cantidad = 0;
        }

    }
}
