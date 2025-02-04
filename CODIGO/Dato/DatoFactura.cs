﻿using Modelo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dato
{
    /// <summary>
    /// Clase que maneja las operaciones CRUD para la entidad Factura en la base de datos.
    /// <list type="bullet">
    /// <item>
    /// <term>InsertFactura</term> <see cref="InsertFactura"/>
    /// </item>
    /// <item>
    /// <term>SelectFact</term> <see cref="SelectFact"/>
    /// </item>
    /// <item>
    /// <term>UpdateEstadoFactura</term> <see cref="UpdateEstadoFactura"/>
    /// </item>
    /// </list>
    /// </summary>
    public class DatoFactura
    {
        SqlCommand cmd = new SqlCommand();

        public void ImprimirSQL(string sentencia)
        {
            string sqlWithValues = sentencia;
            foreach (SqlParameter param in cmd.Parameters)
            {
                if (param.Value != null)
                {
                    sqlWithValues = sqlWithValues.Replace(param.ParameterName, param.Value.ToString());
                }
                else
                {
                    sqlWithValues = sqlWithValues.Replace(param.ParameterName, "NULL");
                }
            }
            Console.WriteLine("COMANDO SQL: " + sqlWithValues);
        }

        /// <summary>
        /// Inserta una nueva factura en la base de datos.
        /// </summary>
        /// <param name="fact">Factura a insertar.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string InsertFactura(Factura fact, SqlConnection conn)
        {
            Console.WriteLine("-----INSERT FACTURA-----");
            string x = "";
            string comando = "INSERT INTO Factura (numFactura, serie, precioFact, descuentoFact, iva, total, estadoFact, motivoInactivacion, idCliente, idMembresia) \n" +
                             "VALUES (@numfactura, @serie, @preciofact, @descuentofact, @iva, @total, @estadofact, @motivoinactivacion, @idCliente, @idMembresia); \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@numfactura", fact.Numfactura);
                cmd.Parameters.AddWithValue("@serie", fact.Serie);
                cmd.Parameters.AddWithValue("@preciofact", fact.Preciofact);
                cmd.Parameters.AddWithValue("@descuentofact", fact.Descuentofact);
                cmd.Parameters.AddWithValue("@iva", fact.Iva);
                cmd.Parameters.AddWithValue("@total", fact.Total);
                cmd.Parameters.AddWithValue("@estadofact", fact.Estadofact);
                cmd.Parameters.AddWithValue("@motivoinactivacion", fact.Motivoinactivacion);
                cmd.Parameters.AddWithValue("@idCliente", fact.IdCliente);
                cmd.Parameters.AddWithValue("@idMembresia", fact.IdMembresia);             

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
        /// Selecciona todas las facturas de la base de datos.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Lista de facturas con sus datos relacionados de cliente y membresía.</returns>
        public List<Factura> SelectFact(SqlConnection conn)
        {
            Console.WriteLine("-----SELECT Factura-----");
            List<Factura> facturas = new List<Factura>();
            SqlDataReader reader = null; // TABLA VIRTUAL
            Factura factdat;
            string comando = "SELECT " +
                "\nfac.numFactura, fac.serie, fac.precioFact, fac.descuentoFact, fac.iva, fac.total, fac.estadoFact, fac.motivoInactivacion," +
                "\ncli.Cedula, cli.Apellido, cli.Nombre, cli.Telefono," +
                "\nmen.planMembresia, men.promocion, men.descuento, men.precio, men.fechaInicio, men.fechaFin" +
                "\nFROM Factura AS fac" +
                "\nINNER JOIN Cliente AS cli ON fac.idCliente = cli.id_Cliente" +
                "\nINNER JOIN Membresia AS men ON fac.idMembresia = men.idMembresia;";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;
                ImprimirSQL(comando);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    factdat = new Factura();
                    factdat.Numfactura = Convert.ToInt32(reader["numFactura"]);
                    factdat.Serie = reader["serie"].ToString();
                    factdat.Preciofact = reader["precioFact"].ToString();
                    factdat.Descuentofact = reader["descuentoFact"].ToString();
                    factdat.Iva = reader["iva"].ToString();
                    factdat.Total = reader["total"].ToString();
                    factdat.estadofact = reader["estadoFact"].ToString();
                    factdat.motivoinactivacion = reader["motivoInactivacion"].ToString();

                    // Crear una nueva instancia de Cliente y asignar propiedades
                    Cliente cliente = new Cliente
                    {
                        Cedula = reader["Cedula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };

                    // Asignar la instancia de Cliente a la Factura
                    factdat.Cliente = cliente;
                    // Crear una nueva instancia de Membresia y asignar propiedades
                    Membresia membresia = new Membresia
                    {
                        Plan = reader["planMembresia"].ToString(),
                        Promocion = reader["promocion"].ToString(),
                        Descuento = Convert.ToInt32(reader["descuento"]),
                        Precio = Convert.ToDouble(reader["precio"]),
                        FechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(reader["fechaFin"])
                    };

                    // Asignar la instancia de Membresia a la Factura
                    factdat.Membresia = membresia;
                    facturas.Add(factdat);
                }
            }
            catch (SqlException ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return facturas;
        }

        /// <summary>
        /// Selecciona todas las facturas de la base de datos.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Lista de facturas con sus datos relacionados de cliente y membresía.</returns>
        public string SelectCliente(SqlConnection conn, string cedula)
        {
            Console.WriteLine("-----SELECT CLIENTE-----");
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
        /// Selecciona una membresía específica por su plan.
        /// </summary>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <param name="planMembresia">Plan de membresía a seleccionar.</param>
        /// <returns>El ID de la membresía encontrada.</returns>
        public string SelectMembresia(SqlConnection conn, string planMembresia)
        {
            Console.WriteLine("-----SELECT MEMBRESIA-----");
            SqlDataReader reader = null; // TABLA VIRTUAL
            Membresia mem = null;
            string idMembresia = "";
            string comando = "SELECT idMembresia, planMembresia, fechaInicio, fechaFin, promocion, descuento, detallePromocion, precio FROM Membresia WHERE planMembresia = @planMembresia; \n";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS
                cmd.Parameters.AddWithValue("@planMembresia", planMembresia);

                ImprimirSQL(comando);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idMembresia = reader["idMembresia"].ToString();
                    mem = new Membresia();
                    mem.Plan = reader["planMembresia"].ToString();
                    mem.FechaInicio = Convert.ToDateTime(reader["fechaInicio"]);
                    mem.FechaFin = Convert.ToDateTime(reader["fechaFin"]);
                    mem.Promocion = reader["promocion"].ToString();
                    mem.Descuento = Convert.ToInt32(reader["descuento"]);
                    mem.DetallePromocion = reader["detallePromocion"].ToString();                  
                    mem.Precio = Convert.ToDouble(reader["precio"]);
                }

            }
            catch (SqlException ex)
            {
                Log.Warning("ERROR: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            return idMembresia;
        }

        /// <summary>
        /// Actualiza el estado de una factura en la base de datos.
        /// </summary>
        /// <param name="fact">Factura con el nuevo estado.</param>
        /// <param name="conn">Conexión a la base de datos.</param>
        /// <returns>Mensaje indicando el éxito o fracaso de la operación.</returns>
        public string UpdateEstadoFactura(Factura fact, SqlConnection conn)
        {
            Console.WriteLine("-----UPDATE ESTADO Factura-----");
            string x = "";
            string comando = "UPDATE Factura SET " +                            
                             "estadofact = @estadoFact, " +
                             "motivoinactivacion = @motivoInactivacion " +
                             "WHERE serie = @serie";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = comando;

                cmd.Parameters.Clear(); // LIMPIA PARAMETROS UTILIZADOS              
                cmd.Parameters.AddWithValue("@serie", fact.Serie.Trim());               
                cmd.Parameters.AddWithValue("@estadoFact", fact.estadofact);
                cmd.Parameters.AddWithValue("@motivoInactivacion", fact.motivoinactivacion);

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
