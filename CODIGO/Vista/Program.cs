using System;
using System.Windows.Forms;
using Serilog;

namespace Vista
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración de Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:/Logs_CS_Proyect/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Aplicación iniciada.");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VsConexion());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ocurrió un error inesperado.");
            }
            finally
            {
                Log.Information("Aplicación finalizada.");
                Log.CloseAndFlush();
            }
        }
    }
}
