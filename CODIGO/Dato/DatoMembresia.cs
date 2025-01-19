using Modelo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dato
{
    /// <summary>
    /// Clase que maneja las operaciones CRUD para la entidad Membresía en la base de datos.
    /// <list type="bullet">
    /// <item>
    /// <term>InsertMembresia</term> <see cref="InsertMembresia"/>
    /// </item>
    /// <item>
    /// <term>SelectMembresias</term> <see cref="SelectMembresias"/>
    /// </item>
    /// <item>
    /// <term>UpdateCamposMembresia</term> <see cref="UpdateCamposMembresia"/>
    /// </item>
    /// <item>
    /// <term>UpdateEstadoMembresia</term> <see cref="UpdateEstadoMembresia"/>
    /// </item>
    /// </list>
    /// </summary>
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

        /// <summary>
        /// Inserta una nueva membresía en la base de datos.
        /// </summary>
        /// <param name="mem">Membresía a insertar.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string InsertMembresia(Membresia mem, SqlConnection conn)
        {
            Console.WriteLine("-----INSERT MEMBRESIA-----");
            string x = "";
            string precio = mem.Precio.ToString().Replace(",", ".");
            string comando = "INSERT INTO Membresia (planMembresia, fechaInicio, fechaFin, promocion, descuento, detallePromocion, precio, idCliente, estado) \n" +
                             "VALUES (@plan, @fechaInicio, @fechaFin, @promocion, @descuento, @detallePromocion, @precio, @idCliente, @estado); \n"; 
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
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message); 
                Console.WriteLine(x);
            }
            return x;
        }

        /// <summary>
        /// Obtiene todas las membresías con un estado específico.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <param name="estado">Estado de las membresías a seleccionar.</param>
        /// <returns>Lista de membresías con los datos de cliente relacionados.</returns>
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
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return membresias;
        }

        /// <summary>
        /// Obtiene el ID de un cliente mediante su cédula.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <param name="cedula">Cédula del cliente.</param>
        /// <returns>El ID del cliente encontrado.</returns>
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
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return idCliente;
        }

        /// <summary>
        /// Obtiene la cédula de un cliente mediante su ID de cliente.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <param name="idCliente">ID del cliente.</param>
        /// <returns>La cédula del cliente.</returns>
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
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return cedula;
        }

        /// <summary>
        /// Actualiza los campos de una membresía en la base de datos.
        /// </summary>
        /// <param name="mem">Membresía con los nuevos datos.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <param name="SNombrePlan">Nombre del plan de membresía a actualizar.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
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
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }

        /// <summary>
        /// Actualiza el estado de una membresía en la base de datos.
        /// </summary>
        /// <param name="mem">Membresía con el nuevo estado.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
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
                x = "0" + ex.Message;
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(x);
            }
            return x;
        }

    }
}
