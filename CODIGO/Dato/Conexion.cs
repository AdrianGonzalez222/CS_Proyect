using Serilog;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Dato
{
    public class Conexion
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["ConexionProyectoGimnasio"].ConnectionString;
        private SqlConnection connect = null;

        public SqlConnection Connect { get => connect; set => connect = value; }

        public string AbrirConexion()
        {
            try
            {
                connect = new SqlConnection(cadena);
                connect.Open();
                return "1";
            }
            catch (Exception ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine("ERROR: " + ex.Message);
                return "0" + ex.Message;
            }
        }

        public string CerrarConexion()
        {
            try
            {
                connect.Close();
                return "1";
            }
            catch (Exception ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine("ERROR: " + ex.Message);
                return "0" + ex.Message;
            }
        }

    }
}
