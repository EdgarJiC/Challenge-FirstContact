﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_First_Contact
{
    public class Producto
    {
        public int idProducto;
        public int Cantidad;
        public string Nombre_Producto;
        public string Descripcion;
        public string Propetario;
        public double Precio;
        public DateTime Fecha_Compra;

        public Producto()
        {
            idProducto = 0;
            Nombre_Producto = "";
            Descripcion = "";
            Propetario = "No Asignado";
            Precio = 0;
            Fecha_Compra = Convert.ToDateTime("12/31/1970");
            Cantidad = 1;
        }

    }
}
