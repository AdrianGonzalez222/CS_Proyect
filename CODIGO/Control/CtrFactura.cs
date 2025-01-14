using Dato;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Control
{
    public class CtrFactura
    {
        Conexion conn = new Conexion();
        DatoFactura dtFactura = new DatoFactura();


        public static List<Factura> listaFact = new List<Factura>();
        private static List<Membresia> listaMembresia = new List<Membresia>();
        public static List<Factura> ListaFact { get => listaFact; set => listaFact = value; }
        public static List<Membresia> ListaMembresia { get => listaMembresia; set => listaMembresia = value; }


        //Lista quemada
        //public CtrFactura()
        //{
        //    if (ListaFact.Count == 0)
        //    {
        //        ListaFact.Add(new Factura(1, "JKSD23FJ3D52K9 ", "144", "20%", "0.15", "136.80"));
        //        ListaFact.Add(new Factura(2, "JKDI43JYWHG3FG", "556", "24%", "0.15", "505.06"));
        //        ListaFact.Add(new Factura(3, "34TEOI0D07KGG7", "700", "13%", "0.15", "714"));
        //    }
        //}


        //Mostrar tabla BD
        public int GetTotal()
        {
            ListaFact = TablaConsultarFacturaBD(); // BASE DE DATOS
            return ListaFact.Count;
        }


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
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
            return facturas;
        }




        //Calcular el total de los precios activos
        public float CalcularSumaPrecios()
        {
            float sumaPrecios = 0;
            foreach (Factura f in ListaFact)
            {
                if (f.Estadofact == "ACTIVO")
                {
                    sumaPrecios += float.Parse(f.Preciofact);
                }
            }
            return sumaPrecios;
        }


        //Generar código de la factura
        public string GenerarFactura()
        {
            return generarCodigoUnico();
        }

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


        //Método para calcular datos ingresados
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




        //Guardar datos
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
                return msg;
            }

            fact.Estadofact = "ACTIVO";
            fact.Motivoinactivacion = "NO APLICA";

            //listaFact.Add(fact);            
            IngresarFacturaBD(fact);
            msg = fact.ToString() + Environment.NewLine + "---REGISTRO EXITOSO---" + Environment.NewLine;

            return msg;
        }


        //PARA CLIENTE
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
                MessageBox.Show(msj);
            }

            return msj;
        }



        //PARA MEMBRESIA
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
                MessageBox.Show(msj);
            }

            return msj;
        }




        //Ingresar-Guardar en el BD
        public void IngresarFacturaBD(Factura fact)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtFactura.InsertFactura(fact, conn.Connect);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }




        //LLenar la tabla
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

                //dgvRegistroFact
                //dgvRegistroFact
            }
        }



        //BUSCAR POR NOMBRE O APELLDIO
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



        //Eliminar factura seleccionando fila
        //public void EliminarFactura(DataGridView dgvRegistroFact)
        //{
        //    if (dgvRegistroFact.SelectedRows.Count > 0)
        //    {
        //        int filaSelecc = dgvRegistroFact.SelectedRows[0].Index; // OBTIENE INDICE DE FILA SELECCIONADA
        //        if (filaSelecc >= 0)
        //        {
        //            string cl = dgvRegistroFact.Rows[filaSelecc].Cells["FacturaRegistroFact"].Value.ToString(); // OBTIENE NUMERO DE LA ACTIVIDAD
        //            Factura factura = ListaFact.FirstOrDefault(f => f.Serie == cl);

        //            if (factura != null)
        //            {
        //                DialogResult result = MessageBox.Show("ESTA SEGURO DE BORRAR LA FACTURA SELECCIONADA?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //                if (result == DialogResult.Yes)
        //                {
        //                    ListaFact.Remove(factura); // <--- Actualiza la tabla y ya no muestra lo borrado
        //                    dgvRegistroFact.Rows.RemoveAt(filaSelecc);
        //                    MessageBox.Show("BORRADO EXITOSO.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}



        public void EstadoFacturaBD(Factura fact)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtFactura.UpdateEstadoFactura(fact, conn.Connect);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }




        //INACTIVAR FACTURA
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




        //RE-ACTIVAR FACTURA
        public void ActivarFactura(string serie, DataGridViewRow filaSeleccionada, DataGridView dgvRegistroFact)
        {
            var factura = listaFact.FirstOrDefault(facto => facto.Serie == serie);
            if (factura != null)
            {
                if (factura.estadofact == "ACTIVO")
                {
                    MessageBox.Show("LA FACTURA YA ESTÁ ACTIVA.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (factura.estadofact == "INACTIVO")
                {
                    factura.estadofact = "ACTIVO"; //Pone el estado Activo a la factura                   
                    factura.motivoinactivacion = "NO APLICA";
                    EstadoFacturaBD(factura);
                    LlenarDataFact(dgvRegistroFact);
                    MessageBox.Show("LA FACTURA AHORA ESTÁ ACTIVA.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        //
        //INFORME
        //
        //LLENAR EL INFORME DE PRECIO
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



        //MOSTRAR EL TOTAL DE FACTURAS MOSTRADAS
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


        //MOSTRAR EL TOTAL DE LAS FACTURAS CON Y SIN DESCUENTO
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


        //CALCULAR MONTO TOTAL DE TODAS LAS FACTURAS DE INFORME
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



        //public void LlenarRegistroPrecio(DataGridView dgvRegistroPrecio, string estadoSeleccionado)
        //{
        //    int i;
        //    dgvRegistroPrecio.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

        //    foreach (Factura f in ListaFact)
        //    {
        //        if (f.Estadofact == estadoSeleccionado) // Agregar condición para filtrar por estado
        //        {
        //            i = dgvRegistroPrecio.Rows.Add();
        //            dgvRegistroPrecio.Rows[i].Cells["clmNroFactRegistro"].Value = f.Serie;
        //            dgvRegistroPrecio.Rows[i].Cells["clmPrecioFactRegistro"].Value = "$ " + f.Preciofact;
        //            dgvRegistroPrecio.Rows[i].Cells["ClmDescuentoRegistro"].Value = f.Descuentofact + "%";
        //            dgvRegistroPrecio.Rows[i].Cells["ClmIVARegistro"].Value = f.Iva;
        //            dgvRegistroPrecio.Rows[i].Cells["ClmTotalRegistro"].Value = "$ " + f.Total;
        //            dgvRegistroPrecio.Rows[i].Cells["ClmEstadoRegistro"].Value = f.Estadofact;
        //            dgvRegistroPrecio.Rows[i].Cells["ClmMotivoRegistro"].Value = f.Motivoinactivacion;

        //            //DATOS CLIENTE
        //            dgvRegistroPrecio.Rows[i].Cells["ClmCedulaClienteRegistro"].Value = f.Cliente?.Cedula ?? "N/A"; // Cedula del cliente
        //            dgvRegistroPrecio.Rows[i].Cells["ClmNombreClienteRegistro"].Value = f.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
        //            dgvRegistroPrecio.Rows[i].Cells["ClmApellidoClienteRegistro"].Value = f.Cliente?.Apellido ?? "N/A"; // Apellido del cliente
        //            dgvRegistroPrecio.Rows[i].Cells["ClmTelefonoClienteRegistro"].Value = f.Cliente?.Telefono ?? "N/A";

        //            //DATOS MEMBRESIA
        //            dgvRegistroPrecio.Rows[i].Cells["ClmPlanRegistro"].Value = f.Membresia?.Plan ?? "N/A";
        //            dgvRegistroPrecio.Rows[i].Cells["ClmFechaInicioRegistro"].Value = f.Membresia?.FechaInicio.ToString("d") ?? "N/A";
        //            dgvRegistroPrecio.Rows[i].Cells["ClmFechaFinRegistro"].Value = f.Membresia?.FechaFin.ToString("d") ?? "N/A";

        //        }
        //    }
        //}


        ////MUESTRA EL TOTAL DE FACTURAS ACTIVAS O INACTIVAS
        //public void MostrarTotalFacturas(string estadoSeleccionado, TextBox txtTotalFacturas)
        //{
        //    int totalFacturas = 0;

        //    foreach (Factura f in ListaFact)
        //    {
        //        if (f.Estadofact == estadoSeleccionado)
        //        {
        //            totalFacturas++;
        //        }
        //    }

        //    txtTotalFacturas.Text = totalFacturas.ToString();
        //}



        //// CONTAR CUANTAS FACTURAS CON Y SIN DESCUENTO HAY
        //public void MostrarTotalFacturasConDescuento(string estadoSeleccionado, TextBox txtTotalConDescuento, TextBox txtTotalSinDescuento)
        //{
        //    int totalFacturasConDescuento = 0;
        //    int totalFacturasSinDescuento = 0;

        //    foreach (Factura f in ListaFact)
        //    {
        //        if (f.Estadofact == estadoSeleccionado)
        //        {
        //            if (int.TryParse(f.Descuentofact, out int descuento))
        //            {
        //                if (descuento > 0)
        //                {
        //                    totalFacturasConDescuento++;
        //                }
        //                else
        //                {
        //                    totalFacturasSinDescuento++; // Si el descuento es 0, incrementa el contador de facturas sin descuento
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrWhiteSpace(f.Descuentofact) || f.Descuentofact.ToUpper() == "NO APLICA")
        //                {
        //                    totalFacturasSinDescuento++; // Si el string es vacío o contiene solo espacios en blanco, incrementa el contador de facturas sin descuento
        //                }
        //            }
        //        }
        //    }

        //    txtTotalConDescuento.Text = totalFacturasConDescuento.ToString();
        //    txtTotalSinDescuento.Text = totalFacturasSinDescuento.ToString();
        //}


        ////MUESTRA EL MONTO TOTAL DE TODAS LAS FACTURAS ACTIVAS O INACTIVAS
        //public void MostrarMontoTotalInforme(string estadoSeleccionado, TextBox txtMontoTotal)
        //{
        //    decimal totalFacturas = 0; // Cambia el tipo de variable a decimal para admitir decimales

        //    foreach (Factura f in ListaFact)
        //    {
        //        if (f.Estadofact == estadoSeleccionado)
        //        {
        //            if (decimal.TryParse(f.Total, out decimal total))
        //            {
        //                totalFacturas += total;
        //            }
        //        }
        //    }

        //    txtMontoTotal.Text = totalFacturas.ToString("C"); // Muestra el valor con símbolo de moneda y decimales
        //}






        //
        // PDF
        //
        //Creación del PDF de factura normal
        public List<Factura> GetListaFactura()
        {
            return TablaConsultarFacturaBD();
        }


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
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stream?.Close();
            }
        }





        //CREACION DE PDF PARA INFORME
        //GENERAR PDF DE INFORME
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
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stream?.Close();
            }
        }
    }
}

