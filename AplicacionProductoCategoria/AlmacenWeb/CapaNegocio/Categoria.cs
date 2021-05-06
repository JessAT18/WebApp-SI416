using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class Categoria:Conexion
    {
        private int id_categoria;
        private string nombre;

        public Categoria()
        {
            id_categoria = 0;
            nombre = "";
        }
        public int id_Categoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }
        public string Nombre
        {
            get { return this.nombre;  }
            set { this.nombre = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarCategoria");
            parametroVarchar(nombre, "nom", 40); 
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarCategoria");
            parametroVarchar(nombre, "buscar", 40);
            return mostrarData();
        }
        public DataTable listarCategoria()
        {
            iniciarSP("listarCategoria");
            return mostrarData();
        }
        public bool modificar()
        {
            iniciarSP("modificarCategoria");
            parametroInt(id_categoria, "id_c");
            parametroVarchar(nombre, "nom", 40);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        { 
        iniciarSP("eliminarCategoria");
        parametroInt(id_categoria, "id_c");
         if (ejecutarSP() == true) { return true; } else { return false; }
        }
    }
}
