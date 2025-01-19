using System;
using System.Windows.Forms;
using Dato;
using Modelo;
using Serilog;

namespace Control
{
    /// <summary>
    /// Clase encargada de gestionar la conexión a la base de datos al iniciar el sistema.
    /// <list type="bullet">
    /// <item>
    /// <term>Conectar</term> <see cref="Conectar"/>
    /// </item>
    /// </list>
    /// </summary>
    public class CtrConexion
    {
        Conexion conn = new Conexion();
        private string msjConexion = "";

        public string MsjConexion { get => msjConexion; set => msjConexion = value; }

        /// <summary>
        /// Método encargado de establecer la conexión y mostrar el estado de la misma.
        /// </summary>
        public void Conectar()
        {
            Console.WriteLine("-----CONEXION-----");
            string msj = conn.AbrirConexion();

            if (msj[0] == '1')
            {
                MsjConexion = "CONEXION EXITOSA!";
                MessageBox.Show(MsjConexion, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (msj[0] == '0')
            {
                MsjConexion = "ERROR: " + msj;
                Log.Warning("ERROR: " + msj);
                MessageBox.Show(MsjConexion, "ERROR DE CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.CerrarConexion();
        }

    }
}
