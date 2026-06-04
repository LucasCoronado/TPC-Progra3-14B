using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPComercio.Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=BDDComercio;Integrated Security=True");
        }

        public void setearConsulta(string consulta)
        {
            comando = new SqlCommand();
            comando.CommandText = consulta;
            comando.Connection = conexion;
        }

        public void ejecutarLectura()
        {
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}