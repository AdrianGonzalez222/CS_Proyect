using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelo;
using Serilog;

namespace Dato
{
    /// <summary>
    /// Clase que maneja las operaciones CRUD para la entidad Cliente en la base de datos.
    /// <list type="bullet">
    /// <item>
    /// <term>InsertarCliente</term> <see cref="InsertarCliente"/>
    /// </item>
    /// <item>
    /// <term>SeleccionarCliente</term> <see cref="SeleccionarCliente"/>
    /// </item>
    /// <item>
    /// <term>UpdateCliente</term> <see cref="UpdateCliente"/>
    /// </item>
    /// <item>
    /// <term>UpdateEstadoCliente</term> <see cref="UpdateEstadoCliente"/>
    /// </item>
    /// </list>
    /// </summary>
    public class DatoCliente
    {
        SqlCommand cmd = new SqlCommand();

        public void ImprimirSQL(string sentencia)
        {
            try
            {
                string sqlWithValues = sentencia;
                foreach (SqlParameter param in cmd.Parameters)
                {
                    sqlWithValues = sqlWithValues.Replace(param.ParameterName, param.Value.ToString());
                }
                Console.WriteLine("COMANDO SQL: " + sqlWithValues);
            } 
            catch (Exception ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="cli">Objeto cliente a insertar.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string InsertarCliente(Cliente cli, SqlConnection conn)
        {
            Console.WriteLine("-----INSERT CLIENTE-----");
            string x = "";
            string comando = "INSERT INTO Cliente(cedula, nombre, apellido, fechaNacimiento, telefono, direccion, estado, tipo, comprobante)\n" +
                "VALUES (@cedula, @nombre, @apellido, @fechaNacimiento, @telefono, @direccion, @estado, @tipo, @comprobante);\n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cedula", cli.Cedula);
                cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cli.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cli.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@estado", cli.Estado);

                if (cli is ClienteEstudiante cliEst)
                {
                    cmd.Parameters.AddWithValue("@tipo", "ESTUDIANTE");
                    cmd.Parameters.AddWithValue("@comprobante", cliEst.Comprobante);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@tipo", "ESTANDAR");
                    cmd.Parameters.AddWithValue("@comprobante","SIN COMPROBANTE");
                }
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
        /// Selecciona todos los clientes de la base de datos.
        /// </summary>
        /// <param name="cn">Conexión a la base de datos.</param>
        /// <returns>Lista de objetos Cliente con los datos de la base de datos.</returns>
        public List<Cliente> SeleccionarCliente(SqlConnection cn)
        {
            Console.WriteLine("-----SELECT CLIENTE-----");
            List<Cliente> clientes = new List<Cliente>();
            SqlDataReader dr = null;
            Cliente cli = null;
            string comando = "SELECT cedula, nombre, apellido, fechaNacimiento, telefono, direccion, estado, tipo, comprobante FROM Cliente";
            
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = comando;

                ImprimirSQL(comando);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string tipo = dr["tipo"]?.ToString();

                    if (tipo == "ESTUDIANTE")
                    {
                        cli = new ClienteEstudiante(
                            dr["cedula"].ToString(),
                            dr["nombre"].ToString(),
                            dr["apellido"].ToString(),
                            DateTime.Parse(dr["fechaNacimiento"].ToString()),
                            dr["telefono"].ToString(),
                            dr["direccion"].ToString(),
                            dr["estado"].ToString(),
                            dr["comprobante"].ToString()
                        );
                    }
                    else
                    {
                        cli = new Cliente(
                            dr["cedula"].ToString(),
                            dr["nombre"].ToString(),
                            dr["apellido"].ToString(),
                            DateTime.Parse(dr["fechaNacimiento"].ToString()),
                            dr["telefono"].ToString(),
                            dr["direccion"].ToString(),
                            dr["estado"].ToString()
                        );

                    }

                    clientes.Add(cli);
                }
            }
            catch (SqlException ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return clientes;
        }

        /// <summary>
        /// Actualiza la información de un cliente en la base de datos.
        /// </summary>
        /// <param name="cli">Cliente con la nueva información.</param>
        /// <param name="cn">Conexión a la base de datos.</param>
        /// <param name="uCedulaOrg">Cédula inicial del cliente para hacer la actualización.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string UpdateCliente(Cliente cli, SqlConnection cn, string uCedulaOrg)
        {
            Console.WriteLine("-----UPDATE CLIENTES-----");
            string x = "";
            string comando = "UPDATE Cliente SET \n" +
                             "cedula = @cedula, \n" +
                             "nombre = @nombre, \n" +
                             "apellido = @apellido, \n" +
                             "fechaNacimiento = @fechaNacimiento, \n" +
                             "telefono = @telefono, \n" +
                             "direccion = @direccion, \n" +
                             "estado = @estado, \n" +
                             "tipo = @tipo, \n" +
                             "comprobante = @comprobante \n" +
                             "WHERE cedula = @cedulaOrg; \n";

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cedula", cli.Cedula);
                cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cli.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", cli.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@estado", cli.Estado);
                cmd.Parameters.AddWithValue("@cedulaOrg", uCedulaOrg);

                if (cli is ClienteEstudiante cliEst)
                {
                    cmd.Parameters.AddWithValue("@tipo", "ESTUDIANTE");
                    cmd.Parameters.AddWithValue("@comprobante", cliEst.Comprobante);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@tipo", "ESTANDAR");
                    cmd.Parameters.AddWithValue("@comprobante", "SIN COMPROBANTE");
                }

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
        /// Actualiza el estado de un cliente en la base de datos.
        /// </summary>
        /// <param name="cli">Cliente con el nuevo estado.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string UpdateEstadoCliente(Cliente cli, SqlConnection conn)
        {
            Console.WriteLine("-----UPDATE ESTADO CLIENTE-----");
            string x = "";
            string comando = "UPDATE Cliente SET \n " +
                             "estado = @estado \n" +
                             "WHERE cedula = @cedula; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cedula", cli.Cedula);
                cmd.Parameters.AddWithValue("@estado", cli.Estado);

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
