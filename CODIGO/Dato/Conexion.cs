using Serilog;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Dato
{
    /// <summary>
    /// Clase que maneja la conexión a la base de datos utilizando la cadena de conexión desde el archivo de configuración.
    /// <list type="bullet">
    /// <item>
    /// <term>AbrirConexion</term> <see cref="AbrirConexion"/>
    /// </item>
    /// <item>
    /// <term>CerrarConexion</term> <see cref="CerrarConexion"/>
    /// </item>
    /// </list>
    /// </summary>
    public class Conexion
    {
        // Cadena de conexión obtenida del archivo de configuración.
        private static string cadena = ConfigurationManager.ConnectionStrings["ConexionProyectoGimnasio"].ConnectionString;
        private SqlConnection connect = null;

        public SqlConnection Connect { get => connect; set => connect = value; }

        /// <summary>
        /// Método para abrir la conexión con la base de datos.
        /// </summary>
        /// <returns>Retorna "1" si la conexión es exitosa, de lo contrario retorna "0" en caso de error.</returns>
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

        /// <summary>
        /// Método para cerrar la conexión con la base de datos.
        /// </summary>
        /// <returns>Retorna "1" si la desconexión es exitosa, de lo contrario retorna "0" en caso de error.</returns>
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
