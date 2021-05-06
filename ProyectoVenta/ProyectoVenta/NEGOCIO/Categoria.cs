using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;

namespace NEGOCIO
{
    public class Categoria : Conexion
    {
        private int id_categoria;
        private string nombre;

        public Categoria()
        {
            id_categoria = 0;
            nombre = "";
        }

        public int Idcategoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarCategoria");
            parametroVarchar(nombre, "nomb", 30);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarCategoria");
            parametroVarchar(nombre, "buscar", 30);
            return mostrarData();
        }

        public DataTable selectCategoria()
        {
            iniciarSP("selectCategoria");
            return mostrarData();
        }
    }
}
