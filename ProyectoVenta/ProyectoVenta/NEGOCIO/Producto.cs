using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;

namespace NEGOCIO
{
    public class Producto : Conexion
    {
        private int id_producto;
        private string descripcion;
        private decimal precio;
        private int stock;
        private int id_categoria;

        public Producto()
        {
            id_producto = 0;
            descripcion = "";
            precio = 0;
            stock = 0;
            id_categoria = 0;
        }

        public int Idproducto
        {
            get { return this.id_producto; }
            set { this.id_producto = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public decimal Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }


        public int Idcategoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }

        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarProducto");
            parametroVarchar(descripcion, "descr", 20);
            parametroDecimal(precio, "prec");
            parametroInt(stock, "stoc");
            parametroInt(id_categoria, "id_cat");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool modificar()
        {
            iniciarSP("modificarProducto");
            parametroInt(id_producto, "id_prod");
            parametroVarchar(descripcion, "descr", 20);
            parametroDecimal(precio, "prec");
            parametroInt(stock, "stoc");
            parametroInt(id_categoria, "id_cat");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarProducto");
            parametroInt(id_producto, "id_prod");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarProducto");
            parametroVarchar(descripcion, "buscar", 20);
            return mostrarData();
        }
    }
}
