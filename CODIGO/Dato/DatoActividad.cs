using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelo;
using Serilog;

namespace Dato
{
    /// <summary>
    /// Clase que maneja las operaciones CRUD para la entidad Actividad en la base de datos.
    /// <list type="bullet">
    /// <item>
    /// <term>InsertActividad</term> <see cref="InsertActividad"/>
    /// </item>
    /// <item>
    /// <term>SelectActividades</term> <see cref="SelectActividades"/>
    /// </item>
    /// <item>
    /// <term>UpdateCamposActividad</term> <see cref="UpdateCamposActividad"/>
    /// </item>
    /// <item>
    /// <term>DeleteActividad</term> <see cref="DeleteActividad"/>
    /// </item>
    /// </list>
    /// </summary>
    public class DatoActividad
    {
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Imprime la consulta SQL con sus parámetros reemplazados por los valores actuales.
        /// </summary>
        /// <param name="sentencia">La sentencia SQL con parámetros.</param>
        public void ImprimirSQL(string sentencia)
        {
            string sqlWithValues = sentencia;
            foreach (SqlParameter param in cmd.Parameters)
            {
                sqlWithValues = sqlWithValues.Replace(param.ParameterName, param.Value.ToString());
            }
            Console.WriteLine("COMANDO SQL: " + sqlWithValues);
        }

        /// <summary>
        /// Inserta una nueva actividad en la base de datos.
        /// </summary>
        /// <param name="act">El objeto Actividad con los datos a insertar.</param>
        /// <param name="conn">La conexión a la base de datos.</param>
        /// <returns>Un string que indica el resultado de la operación ("1" para éxito, "0" en caso de error).</returns>
        public string InsertActividad(Actividad act, SqlConnection conn)
        {
            Console.WriteLine("-----INSERT ACTIVIDAD-----");
            string x = "";
            string comando = "INSERT INTO Actividad(estado, nombre, descripcion, fechaInicio, fechaFin, horaInicio, horaFin) \n" +
                             "VALUES (@estado, @nombre, @descripcion, @fechaInicio, @fechaFin, @horaInicio, @horaFin); \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@estado", act.Estado);
                cmd.Parameters.AddWithValue("@nombre", act.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", act.Descripcion);
                cmd.Parameters.AddWithValue("@fechaInicio", act.FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaFin", act.FechaFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@horaInicio", act.HoraInicio);
                cmd.Parameters.AddWithValue("@horaFin", act.HoraFin);

                ImprimirSQL(comando);
                cmd.ExecuteNonQuery();
                x = "1";
            }
            catch (SqlException ex)
            {
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }

        /// <summary>
        /// Obtiene una lista de actividades desde la base de datos según el estado proporcionado.
        /// </summary>
        /// <param name="conn">La conexión a la base de datos.</param>
        /// <param name="estado">El estado de las actividades a buscar.</param>
        /// <returns>Una lista de actividades que cumplen con el estado especificado.</returns>
        public List<Actividad> SelectActividades(SqlConnection conn, int estado)
        {
            Console.WriteLine("-----SELECT ACTIVIDAD-----");
            List<Actividad> actividades = new List<Actividad>();
            SqlDataReader reader = null; // TABLA VIRTUAL
            Actividad actividad = null;
            string comando = "SELECT estado, nombre, descripcion, fechaInicio, fechaFin, horaInicio, horaFin FROM Actividad WHERE estado = @estado; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@estado", estado);

                ImprimirSQL(comando);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    actividad = new Actividad();
                    actividad.Estado = Convert.ToInt32(reader["estado"]);
                    actividad.Nombre = reader["nombre"].ToString();
                    actividad.Descripcion = reader["descripcion"].ToString();
                    actividad.FechaInicio = Convert.ToDateTime(reader["fechaInicio"]);
                    actividad.FechaFin = Convert.ToDateTime(reader["fechaFin"]);
                    actividad.HoraInicio = TimeSpan.Parse(reader["horaInicio"].ToString());
                    actividad.HoraFin = TimeSpan.Parse(reader["horaFin"].ToString());

                    actividades.Add(actividad);
                }
            }
            catch (SqlException ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return actividades;
        }

        /// <summary>
        /// Actualiza los campos de una actividad específica.
        /// </summary>
        /// <param name="act">El objeto Actividad con los nuevos valores.</param>
        /// <param name="conn">La conexión a la base de datos.</param>
        /// <param name="sNombreOriginal">El nombre original de la actividad a actualizar.</param>
        /// <returns>Un string que indica el resultado de la operación ("1" para éxito, "0" en caso de error).</returns>
        public string UpdateCamposActividad(Actividad act, SqlConnection conn, string sNombreOriginal)
        {
            Console.WriteLine("-----UPDATE CAMPOS ACTIVIDAD-----");
            string x = "";
            string comando = "UPDATE Actividad SET \n" +
                             "nombre = @nombre, \n" +
                             "descripcion = @descripcion, \n" +
                             "fechaInicio = @fechaInicio, \n" +
                             "fechaFin = @fechaFin, \n" +
                             "horaInicio = @horaInicio, \n" +
                             "horaFin = @horaFin \n" +
                             "WHERE nombre = @nombreOriginal; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@nombre", act.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", act.Descripcion);
                cmd.Parameters.AddWithValue("@fechaInicio", act.FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaFin", act.FechaFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@horaInicio", act.HoraInicio);
                cmd.Parameters.AddWithValue("@horaFin", act.HoraFin);
                cmd.Parameters.AddWithValue("@nombreOriginal", sNombreOriginal);

                ImprimirSQL(comando);
                cmd.ExecuteNonQuery();
                x = "1";
            }
            catch (SqlException ex)
            {
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }

        /// <summary>
        /// Actualiza el estado de una actividad en la base de datos.
        /// </summary>
        /// <param name="act">El objeto Actividad con el estado actualizado.</param>
        /// <param name="conn">La conexión a la base de datos.</param>
        /// <returns>Un string que indica el resultado de la operación ("1" para éxito, "0" en caso de error).</returns>
        public string UpdateEstadoActividad(Actividad act, SqlConnection conn)
        {
            Console.WriteLine("-----UPDATE ESTADO ACTIVIDAD-----");
            string x = "";
            string comando = "UPDATE Actividad SET \n" +
                             "estado = @estado \n" +
                             "WHERE nombre = @nombre; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@estado", act.Estado);
                cmd.Parameters.AddWithValue("@nombre", act.Nombre);

                ImprimirSQL(comando);
                cmd.ExecuteNonQuery();
                x = "1";
            }
            catch (SqlException ex)
            {
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }

        /// <summary>
        /// Elimina una actividad de la base de datos según su nombre.
        /// </summary>
        /// <param name="act">El objeto Actividad con el nombre de la actividad a eliminar.</param>
        /// <param name="conn">La conexión a la base de datos.</param>
        /// <returns>Un string que indica el resultado de la operación ("1" para éxito, "0" en caso de error).</returns>
        public string DeleteActividad(Actividad act, SqlConnection conn)
        {
            Console.WriteLine("-----DELETE ACTIVIDAD-----");
            string x = "";
            string comando = "DELETE FROM Actividad WHERE nombre = @nombre; \n";

            try
            {
                cmd.Connection= conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", act.Nombre);

                ImprimirSQL(comando);
                cmd.ExecuteNonQuery(); 
                x = "1";
            }
            catch (SqlException ex)
            {
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }
        
    }
}
