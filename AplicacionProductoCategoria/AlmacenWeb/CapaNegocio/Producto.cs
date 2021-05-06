using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Security.Cryptography;

namespace CapaNegocio
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
            descripcion= "";
            precio = 0;
            stock = 0;
            id_categoria = 0;
        }
        public int id_Producto
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
        public int id_Categoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarProducto");
            parametroVarchar(descripcion, "des", 30);
            parametroDecimal(precio, "pre");
            parametroInt(stock, "sto");
            parametroInt(id_categoria, "id_c");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool modificar()
        {
            iniciarSP("modificarProducto");
            parametroInt(id_producto, "id_p");
            parametroVarchar(descripcion, "des", 30);
            parametroDecimal(precio, "pre");
            parametroInt(stock, "stoc");
            parametroInt(id_categoria, "id_c");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarProducto");
            parametroInt(id_producto, "id_p");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar()
        {
            iniciarSP("buscarProducto");
            parametroVarchar(descripcion, "buscar", 40);
            return mostrarData();
            
        }
    }
}
