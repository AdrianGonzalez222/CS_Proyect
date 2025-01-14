using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Dato
{
    // GONZALEZ ASTUDILLO ADRIAN
    public class DatoActividad
    {
        SqlCommand cmd = new SqlCommand();

        public void ImprimirSQL(string sentencia)
        {
            string sqlWithValues = sentencia;
            foreach (SqlParameter param in cmd.Parameters)
            {
                sqlWithValues = sqlWithValues.Replace(param.ParameterName, param.Value.ToString());
            }
            Console.WriteLine("COMANDO SQL: " + sqlWithValues);
        }

        //
        // INSERTS
        //
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
                x = "0" + ex.Message; Console.WriteLine(x);
            }
            return x;
        }
        
        //
        // SELECTS
        //
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
                Console.WriteLine(ex.Message);
            }
            return actividades;
        }

        //public List<Actividad> SelectActividades(SqlConnection conn)
        //{
        //    List<Actividad> actividades = new List<Actividad>();
        //    SqlDataReader reader = null; // TABLA VIRTUAL
        //    Actividad actividad = null;
        //    string comando = "SELECT estado, nombre, descripcion, fechaInicio, fechaFin, horaInicio, horaFin FROM Actividad; \n";

        //    try
        //    {
        //        cmd.Connection = conn;
        //        cmd.CommandText = comando;
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            actividad = new Actividad();
        //            actividad.Estado = Convert.ToInt32(reader["estado"]);
        //            actividad.Nombre = reader["nombre"].ToString();
        //            actividad.Descripcion = reader["descripcion"].ToString();
        //            actividad.FechaInicio = Convert.ToDateTime(reader["fechaInicio"]);
        //            actividad.FechaFin = Convert.ToDateTime(reader["fechaFin"]);
        //            actividad.HoraInicio = TimeSpan.Parse(reader["horaInicio"].ToString());
        //            actividad.HoraFin = TimeSpan.Parse(reader["horaFin"].ToString());

        //            actividades.Add(actividad);
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return actividades;
        //}

        //
        // UPDATES
        //
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
                x = "0" + ex.Message; Console.WriteLine(x);
            }
            return x;
        }

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
                x = "0" + ex.Message; Console.WriteLine(x);
            }
            return x;
        }

        //
        // DELETES
        //
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
                x = "0" + ex.Message; Console.WriteLine(x);
            }
            return x;
        }
        

    // FIN
    }
}
