using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                connect = new SqlConnection();
                connect.ConnectionString = cadena;
                connect.Open();
                return "1";
            }
            catch (Exception ex)
            {
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
                Console.WriteLine("ERROR: " + ex.Message);
                return "0" + ex.Message;
            }
        }


    }
}
