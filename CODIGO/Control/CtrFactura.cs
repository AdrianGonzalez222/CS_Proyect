using Dato;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control
{
    /// <summary>
    /// Clase controlador que contiene todos los métodos de la entidad Factura.
    /// </summary>
    public class CtrFactura
    {
        Conexion conn = new Conexion();
        DatoFactura dtFactura = new DatoFactura();

        public static List<Factura> listaFact = new List<Factura>();
        private static List<Membresia> listaMembresia = new List<Membresia>();

        public static List<Factura> ListaFact { get => listaFact; set => listaFact = value; }

        /// <summary>
        /// Obtiene el total de facturas registradas en la base de datos.
        /// </summary>
        /// <returns>El número total de facturas.</returns>
        public int GetTotal()
        {
            ListaFact = TablaConsultarFacturaBD(); // BASE DE DATOS
            return ListaFact.Count;
        }

        /// <summary>
        /// Consulta las facturas de la base de datos y las devuelve como una lista.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Factura"/>.</returns>
        public List<Factura> TablaConsultarFacturaBD()
        {
            List<Factura> facturas = new List<Factura>();
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                facturas = dtFactura.SelectFact(conn.Connect);
            }
            else if (msjBD[0] == '0')
            {
                Log.Error("ERROR: " + msjBD);
                MessageBox.Show("ERROR: " + msjBD);
            }

            conn.CerrarConexion();
            return facturas;
        }

        /// <summary>
        /// Genera un código único para una nueva factura.
        /// </summary>
        /// <returns>El código generado para la factura.</returns>
        public string GenerarFactura()
        {
            return generarCodigoUnico();
        }

        /// <summary>
        /// Genera un código aleatorio único para la factura.
        /// </summary>
        /// <returns>El código único generado para la factura.</returns>
        private string generarCodigoUnico()
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var Serie = new StringBuilder();

            for (int i = 0; i < 12; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                Serie.Append(caracteresPermitidos[indice]);
            }

            return Serie.ToString();
        }

        /// <summary>
        /// Calcula el total de la factura aplicando descuentos y el IVA si es necesario.
        /// </summary>
        /// <param name="precioFact">El precio original de la factura.</param>
        /// <param name="descuentoFact">El descuento aplicado a la factura.</param>
        /// <returns>El total calculado de la factura como cadena de texto.</returns>
        public string CalcularTotal(double precioFact, double descuentoFact)
        {
            double totalFact;
            if (descuentoFact > 0)
            {
                // Si hay descuento y es mayor a 0, lo aplico
                totalFact = precioFact - (precioFact * (descuentoFact / 100)) + (precioFact * 0.15);
            }
            else
            {
                // Si no hay descuento o es 0, solo calculo el IVA
                totalFact = precioFact + (precioFact * 0.15);
            }
            return totalFact.ToString();
        }

        /// <summary>
        /// Ingresa una nueva factura en la base de datos con los datos proporcionados.
        /// </summary>
        /// <param name="numfactura">El número de la factura.</param>
        /// <param name="preciofact">El precio de la factura.</param>
        /// <param name="descuentofact">El descuento aplicado a la factura.</param>
        /// <param name="iva">El valor del IVA aplicado a la factura.</param>
        /// <param name="serie">La serie de la factura.</param>
        /// <param name="cedula">La cédula del cliente asociado a la factura.</param>
        /// <param name="planMembresia">El plan de membresía asociado a la factura.</param>
        /// <returns>Un mensaje que indica si el registro de la factura fue exitoso o hubo un error.</returns>
        public string IngresarFact(int numfactura, string preciofact, string descuentofact, string iva, string serie, string cedula, string planMembresia)
        {
            string msg;
            Factura fact;
            Validacion val = new Validacion();
            string motivoinactivacion = "NO APLICA";

            string idCliente = SelectClienteBD(cedula);
            Console.WriteLine(idCliente);
            int idCli = val.ConvertirEntero(idCliente);
            Console.WriteLine(idCli);

            string idMembresia = SelectMembresiaBD(planMembresia);
            Console.WriteLine(idMembresia);
            int idMem = val.ConvertirEntero(idMembresia);
            Console.WriteLine(idMem);

            double precioFact;
            double descuentoFact;

            if (double.TryParse(preciofact, out precioFact))
            {
                if (string.IsNullOrEmpty(descuentofact) || double.TryParse(descuentofact, out descuentoFact) && descuentoFact <= 0)
                {
                    descuentofact = motivoinactivacion; // Asignar "NO APLICA" a descuentofact
                    fact = new Factura(numfactura, serie, preciofact, descuentofact, iva, CalcularTotal(precioFact, 0), motivoinactivacion, idCli, idMem);
                }
                else
                {
                    fact = new Factura(numfactura, serie, preciofact, descuentofact, iva, CalcularTotal(precioFact, descuentoFact), motivoinactivacion, idCli, idMem);
                }
            }
            else
            {
                msg = "Error: Valor de precio no válido";
                Log.Error(msg);
                return msg;
            }

            fact.Estadofact = "ACTIVO";
            fact.Motivoinactivacion = "NO APLICA";
          
            IngresarFacturaBD(fact);
            msg = fact.ToString() + Environment.NewLine + "---REGISTRO EXITOSO---" + Environment.NewLine;

            return msg;
        }

        /// <summary>
        /// Consulta el cliente en la base de datos mediante su cédula.
        /// </summary>
        /// <param name="cedulaCliente">La cédula del cliente a buscar.</param>
        /// <returns>El ID del cliente si se encuentra, o un mensaje de error si no se encuentra.</returns>
        public string SelectClienteBD(string cedulaCliente)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                try
                {
                    string idCliente = dtFactura.SelectCliente(conn.Connect, cedulaCliente);
                    if (!string.IsNullOrEmpty(idCliente))
                    {
                        msj = idCliente;
                    }
                    else
                    {
                        msj = "Cliente no encontrado.";
                        Console.WriteLine(msj);
                    }
                }
                catch (Exception ex)
                {
                    msj = "ERROR INESPERADO: " + ex.Message;
                    Log.Error(msj);
                    MessageBox.Show(msj);
                }
                finally
                {
                    conn.CerrarConexion();
                }
            }
            else if (msjBD[0] == '0')
            {
                msj = "ERROR: " + msjBD;
                Log.Error(msj);
                MessageBox.Show(msj);
            }

            return msj;
        }

        /// <summary>
        /// Consulta la membresía en la base de datos mediante el nombre del plan.
        /// </summary>
        /// <param name="planMembresia">El nombre del plan de membresía a buscar.</param>
        /// <returns>El ID de la membresía si se encuentra, o un mensaje de error si no se encuentra.</returns>
        public string SelectMembresiaBD(string planMembresia)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                try
                {
                    string idMembresia = dtFactura.SelectMembresia(conn.Connect, planMembresia);
                    if (!string.IsNullOrEmpty(idMembresia))
                    {
                        msj = idMembresia;
                    }
                    else
                    {
                        msj = "Membresia no encontrado.";
                        Console.WriteLine(msj);
                    }
                }
                catch (Exception ex)
                {
                    msj = "ERROR INESPERADO: " + ex.Message;
                    Log.Error(msj);
                    MessageBox.Show(msj);
                }
                finally
                {
                    conn.CerrarConexion();
                }
            }
            else if (msjBD[0] == '0')
            {
                msj = "ERROR: " + msjBD;
                Log.Error(msj);
                MessageBox.Show(msj);
            }

            return msj;
        }

        /// <summary>
        /// Ingresa una nueva factura en la base de datos.
        /// </summary>
        /// <param name="fact">El objeto <see cref="Factura"/> que contiene los datos de la factura a registrar.</param>
        public void IngresarFacturaBD(Factura fact)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtFactura.InsertFactura(fact, conn.Connect);
                if (msj[0] == '0')
                {
                    Log.Error("ERROR INESPERADO: " + msj);
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                }
            }
            else if (msjBD[0] == '0')
            {   
                Log.Error("ERROR: " + msjBD);
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }

        /// <summary>
        /// Llena un DataGridView con los registros de las facturas almacenadas en la lista de facturas.
        /// </summary>
        /// <param name="dgvRegistroFact">El <see cref="DataGridView"/> donde se mostrarán los registros de las facturas.</param>
        public void LlenarDataFact(DataGridView dgvRegistroFact)
        {
            int i;
            dgvRegistroFact.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

            foreach (Factura f in ListaFact)
            {
                i = dgvRegistroFact.Rows.Add();
                dgvRegistroFact.Rows[i].Cells["FacturaRegistroFact"].Value = f.Serie;                
                dgvRegistroFact.Rows[i].Cells["IvaDataFact"].Value = f.Iva;
                dgvRegistroFact.Rows[i].Cells["TotalDataFact"].Value = "$ " + f.Total;
                dgvRegistroFact.Rows[i].Cells["EstadoDataFact"].Value = f.Estadofact;
                dgvRegistroFact.Rows[i].Cells["MotivoDataFact"].Value = f.Motivoinactivacion;

                //LOS DATOS DE CLEITNE
                dgvRegistroFact.Rows[i].Cells["ClmCedulaCliente"].Value = f.Cliente?.Cedula ?? "N/A";
                dgvRegistroFact.Rows[i].Cells["ClmNombreCliente"].Value = f.Cliente?.Nombre ?? "N/A"; 
                dgvRegistroFact.Rows[i].Cells["ClmApellidoCliente"].Value = f.Cliente?.Apellido ?? "N/A"; 
                dgvRegistroFact.Rows[i].Cells["ClmTelefonoCliente"].Value = f.Cliente?.Telefono ?? "N/A";

                //LOS DATOS DE MEMBRESIA
                dgvRegistroFact.Rows[i].Cells["ClmPlanMembresia"].Value = f.Membresia?.Plan ?? "N/A";
                dgvRegistroFact.Rows[i].Cells["ClmPromocionMembresia"].Value = f.Membresia?.Promocion ?? "N/A";
                dgvRegistroFact.Rows[i].Cells["ClmDescuentoMembresia"].Value = f.Membresia != null ? f.Membresia.Descuento.ToString() + "%" : "N/A"; 
                dgvRegistroFact.Rows[i].Cells["ClmPrecioMembresia"].Value = f.Membresia != null ? "$ " + f.Membresia.Precio.ToString("F2") : "N/A";
                dgvRegistroFact.Rows[i].Cells["ClmFechaInicioMem"].Value = f.Membresia?.FechaInicio.ToString("d") ?? "N/A";
                dgvRegistroFact.Rows[i].Cells["ClmFechaFinMem"].Value = f.Membresia?.FechaFin.ToString("d") ?? "N/A";
            }
        }

        /// <summary>
        /// Realiza una búsqueda de las facturas en el DataGridView basado en un filtro específico, como nombre del cliente o precio de la factura.
        /// </summary>
        /// <param name="dgvRegistroFact">El <see cref="DataGridView"/> donde se mostrarán los resultados de la búsqueda.</param>
        /// <param name="filtro">El filtro de búsqueda (nombre del cliente o precio de la factura).</param>
        /// <param name="buscarPorNombreCliente">Indica si la búsqueda se realiza por nombre del cliente o por precio de la factura.</param>
        public void TablaConsultarNombreDescripcion(DataGridView dgvRegistroFact, string filtro = "", bool buscarPorNombreCliente = true)
        {
            int i;
            dgvRegistroFact.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

            foreach (Factura f in ListaFact)
            {

                if (string.IsNullOrEmpty(filtro) ||
                    (buscarPorNombreCliente && f.Cliente != null &&
                    (f.Cliente.Nombre.Contains(filtro) || f.Cliente.Apellido.Contains(filtro))) ||
                    (!buscarPorNombreCliente && f.Preciofact.ToString().Contains(filtro)))
                {
                    i = dgvRegistroFact.Rows.Add();
                    dgvRegistroFact.Rows[i].Cells["FacturaRegistroFact"].Value = f.Serie;                 
                    dgvRegistroFact.Rows[i].Cells["IvaDataFact"].Value = f.Iva;
                    dgvRegistroFact.Rows[i].Cells["TotalDataFact"].Value = f.Total;
                    dgvRegistroFact.Rows[i].Cells["EstadoDataFact"].Value = f.Estadofact;
                    dgvRegistroFact.Rows[i].Cells["MotivoDataFact"].Value = f.Motivoinactivacion;

                    //LOS DATOS DE CLIENTE
                    dgvRegistroFact.Rows[i].Cells["ClmCedulaCliente"].Value = f.Cliente?.Cedula ?? "N/A"; 
                    dgvRegistroFact.Rows[i].Cells["ClmNombreCliente"].Value = f.Cliente?.Nombre ?? "N/A"; 
                    dgvRegistroFact.Rows[i].Cells["ClmApellidoCliente"].Value = f.Cliente?.Apellido ?? "N/A"; 
                    dgvRegistroFact.Rows[i].Cells["ClmTelefonoCliente"].Value = f.Cliente?.Telefono ?? "N/A";

                    //LOS DATOS DE MEMBRESIA 
                    dgvRegistroFact.Rows[i].Cells["ClmPlanMembresia"].Value = f.Membresia?.Plan ?? "N/A";
                    dgvRegistroFact.Rows[i].Cells["ClmPromocionMembresia"].Value = f.Membresia?.Promocion ?? "N/A";
                    dgvRegistroFact.Rows[i].Cells["ClmDescuentoMembresia"].Value = f.Membresia != null ? f.Membresia.Descuento.ToString() + "%" : "N/A";
                    dgvRegistroFact.Rows[i].Cells["ClmPrecioMembresia"].Value = f.Membresia != null ? "$ " + f.Membresia.Precio.ToString("F2") : "N/A";
                    dgvRegistroFact.Rows[i].Cells["ClmFechaInicioMem"].Value = f.Membresia?.FechaInicio.ToString("d") ?? "N/A";
                    dgvRegistroFact.Rows[i].Cells["ClmFechaFinMem"].Value = f.Membresia?.FechaFin.ToString("d") ?? "N/A";
                }
            }
        }

        /// <summary>
        /// Actualiza el estado de la factura en la base de datos.
        /// </summary>
        /// <param name="fact">El objeto <see cref="Factura"/> que contiene la factura cuya estado debe ser actualizado.</param>
        public void EstadoFacturaBD(Factura fact)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtFactura.UpdateEstadoFactura(fact, conn.Connect);
                if (msj[0] == '0')
                {
                    Log.Error("ERROR INESPERADO: " + msj);
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                Log.Error("ERROR: " + msjBD);
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }

        /// <summary>
        /// Inactiva una factura específica cambiando su estado a "INACTIVO" y agregando un motivo de inactivación.
        /// </summary>
        /// <param name="serie">El número de serie de la factura a inactivar.</param>
        /// <param name="filaSeleccionada">La fila seleccionada en el DataGridView que contiene la factura.</param>
        /// <param name="dgvRegistroFact">El <see cref="DataGridView"/> donde se actualizarán los registros después de la inactivación.</param>
        public void InactivarFactura(string serie, DataGridViewRow filaSeleccionada, DataGridView dgvRegistroFact)
        {
            DialogResult resultado = MessageBox.Show("¿DESEA INACTIVAR LA FACTURA SELECCIONADA?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultado == DialogResult.Yes)
            {
                var factura = listaFact.FirstOrDefault(facto => facto.Serie == serie);
               
                if (factura != null)
                {
                    factura.estadofact = "INACTIVO"; //Pone el estado Inactivo a la factura

                    string motivoInactivacion = filaSeleccionada.Cells["MotivoDataFact"].Value.ToString();  // Agregar el motivo de inactivación
                    factura.motivoinactivacion = motivoInactivacion;

                    EstadoFacturaBD(factura);
                    LlenarDataFact(dgvRegistroFact);
                }
            }
        }

        /// <summary>
        /// Llena un DataGridView con los registros de las facturas filtradas por un rango de fechas y estado específico.
        /// </summary>
        /// <param name="dgvRegistroPrecio">El <see cref="DataGridView"/> donde se mostrarán los registros filtrados de las facturas.</param>
        /// <param name="dtInicioInforme">La fecha de inicio del rango para el informe.</param>
        /// <param name="dtFinInforme">La fecha de fin del rango para el informe.</param>
        /// <param name="estadoSeleccionado">El estado de las facturas a filtrar.</param>
        public void LlenarRegistroPrecioPorFecha(DataGridView dgvRegistroPrecio, DateTime dtInicioInforme, DateTime dtFinInforme, string estadoSeleccionado)
        {
            int i;
            dgvRegistroPrecio.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

            foreach (Factura f in ListaFact)
            {
                if (f.Membresia.FechaInicio >= dtInicioInforme && f.Membresia.FechaFin <= dtFinInforme && f.Estadofact == estadoSeleccionado) // Agregar condición para filtrar por fecha y estado
                {
                    if (string.IsNullOrEmpty(f.Descuentofact) || f.Descuentofact == "NO APLICA")  // Si el descuento es "NO APLICA"
                    {                     
                        i = dgvRegistroPrecio.Rows.Add();
                        dgvRegistroPrecio.Rows[i].Cells["clmNroFactRegistro"].Value = f.Serie;
                        dgvRegistroPrecio.Rows[i].Cells["clmPrecioFactRegistro"].Value = "$ " + f.Preciofact;
                        dgvRegistroPrecio.Rows[i].Cells["ClmDescuentoRegistro"].Value = "NO APLICA";
                        dgvRegistroPrecio.Rows[i].Cells["ClmIVARegistro"].Value = f.Iva;
                        dgvRegistroPrecio.Rows[i].Cells["ClmTotalRegistro"].Value = "$ " + f.Total;
                        dgvRegistroPrecio.Rows[i].Cells["ClmEstadoRegistro"].Value = f.Estadofact;
                        dgvRegistroPrecio.Rows[i].Cells["ClmMotivoRegistro"].Value = f.Motivoinactivacion;

                        //DATOS CLIENTE
                        dgvRegistroPrecio.Rows[i].Cells["ClmCedulaClienteRegistro"].Value = f.Cliente?.Cedula ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmNombreClienteRegistro"].Value = f.Cliente?.Nombre ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmApellidoClienteRegistro"].Value = f.Cliente?.Apellido ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmTelefonoClienteRegistro"].Value = f.Cliente?.Telefono ?? "N/A";

                        //DATOS MEMBRESIA
                        dgvRegistroPrecio.Rows[i].Cells["ClmPlanRegistro"].Value = f.Membresia?.Plan ?? "N/A";
                        dgvRegistroPrecio.Rows[i].Cells["ClmFechaInicioRegistro"].Value = f.Membresia?.FechaInicio.ToString("d") ?? "N/A";
                        dgvRegistroPrecio.Rows[i].Cells["ClmFechaFinRegistro"].Value = f.Membresia?.FechaFin.ToString("d") ?? "N/A";
                    }
                    else 
                    {
                        i = dgvRegistroPrecio.Rows.Add();
                        dgvRegistroPrecio.Rows[i].Cells["clmNroFactRegistro"].Value = f.Serie;
                        dgvRegistroPrecio.Rows[i].Cells["clmPrecioFactRegistro"].Value = "$ " + f.Preciofact;
                        dgvRegistroPrecio.Rows[i].Cells["ClmDescuentoRegistro"].Value = f.Descuentofact + "%";
                        dgvRegistroPrecio.Rows[i].Cells["ClmIVARegistro"].Value = f.Iva;
                        dgvRegistroPrecio.Rows[i].Cells["ClmTotalRegistro"].Value = "$ " + f.Total;
                        dgvRegistroPrecio.Rows[i].Cells["ClmEstadoRegistro"].Value = f.Estadofact;
                        dgvRegistroPrecio.Rows[i].Cells["ClmMotivoRegistro"].Value = f.Motivoinactivacion;

                        //DATOS CLIENTE
                        dgvRegistroPrecio.Rows[i].Cells["ClmCedulaClienteRegistro"].Value = f.Cliente?.Cedula ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmNombreClienteRegistro"].Value = f.Cliente?.Nombre ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmApellidoClienteRegistro"].Value = f.Cliente?.Apellido ?? "N/A"; 
                        dgvRegistroPrecio.Rows[i].Cells["ClmTelefonoClienteRegistro"].Value = f.Cliente?.Telefono ?? "N/A";

                        //DATOS MEMBRESIA
                        dgvRegistroPrecio.Rows[i].Cells["ClmPlanRegistro"].Value = f.Membresia?.Plan ?? "N/A";
                        dgvRegistroPrecio.Rows[i].Cells["ClmFechaInicioRegistro"].Value = f.Membresia?.FechaInicio.ToString("d") ?? "N/A";
                        dgvRegistroPrecio.Rows[i].Cells["ClmFechaFinRegistro"].Value = f.Membresia?.FechaFin.ToString("d") ?? "N/A";
                    }
                }
            }
        }

        /// <summary>
        /// Muestra el total de las facturas que están actualmente mostradas en el <see cref="DataGridView"/>.
        /// </summary>
        /// <param name="dgv">El <see cref="DataGridView"/> que contiene las facturas mostradas.</param>
        /// <param name="txtTotalFacturas">El <see cref="TextBox"/> donde se mostrará el total de las facturas.</param>
        public void MostrarTotalFacturas(DataGridView dgv, TextBox txtTotalFacturas)
        {
            int totalFacturas = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value != null) // Verifica si la primera celda de la fila no es nula
                {
                    totalFacturas++;
                }
            }

            txtTotalFacturas.Text = totalFacturas.ToString();
        }

        /// <summary>
        /// Muestra el total de las facturas con descuento y sin descuento en los respectivos TextBox.
        /// </summary>
        /// <param name="dgv">El <see cref="DataGridView"/> que contiene las facturas.</param>
        /// <param name="txtTotalConDescuento">El <see cref="TextBox"/> donde se mostrará el total de las facturas con descuento.</param>
        /// <param name="txtTotalSinDescuento">El <see cref="TextBox"/> donde se mostrará el total de las facturas sin descuento.</param>
        public void MostrarTotalFacturasConDescuento(DataGridView dgv, TextBox txtTotalConDescuento, TextBox txtTotalSinDescuento)
        {
            int totalFacturasConDescuento = 0;
            int totalFacturasSinDescuento = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row != null && row.Cells.Count > 0) // Verifica si la fila no es nula y tiene celdas
                {
                    string descuento = row.Cells["ClmDescuentoRegistro"].Value?.ToString();

                    if (descuento != null)
                    {
                        if (descuento.EndsWith("%")) // Verifica si el descuento termina con "%"
                        {
                            totalFacturasConDescuento++;
                        }
                        else
                        {
                            totalFacturasSinDescuento++;
                        }
                    }
                }
            }

            txtTotalConDescuento.Text = totalFacturasConDescuento.ToString();
            txtTotalSinDescuento.Text = totalFacturasSinDescuento.ToString();
        }

        /// <summary>
        /// Calcula el monto total de todas las facturas mostradas en el <see cref="DataGridView"/> y lo muestra en un TextBox.
        /// </summary>
        /// <param name="dgv">El <see cref="DataGridView"/> que contiene las facturas.</param>
        /// <param name="txtMontoTotal">El <see cref="TextBox"/> donde se mostrará el monto total calculado.</param>
        public void MostrarMontoTotalInforme(DataGridView dgv, TextBox txtMontoTotal)
        {
            decimal totalFacturas = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string total = row.Cells["ClmTotalRegistro"].Value?.ToString();

                if (total != null)
                {
                    // Elimina el símbolo "$" de la cadena
                    total = total.Replace("$", "");

                    // Intenta convertir la cadena a decimal
                    if (decimal.TryParse(total, out decimal totalValue))
                    {
                        totalFacturas += totalValue;
                    }
                }
            }

            txtMontoTotal.Text = "$ " + totalFacturas.ToString("N2");
        }

        /// <summary>
        /// Obtiene la lista de facturas desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Factura"/>.</returns>
        public List<Factura> GetListaFactura()
        {
            return TablaConsultarFacturaBD();
        }

        /// <summary>
        /// Abre el archivo PDF de las facturas si existe, o muestra un mensaje de error si no se encuentra el archivo.
        /// </summary>
        public void AbrirPDF()
        {
            if (File.Exists("REPORTE-PDF-FACTURAS.pdf")) // Verificar si el archivo PDF existe antes de intentar abrirlo
            {
                System.Diagnostics.Process.Start("REPORTE-PDF-FACTURAS.pdf"); // Abrir el archivo PDF con el visor de PDF predeterminado del sistema
            }
            else
            {
                MessageBox.Show("ARCHIVO PDF NO ENCONTRADO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera un archivo PDF con los detalles de las facturas almacenadas, incluyendo datos del cliente, membresía, y monto de la factura.
        /// </summary>
        public void GenerarPDF()
        {
            FileStream stream = null;
            Document document = null;
            string[] etiquetas = { "CEDULA", "NUMERO FACTURA", "APELLIDO", "NOMBRE", "PLAN", "FECHA INICIO", "FECHA FIN", "PRECIO", "IVA", "DESCUENTO", "TOTAL", "ESTADO" };
            int numCol = 12;
            List<Factura> facturas = GetListaFactura();

            try
            {
                // Crear documento PDF
                stream = new FileStream("REPORTE-PDF-FACTURAS.pdf", FileMode.Create);
                document = new Document(PageSize.A4.Rotate(), 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Crear fuentes
                iTextSharp.text.Font Miletra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font letra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.BLUE);

                // Agregar contenido al documento PDF
                document.Add(new Paragraph("CONSULTA DE FACTURAS DEL GIMNASIO GYMRAT."));
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(numCol);
                table.WidthPercentage = 100;

                //Ajustar tamaño de columnas
                float[] anchoColumnas = { 0.6f, 0.8f, 0.8f, 0.8f, 1f, 0.5f, 0.5f, 0.4f, 0.3f, 0.6f, 0.4f, 0.5f };
                table.SetWidths(anchoColumnas);
                PdfPCell[] columnaT = new PdfPCell[etiquetas.Length];

                for (int i = 0; i < etiquetas.Length; i++)
                {
                    columnaT[i] = new PdfPCell(new Phrase(etiquetas[i], Miletra));
                    columnaT[i].BorderWidth = 0;
                    columnaT[i].BorderWidthBottom = 0.25f;
                    table.AddCell(columnaT[i]);
                }

                foreach (Factura fact in facturas)
                {
                    columnaT[0] = new PdfPCell(new Phrase(fact.Cliente.Cedula, letra));
                    columnaT[0].BorderWidth = 0;

                    columnaT[1] = new PdfPCell(new Phrase(fact.Serie, letra));
                    columnaT[1].BorderWidth = 0;

                    columnaT[2] = new PdfPCell(new Phrase(fact.Cliente.Apellido, letra));
                    columnaT[2].BorderWidth = 0;

                    columnaT[3] = new PdfPCell(new Phrase(fact.Cliente.Nombre, letra));
                    columnaT[3].BorderWidth = 0;

                    columnaT[4] = new PdfPCell(new Phrase(fact.Membresia.Plan, letra));
                    columnaT[4].BorderWidth = 0;

                    columnaT[5] = new PdfPCell(new Phrase(fact.Membresia.FechaInicio.ToString("d"), letra));
                    columnaT[5].BorderWidth = 0;

                    columnaT[6] = new PdfPCell(new Phrase(fact.Membresia.FechaFin.ToString("d"), letra));
                    columnaT[6].BorderWidth = 0;

                    columnaT[7] = new PdfPCell(new Phrase("$ " + fact.Preciofact, letra));
                    columnaT[7].BorderWidth = 0;

                    columnaT[8] = new PdfPCell(new Phrase(fact.Iva, letra));
                    columnaT[8].BorderWidth = 0;

                    columnaT[9] = new PdfPCell(new Phrase(fact.Descuentofact + "%", letra));
                    columnaT[9].BorderWidth = 0;

                    columnaT[10] = new PdfPCell(new Phrase("$ " + fact.Total, letra));
                    columnaT[10].BorderWidth = 0;

                    columnaT[11] = new PdfPCell(new Phrase(fact.Estadofact, letra));
                    columnaT[11].BorderWidth = 0;
                    

                    table.AddCell(columnaT[0]);
                    table.AddCell(columnaT[1]);
                    table.AddCell(columnaT[2]);
                    table.AddCell(columnaT[3]);
                    table.AddCell(columnaT[4]);
                    table.AddCell(columnaT[5]);
                    table.AddCell(columnaT[6]);
                    table.AddCell(columnaT[7]);
                    table.AddCell(columnaT[8]);
                    table.AddCell(columnaT[9]);
                    table.AddCell(columnaT[10]);
                    table.AddCell(columnaT[11]);
                }

                document.Add(table);
                document.Close();
                pdf.Close();

                MessageBox.Show("PDF GENERADO EXITOSAMENTE.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {   
                Log.Error("ERROR AL GENERAR PDF: " + ex.Message);
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stream?.Close();
            }
        }

        /// <summary>
        /// Obtiene una lista de facturas basadas en el estado y el rango de fechas proporcionados.
        /// </summary>
        /// <param name="estado">El estado de la factura (ACTIVO o INACTIVO) para filtrar los resultados.</param>
        /// <param name="dtInicio">La fecha de inicio del rango para filtrar las facturas.</param>
        /// <param name="dtFin">La fecha de fin del rango para filtrar las facturas.</param>
        /// <returns>Una lista de facturas que cumplen con los criterios de estado y fechas.</returns>
        public List<Factura> GetListaInformeFactura(string estado, DateTime dtInicio, DateTime dtFin)
        {
            if (estado == "ACTIVO")
            {
                return TablaConsultarFacturaBD().Where(f => f.Estadofact == "ACTIVO" && f.Membresia.FechaInicio >= dtInicio && f.Membresia.FechaFin <= dtFin).ToList();
            }
            else if (estado == "INACTIVO")
            {
                return TablaConsultarFacturaBD().Where(f => f.Estadofact == "INACTIVO" && f.Membresia.FechaInicio >= dtInicio && f.Membresia.FechaFin <= dtFin).ToList();
            }
            else
            {
                return TablaConsultarFacturaBD().Where(f => f.Membresia.FechaInicio >= dtInicio && f.Membresia.FechaFin <= dtFin).ToList();
            }
        }

        /// <summary>
        /// Abre el archivo PDF generado previamente para el informe de facturas, si el archivo existe.
        /// </summary>
        public void AbrirInformePDF()
        {
            if (File.Exists("REPORTE-PDF-INFORME-FACTURAS.pdf")) // Verificar si el archivo PDF existe antes de intentar abrirlo
            {
                System.Diagnostics.Process.Start("REPORTE-PDF-INFORME-FACTURAS.pdf"); // Abrir el archivo PDF con el visor de PDF predeterminado del sistema
            }
            else
            {
                MessageBox.Show("ARCHIVO PDF NO ENCONTRADO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera un archivo PDF con un informe de facturas filtradas por estado y rango de fechas, incluyendo detalles del cliente, membresía, monto y motivo.
        /// </summary>
        /// <param name="estado">El estado de las facturas a incluir en el informe (ACTIVO o INACTIVO).</param>
        /// <param name="dtInicio">La fecha de inicio del rango de fechas para filtrar las facturas.</param>
        /// <param name="dtFin">La fecha de fin del rango de fechas para filtrar las facturas.</param>
        public void GenerarInformePDF(string estado, DateTime dtInicio, DateTime dtFin)
        {
            FileStream stream = null;
            Document document = null;
            string[] etiquetas = { "NÚMERO FACTURA", "CÉDULA", "APELLIDO", "NOMBRE", "PLAN", "FECHA INICIO", "FECHA FIN", "TELÉFONO", "IVA", "PRECIO", "DESCUENTO", "TOTAL", "ESTADO", "MOTIVO" };
            int numCol = 14;
            List<Factura> facturas = GetListaInformeFactura(estado, dtInicio, dtFin);

            try
            {
                // Crear documento PDF
                stream = new FileStream("REPORTE-PDF-INFORME-FACTURAS.pdf", FileMode.Create);
                document = new Document(PageSize.A4.Rotate(), 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Crear fuentes
                iTextSharp.text.Font Miletra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font letra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.BLUE);

                // Agregar contenido al documento PDF
                document.Add(new Paragraph("INFORME DE FACTURAS DEL GIMNASIO GYMRAT."));
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(numCol);
                table.WidthPercentage = 100;

                //Ajustar tamaño de columnas
                float[] anchoColumnas = { 1f, 0.7f, 0.8f, 0.8f, 0.7f, 0.6f, 0.6f, 0.6f, 0.4f, 0.5f, 0.6f, 0.5f, 0.6f, 0.8f };
                table.SetWidths(anchoColumnas);
                PdfPCell[] columnaT = new PdfPCell[etiquetas.Length];

                for (int i = 0; i < etiquetas.Length; i++)
                {
                    columnaT[i] = new PdfPCell(new Phrase(etiquetas[i], Miletra));
                    columnaT[i].BorderWidth = 0;
                    columnaT[i].BorderWidthBottom = 0.25f;
                    table.AddCell(columnaT[i]);
                }

                foreach (Factura fact in facturas)
                {
                    columnaT[0] = new PdfPCell(new Phrase(fact.Serie, letra));
                    columnaT[0].BorderWidth = 0;

                    columnaT[1] = new PdfPCell(new Phrase(fact.Cliente.Cedula, letra));
                    columnaT[1].BorderWidth = 0;

                    columnaT[2] = new PdfPCell(new Phrase(fact.Cliente.Apellido, letra));
                    columnaT[2].BorderWidth = 0;

                    columnaT[3] = new PdfPCell(new Phrase(fact.Cliente.Nombre, letra));
                    columnaT[3].BorderWidth = 0;

                    columnaT[4] = new PdfPCell(new Phrase(fact.Membresia.Plan, letra));
                    columnaT[4].BorderWidth = 0;

                    columnaT[5] = new PdfPCell(new Phrase(fact.Membresia.FechaInicio.ToString("d"), letra));
                    columnaT[5].BorderWidth = 0;

                    columnaT[6] = new PdfPCell(new Phrase(fact.Membresia.FechaFin.ToString("d"), letra));
                    columnaT[6].BorderWidth = 0;

                    columnaT[7] = new PdfPCell(new Phrase(fact.Cliente.Telefono, letra));
                    columnaT[7].BorderWidth = 0;

                    columnaT[8] = new PdfPCell(new Phrase(fact.Iva, letra));
                    columnaT[8].BorderWidth = 0;

                    columnaT[9] = new PdfPCell(new Phrase("$ " + fact.Preciofact, letra));
                    columnaT[9].BorderWidth = 0;                  

                    columnaT[10] = new PdfPCell(new Phrase(fact.Descuentofact + "%", letra));
                    columnaT[10].BorderWidth = 0;

                    columnaT[11] = new PdfPCell(new Phrase("$ " + fact.Total, letra));
                    columnaT[11].BorderWidth = 0;

                    columnaT[12] = new PdfPCell(new Phrase(fact.Estadofact, letra));
                    columnaT[12].BorderWidth = 0;

                    columnaT[13] = new PdfPCell(new Phrase(fact.Motivoinactivacion, letra));
                    columnaT[13].BorderWidth = 0;


                    table.AddCell(columnaT[0]);
                    table.AddCell(columnaT[1]);
                    table.AddCell(columnaT[2]);
                    table.AddCell(columnaT[3]);
                    table.AddCell(columnaT[4]);
                    table.AddCell(columnaT[5]);
                    table.AddCell(columnaT[6]);
                    table.AddCell(columnaT[7]);
                    table.AddCell(columnaT[8]);
                    table.AddCell(columnaT[9]);
                    table.AddCell(columnaT[10]);
                    table.AddCell(columnaT[11]);
                    table.AddCell(columnaT[12]);
                    table.AddCell(columnaT[13]);
                }

                document.Add(table);
                document.Close();
                pdf.Close();

                MessageBox.Show("PDF GENERADO EXITOSAMENTE.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error("ERROR AL GENERAR PDF: " + ex.Message);
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stream?.Close();
            }
        }

    }
}
