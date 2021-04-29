using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace capaDatos
{
    public class clsConexion
    {
        private String servidor;
        private String usuario;
        private String password;
        private String basedatos;
        private MySqlCommand cmd;

        public clsConexion()
        {
            this.servidor = "localhost";
            this.usuario = "root";
            this.password = "Passw0rd";
            this.basedatos = "bdpersona";
            this.cmd = new MySqlCommand();
        }

        public MySqlConnection conectar()
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=" + this.servidor + ";database=" + this.basedatos + ";user=" + this.usuario + ";password=" + this.password;
            cnx.Open();
            return cnx;
        }

        public void desconectar()
        {
            MySqlConnection cnx = this.conectar();
            cnx.Close();
        }

        public void iniciarSP(string nombreSP)
        {
            this.cmd.Connection = conectar();
            this.cmd.CommandText = nombreSP;
            this.cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool ejecutarSP()
        {
            bool res;
            //this.cmd.Connection = conectar();
            if (cmd.ExecuteNonQuery() == 1) { res = true; }
            else { res = false; }
            this.desconectar();
            return res;
        }

        public void parametroInt(int valor, string param)
        {
            MySqlParameter Par = new MySqlParameter();
            Par.ParameterName = param;
            Par.MySqlDbType = MySqlDbType.Int32;
            Par.Value = valor;
            cmd.Parameters.Add(Par);
        }

        public void parametroVarchar(string valor, string param, int dimension)
        {
            MySqlParameter Par = new MySqlParameter();
            Par.ParameterName = param;
            Par.MySqlDbType = MySqlDbType.VarChar;
            Par.Size = dimension;
            Par.Value = valor;
            cmd.Parameters.Add(Par);
        }
        public void parametroFecha(DateTime valor, string param)
        {
            MySqlParameter Par = new MySqlParameter();
            Par.ParameterName = param;
            Par.MySqlDbType = MySqlDbType.DateTime;
            Par.Value = valor;
            cmd.Parameters.Add(Par);
        }

        public DataTable mostrarData()
        {
            DataTable DtResultado = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(this.cmd);
            da.Fill(DtResultado);
            this.desconectar();
            return DtResultado;
        }
    }
}
