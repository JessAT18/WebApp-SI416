using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;

namespace NEGOCIO
{
    public class Venta : Conexion
    {
        private int id_venta;
        private DateTime fecha;
        private decimal monto;
        private int id_cliente;

        public Venta()
        {
            id_venta = 0;
            fecha = DateTime.Today.Date;
            monto = 0;
            id_cliente = 0;
        }
        public int Idventa
        {
            get { return this.id_venta; }
            set { this.id_venta = value; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        public int Idcliente
        {
            get { return this.id_cliente; }
            set { this.id_cliente = value; }
        }

        public decimal Monto
        {
            get { return this.monto; }
            set { this.monto = value; }
        }

        public bool guardar()
        {
            iniciarSP("guardarVenta");
            parametroFecha(fecha, "fech");
            parametroDecimal(monto, "mont");
            parametroInt(id_cliente, "id_cli");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool modificar()
        {
            iniciarSP("modificarVenta");
            parametroInt(id_venta, "id_v");
            parametroFecha(fecha, "fech");
            parametroDecimal(monto, "mont");
            parametroInt(id_cliente, "id_cli");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarVenta");
            parametroInt(id_venta, "id_v");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar(string buscar)
        {
            iniciarSP("buscarVenta");
            parametroVarchar(buscar, "buscar", 30);
            return mostrarData();
        }

        public string buscarClienteVenta(int id_venta)
        {
            iniciarSP("buscarClienteVenta");
            parametroInt(id_venta, "id_v");
            DataTable cod = new DataTable();
            cod = mostrarData();
            string id = "";
            foreach (DataRow row in cod.Rows)
            {
                id = row["id_cliente"].ToString();
            }
            return id;
        }
    }
}
