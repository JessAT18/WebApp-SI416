using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class Persona : clsConexion
    {
        private int ci;
        private string nombre;
        private string apellidos;
        private string sexo;
        private DateTime fecha_nacimiento;
        private string telefono;

        public Persona()
        {
            ci = 0;
            nombre = "";
            apellidos = "";
            sexo = "";
            fecha_nacimiento = DateTime.Today.Date;
            telefono = "";
        }

        public int Ci
        {
            get { return this.ci; }
            set { this.ci = value; }
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

        public string Sexo
        {
            get { return this.sexo; }
            set { this.sexo = value; }
        }

        public DateTime Fecha_nacimiento
        {
            get { return this.fecha_nacimiento; }
            set { this.fecha_nacimiento = value; }
        }

        public string Telefono {
            get { return this.telefono; } 
            set { this.telefono = value; } 
        }

        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarPersona");
            parametroInt(ci, "id");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidos, "ape", 60);
            parametroVarchar(sexo, "sex", 1);
            parametroFecha(fecha_nacimiento, "fec");
            parametroVarchar(telefono, "tel", 12);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool modificar()
        {
            iniciarSP("modificarPersona");
            parametroInt(ci, "id");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidos, "ape", 60);
            parametroVarchar(sexo, "sex", 1);
            parametroFecha(fecha_nacimiento, "fec");
            parametroVarchar(telefono, "tel", 12);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarPersona");
            parametroInt(ci, "id");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarPersona");
            parametroVarchar(nombre, "buscar", 30);
            return mostrarData();
        }

    }
}
