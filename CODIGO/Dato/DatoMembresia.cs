using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato
{
    public class DatoMembresia
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
        public string InsertMembresia(Membresia mem, SqlConnection conn)
        {
            Console.WriteLine("-----INSERT MEMBRESIA-----");
            string x = "";
            string precio = mem.Precio.ToString().Replace(",", ".");
            string comando = "INSERT INTO Membresia (planMembresia, fechaInicio, fechaFin, promocion, descuento, detallePromocion, precio, idCliente, estado) \n" +
                             "VALUES (@plan, @fechaInicio, @fechaFin, @promocion, @descuento, @detallePromocion, @precio, @idCliente, @estado); \n";
            //"VALUES ('"+ mem.Plan + "', '"+ mem.FechaInicio + "', '"+ mem.FechaFin + "', '"+mem.Promocion+"', "+mem.Descuento+", '"+mem.DetallePromocion+"','"+mem.CedulaCliente+"', "+precio +"); \n";  
            Console.WriteLine(comando);

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@plan", mem.Plan);
                cmd.Parameters.AddWithValue("@fechaInicio", mem.FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaFin", mem.FechaFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@promocion", mem.Promocion);
                cmd.Parameters.AddWithValue("@descuento", mem.Descuento);
                cmd.Parameters.AddWithValue("@detallePromocion", mem.DetallePromocion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@idCliente", mem.IdCliente);
                cmd.Parameters.AddWithValue("@estado", mem.Estado);


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

        public List<Membresia> SelectMembresias(SqlConnection conn, int estado)
        {
            Console.WriteLine("-----SELECT MEMBRESIA-----");
            List<Membresia> membresias = new List<Membresia>();
            SqlDataReader reader = null; // TABLA VIRTUAL
            Membresia membresia = null;
            string comando = "SELECT \n" +
                "men.planMembresia, men.fechaInicio, men.fechaFin, men.promocion, men.descuento, men.detallePromocion, men.precio, cli.Cedula, cli.Apellido, cli.Nombre, men.estado \n" +
                "FROM Membresia AS men \n" +
                "INNER JOIN CLIENTE AS cli ON men.idCliente = cli.Id_Cliente\n" +
                "WHERE men.estado = @estado;\n";

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
                    membresia = new Membresia();
                    membresia.Plan = reader["planMembresia"].ToString();
                    membresia.FechaInicio = Convert.ToDateTime(reader["fechaInicio"]);
                    membresia.FechaFin = Convert.ToDateTime(reader["fechaFin"]);
                    membresia.Promocion = reader["promocion"].ToString();
                    membresia.Descuento = Convert.ToInt32(reader["descuento"]);
                    membresia.DetallePromocion = reader["detallePromocion"].ToString();
                    //membresia.CedulaCliente = reader["cedulaCliente"].ToString();
                    membresia.Precio = Convert.ToDouble(reader["precio"]);
                    membresia.Estado = Convert.ToInt32(reader["estado"]);
                    // Crear una nueva instancia de Cliente y asignar propiedades
                    Cliente cliente = new Cliente
                    {
                        Cedula = reader["Cedula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString()
                    };

                    // Asignar la instancia de Cliente a la Membresia
                    membresia.Cliente = cliente;

                    membresias.Add(membresia);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return membresias;
        }




        public string SelectCliente(SqlConnection conn, string cedula)
        {
            Console.WriteLine("-----SELECT MEMBRESIA-----");
            SqlDataReader reader = null; // TABLA VIRTUAL
            Cliente cli = null;
            string idCliente = "";
            string comando = "SELECT id_Cliente, cedula, nombre, apellido, fechaNacimiento, telefono, direccion, estado, tipo, comprobante FROM Cliente WHERE cedula = @cedula; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@cedula", cedula);

                ImprimirSQL(comando);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    idCliente = reader["id_Cliente"].ToString();
                    string tipo = reader["tipo"]?.ToString();

                    if (tipo == "ESTUDIANTE")
                    {
                        cli = new ClienteEstudiante(
                            reader["cedula"].ToString(),
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(),
                            DateTime.Parse(reader["fechaNacimiento"].ToString()),
                            reader["telefono"].ToString(),
                            reader["direccion"].ToString(),
                            reader["estado"].ToString(),
                            reader["comprobante"].ToString()
                        );
                    }
                    else
                    {
                        cli = new Cliente(
                            reader["cedula"].ToString(),
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(),
                            DateTime.Parse(reader["fechaNacimiento"].ToString()),
                            reader["telefono"].ToString(),
                            reader["direccion"].ToString(),
                            reader["estado"].ToString()
                        );
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idCliente;
        }

        public string SelectCedulaCliente(SqlConnection conn, string idCliente)
        {
            Console.WriteLine("-----SELECT MEMBRESIA-----");
            SqlDataReader reader = null; // TABLA VIRTUAL
            Cliente cli = null;
            string cedula = "";
            string comando = "SELECT cli.Cedula \nFROM Membresia AS men \nINNER JOIN Cliente AS cli ON men.idCliente = cli.Id_Cliente \nWHERE men.idCliente = @Id_Cliente; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);

                ImprimirSQL(comando);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cedula = reader["Cedula"].ToString();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cedula;
        }



        public string UpdateCamposMembresia(Membresia mem, SqlConnection conn, string SNombrePlan)
        {
            Console.WriteLine("-----UPDATE CAMPOS MEMBRESIA-----");
            string x = "";
            string comando = "UPDATE Membresia SET \n" +
                             "planMembresia = @plan, \n" +
                             "fechaInicio = @fechaInicio, \n" +
                             "fechaFin = @fechaFin, \n" +
                             "promocion = @promocion, \n" +
                             "descuento = @descuento, \n" +
                             "detallePromocion = @detallePromocion, \n" +
                             "precio = @precio \n" +
                             "WHERE planMembresia = @nombrePlan; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@plan", mem.Plan);
                cmd.Parameters.AddWithValue("@fechaInicio", mem.FechaInicio.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaFin", mem.FechaFin.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@promocion", mem.Promocion);
                cmd.Parameters.AddWithValue("@descuento", mem.Descuento);
                cmd.Parameters.AddWithValue("@detallePromocion", mem.DetallePromocion);
                cmd.Parameters.AddWithValue("@precio", mem.Precio);
                cmd.Parameters.AddWithValue("@nombrePlan", SNombrePlan);
                ;

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
        public string UpdateEstadoMembresia(Membresia mem, SqlConnection conn)
        {
            Console.WriteLine("-----UPDATE ESTADO MEMBRESIA-----");
            string x = "";
            string comando = "UPDATE Membresia SET \n" +
                             "estado = @estado \n" +
                             "WHERE planMembresia = @plan; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@estado", mem.Estado);
                cmd.Parameters.AddWithValue("@plan", mem.Plan);

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
        public string DeleteMembresia(Membresia mem, SqlConnection conn)
        {
            Console.WriteLine("-----DELETE MEMBRESIA-----");
            string x = "";
            string comando = "DELETE FROM Membresia WHERE planMembresia = @plan; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@plan", mem.Plan);

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
