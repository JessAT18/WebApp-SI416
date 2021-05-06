using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private string servidor;
        private string usuario;
        private string password;
        private string basedatos;
        private MySqlCommand cmd;

        public Conexion()
        {
            this.servidor = "localhost";
            this.usuario = "root";
            this.password = "Passw0rd";
            this.basedatos = "bdproducto";
            this.cmd = new  MySqlCommand();

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
           // this.cmd.Connection = Conectar();
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

        public void parametroDecimal(decimal valor, string param)
        {
            MySqlParameter Par = new MySqlParameter();
            Par.ParameterName = param;
            Par.MySqlDbType = MySqlDbType.Decimal;
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
