using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;

namespace NEGOCIO
{
    public class Cliente : Conexion
    {
        private int id_cliente;
        private string nombre;
        private string apellidos;
        private string empresa;
        private string telefono;
        private string direccion;

        public Cliente()
        {
            id_cliente = 0;
            nombre = "";
            apellidos = "";
            empresa = "";
            telefono = "";
            direccion = "";
        }
        public int Idcliente
        {
            get { return this.id_cliente; }
            set { this.id_cliente = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }
        public string Empresa
        {
            get { return this.empresa; }
            set { this.empresa = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        //METODO CRUD
        public bool guardar()
        {
            iniciarSP("guardarCliente");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidos, "ape", 30);
            parametroVarchar(empresa, "emp", 50);
            parametroVarchar(telefono, "tel", 10);
            parametroVarchar(direccion, "dir", 50);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool modificar()
        {
            iniciarSP("modificarCliente");
            parametroInt(id_cliente, "id_c");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidos, "ape", 30);
            parametroVarchar(empresa, "emp", 50);
            parametroVarchar(telefono, "tel", 10);
            parametroVarchar(direccion, "dir", 30);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarCliente");
            parametroInt(id_cliente, "id_cli");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar()
        {
            iniciarSP("buscarCliente");
            parametroVarchar(nombre, "buscar", 30);
            return mostrarData();
        }
        public DataTable buscarEmpresa()
        {
            iniciarSP("buscarClienteEmpresa");
            parametroVarchar(empresa, "buscar", 50);
            return mostrarData();
        }
    }
}
