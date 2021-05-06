using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;

namespace NEGOCIO
{
    public class DetalleVenta : Conexion
    {
        private int id_venta;
        private int id_producto;
        private decimal preciov;
        private int cantidad;

        public DetalleVenta()
        {
            id_venta = 0;
            id_producto = 0;
            preciov = 0;
            cantidad = 0;
        }
        public int Idventa
        {
            get { return this.id_venta; }
            set { this.id_venta = value; }
        }
        public int Idproducto
        {
            get { return this.id_producto; }
            set { this.id_producto = value; }
        }
        public decimal Preciov
        {
            get { return this.preciov; }
            set { this.preciov = value; }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarDetalleVenta");
            parametroInt(id_producto, "id_p");
            parametroDecimal(preciov, "prec");
            parametroInt(cantidad, "cant");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarDetalleVenta");
            parametroInt(id_venta, "id_v");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar(int id_venta)
        {
            iniciarSP("buscarDetalleVenta");
            parametroInt(id_venta, "id_v");
            return mostrarData();
        }
    }
}
