﻿using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dato;
using Modelo;
using Serilog;

namespace Control
{
    /// <summary>
    /// Clase controlador que contiene todos los métodos de la entidad Cliente.
    /// </summary>
    public class CtrCliente
    {
        private static List<Cliente> listaCli = new List<Cliente>();
        private Conexion conn = new Conexion();
        private DatoCliente dtCliente = new DatoCliente();

        public static List<Cliente> ListaCli { get => listaCli; set => listaCli = value; }

        /// <summary>
        /// Obtiene el total de clientes almacenados en la lista.
        /// </summary>
        /// <returns>El número total de clientes.</returns>
        public int GetTotal()
        {
            ListaCli = ConsultarTablaCliBD();
            return listaCli.Count;
        }

        /// <summary>
        /// Ingresa un nuevo cliente en el sistema con los datos proporcionados.
        /// </summary>
        /// <param name="rCedula">Cédula del cliente.</param>
        /// <param name="rNombre">Nombre del cliente.</param>
        /// <param name="rApellido">Apellido del cliente.</param>
        /// <param name="rFechaNacimiento">Fecha de nacimiento del cliente.</param>
        /// <param name="rTelefono">Teléfono del cliente.</param>
        /// <param name="rEstado">Estado del cliente (activo/inactivo).</param>
        /// <param name="rDireccion">Dirección del cliente.</param>
        /// <returns>Mensaje de éxito o error del proceso de registro.</returns>
        public string IngresarCli(string rCedula, string rNombre, string rApellido,string rFechaNacimiento, string rTelefono, string rEstado, string rDireccion)
        {           
            String msg = "ERROR: SE ESPERABA DATOS CORRECTOS!!";
            Validacion v = new Validacion();
            DateTime hoy = DateTime.Now;
            Cliente cli = null;
            DateTime fechaNac = v.ConvertirDateTime(rFechaNacimiento);

            cli = new Cliente(rCedula, rNombre, rApellido, fechaNac, rTelefono, rDireccion, rEstado);
            IngresarClienteBD(cli);
            msg = cli.ToString() + "\n CLIENTE REGISTRADO EXITOSAMENTE!!";

            return msg;
        }

        /// <summary>
        /// Ingresa un nuevo cliente tipo estudiante en el sistema con los datos proporcionados.
        /// </summary>
        /// <param name="rCedula">Cédula del cliente.</param>
        /// <param name="rNombre">Nombre del cliente.</param>
        /// <param name="rApellido">Apellido del cliente.</param>
        /// <param name="rFechaNacimiento">Fecha de nacimiento del cliente.</param>
        /// <param name="rTelefono">Teléfono del cliente.</param>
        /// <param name="rEstado">Estado del cliente (activo/inactivo).</param>
        /// <param name="rDireccion">Dirección del cliente.</param>
        /// <param name="comprobante">Comprobante del estudiante.</param>
        /// <returns>Mensaje de éxito o error del proceso de registro.</returns>
        public string IngresarCliEst( string rCedula, string rNombre, string rApellido, string rFechaNacimiento, string rTelefono,string rEstado, string rDireccion, string comprobante)
        {
            String msg = "ERROR: SE ESPERABA DATOS CORRECTOS11";
            Validacion v = new Validacion();
            DateTime hoy = DateTime.Now;
            DateTime fechaNac = v.ConvertirDateTime(rFechaNacimiento);
            Cliente cli = null;

            cli = new ClienteEstudiante(rCedula, rNombre, rApellido, fechaNac, rTelefono, rDireccion, rEstado, comprobante);
            IngresarClienteBD(cli);
            msg = cli.ToString() + "\n CLIENTE ESTUDIANTE REGISTRADO EXITOSAMENTE11";

            return msg;
        }

        /// <summary>
        /// Inserta un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">Cliente a insertar.</param>
        public void IngresarClienteBD(Cliente cliente)
        {
            string msg = string.Empty;
            string msgBD = conn.AbrirConexion();

            if (msgBD[0] == '1')
            {
                msg = dtCliente.InsertarCliente(cliente, conn.Connect);
                if (msg[0] == '0')
                {
                    Log.Error("ERROR INESPERADO: " + msg);
                    MessageBox.Show("ERROR INESPERADO: " + msg);
                }               
            }
            else if (msgBD[0] == '0')
            {
                Log.Error("ERROR: " + msgBD);
                MessageBox.Show("ERROR: " + msgBD);
            }
            conn.CerrarConexion();
        }

        /// <summary>
        /// Verifica si un cliente ya existe en la lista de clientes.
        /// </summary>
        /// <param name="cedula">Cédula del cliente a verificar.</param>
        /// <returns>Devuelve true si el cliente existe, false en caso contrario.</returns>
        public bool ClienteExistente(string cedula)
        {
            foreach(Cliente cli in ListaCli)
            {
                if(cli.Cedula == cedula)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Consulta la base de datos y devuelve una lista de clientes.
        /// </summary>
        /// <returns>Lista de objetos Cliente obtenidos de la base de datos.</returns>
        public List<Cliente> ConsultarTablaCliBD()
        {
            List<Cliente> clientes = new List<Cliente>();
            string msgBD = conn.AbrirConexion();

            if (msgBD[0] == '1')
            {
                clientes = dtCliente.SeleccionarCliente(conn.Connect);
            }
            else if (msgBD[0] == '0')
            {
                Log.Error("ERROR: " + msgBD);
                MessageBox.Show("ERROR: " + msgBD);
            }

            conn.CerrarConexion();
            return clientes;
        }

        /// <summary>
        /// Llenar el control DataGridView con los datos de la lista de clientes.
        /// </summary>
        /// <param name="dgvClientes">DataGridView donde se mostrarán los clientes.</param>
        public void LlenarGrid(DataGridView dgvClientes)
        {
            int i = 0;
            dgvClientes.Rows.Clear(); // Limpiar filas si las hay 
            foreach (Cliente x in ListaCli )
            {
                i = dgvClientes.Rows.Add();
                dgvClientes.Rows[i].Cells["clmEstado"].Value = x.Estado;
                dgvClientes.Rows[i].Cells["clmCedula"].Value = x.Cedula;
                dgvClientes.Rows[i].Cells["clmNombre"].Value = x.Nombre;
                dgvClientes.Rows[i].Cells["clmApellido"].Value = x.Apellido;
                dgvClientes.Rows[i].Cells["clmTelefono"].Value = x.Telefono;
                dgvClientes.Rows[i].Cells["clmDireccion"].Value = x.Direccion;
                dgvClientes.Rows[i].Cells["clmDate"].Value = x.FechaNacimiento.ToString("d");

                if (x is ClienteEstudiante clienteEstudiante)
                {
                    dgvClientes.Rows[i].Cells["clmComprobanteEst"].Value = clienteEstudiante.Comprobante;
                }
                else
                {
                    dgvClientes.Rows[i].Cells["clmComprobanteEst"].Value = ObtenerComprobanteActualizado(x.Cedula);
                }
            }
        }

        /// <summary>
        /// Obtiene el comprobante actualizado de un cliente, si es estudiante.
        /// </summary>
        /// <param name="cedula">Cédula del cliente a consultar.</param>
        /// <returns>El comprobante del cliente o un mensaje indicando que no tiene comprobante.</returns>
        public string ObtenerComprobanteActualizado(string cedula)
        {
            foreach (Cliente cliente in ListaCli)
            {
                if (cliente.Cedula == cedula)
                {
                    if (cliente is ClienteEstudiante clienteEstudiante)
                    {
                        return string.IsNullOrEmpty(clienteEstudiante.Comprobante) ? "SIN COMPROBANTE" : clienteEstudiante.Comprobante;
                    }
                }
            }

            return "SIN COMPROBANTE";
        }

        /// <summary>
        /// Edita los datos de un cliente existente en la base de datos y en la lista.
        /// </summary>
        /// <param name="aCedulaOrg">Cédula original del cliente para buscarlo en la lista.</param>
        /// <param name="aCedula">Nueva cédula del cliente.</param>
        /// <param name="aNombre">Nuevo nombre del cliente.</param>
        /// <param name="aApellido">Nuevo apellido del cliente.</param>
        /// <param name="aFechaNacimiento">Nueva fecha de nacimiento del cliente.</param>
        /// <param name="aTelefono">Nuevo teléfono del cliente.</param>
        /// <param name="aDireccion">Nueva dirección del cliente.</param>
        /// <param name="aEstado">Nuevo estado del cliente (activo/inactivo).</param>
        /// <param name="esEstudiante">Indica si el cliente es estudiante.</param>
        /// <param name="aComprobante">Comprobante del cliente, si es estudiante.</param>
        /// <returns>Mensaje indicando el resultado de la edición.</returns>
        public string EditarCliente(string aCedulaOrg, string aCedula, string aNombre, string aApellido, string aFechaNacimiento, string aTelefono, string aDireccion, string aEstado, bool esEstudiante, string aComprobante = null)
        {
            string msg = "ERROR: SE ESPERABA DATOS CORRECTOS!!";
            Validacion v = new Validacion();
            DateTime fechaNac = v.ConvertirDateTime(aFechaNacimiento);
            DateTime fechaActual = DateTime.Now;

            // Validaciones
            if (string.IsNullOrEmpty(aCedula) || string.IsNullOrEmpty(aNombre) || string.IsNullOrEmpty(aApellido) ||
                string.IsNullOrEmpty(aFechaNacimiento) || string.IsNullOrEmpty(aTelefono) || string.IsNullOrEmpty(aDireccion))
            {
                Log.Warning("NO PUEDEN EXISTIR CAMPOS VACIOS.");
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else if (fechaNac >= fechaActual)
            {
                Log.Warning("FECHA DE NACIMIENTO NO PUEDE SER IGUAL O MAYOR A LA FECHA ACTUAL.");
                return "ERROR: INGRESE FECHA DE NACIMIENTO VALIDA.";
            }

            Cliente clienteExistente = ListaCli.Find(c => c.Cedula == aCedulaOrg);
            if (clienteExistente == null)
            {
                Log.Warning("NO SE ENCONTRÓ EL CLIENTE A EDITAR.");
                return "ERROR: NO SE ENCONTRÓ EL CLIENTE.";
            }

            // Validar si ya existe otro cliente con la misma cédula
            if (ListaCli.Any(cli => cli.Cedula == aCedula && cli.Cedula != aCedulaOrg))
            {
                Log.Warning("YA EXISTE UN CLIENTE CON ESA CEDULA.");
                return "ERROR: YA EXISTE UN CLIENTE CON ESA CEDULA.";
            }

            // Actualiza los datos del cliente
            clienteExistente.Cedula = aCedula;
            clienteExistente.Nombre = aNombre;
            clienteExistente.Apellido = aApellido;
            clienteExistente.FechaNacimiento = fechaNac;
            clienteExistente.Telefono = aTelefono;
            clienteExistente.Direccion = aDireccion;
            clienteExistente.Estado = aEstado;

            // Manejo de cliente estudiante
            if (esEstudiante)
            {
                if (clienteExistente is ClienteEstudiante cliEst)
                {
                    cliEst.Comprobante = aComprobante;
                }
                else
                {
                    ClienteEstudiante nuevoClienteEstudiante = new ClienteEstudiante(aCedula, aNombre, aApellido, fechaNac, aTelefono, aDireccion, aEstado, aComprobante);
                    int index = ListaCli.IndexOf(clienteExistente);
                    ListaCli[index] = nuevoClienteEstudiante;
                    clienteExistente = nuevoClienteEstudiante; // Actualiza clienteExistente para la actualización en la BD
                }
            }
            else
            {
                if (clienteExistente is ClienteEstudiante)
                {
                    Cliente nuevoCliente = new Cliente(aCedula, aNombre, aApellido, fechaNac, aTelefono, aDireccion, aEstado);
                    int index = ListaCli.IndexOf(clienteExistente);
                    ListaCli[index] = nuevoCliente;
                    clienteExistente = nuevoCliente; // Actualiza clienteExistente para la actualización en la BD
                }
            }

            try
            {
                EditarCliBD(clienteExistente, aCedulaOrg); // Actualiza la base de datos
                msg = "CLIENTE EDITADO CORRECTAMENTE";
                Log.Information("CLIENTE EDITADO CORRECTAMENTE: {clienteExistente}", clienteExistente);
            }
            catch (Exception ex)
            {
                msg = "ERROR INESPERADO AL EDITAR CLIENTE.";
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }

            return msg;
        }

        /// <summary>
        /// Actualiza los datos de un cliente en la base de datos.
        /// </summary>
        /// <param name="cli">El objeto Cliente con los datos actualizados.</param>
        /// <param name="CedulaOrg">La cédula original del cliente que se desea actualizar.</param>
        public void EditarCliBD(Cliente cli, string CedulaOrg)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtCliente.UpdateCliente(cli, conn.Connect, CedulaOrg);
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
        /// Realiza una búsqueda de clientes en la lista filtrando por cédula o nombre.
        /// </summary>
        /// <param name="dgvClientes">DataGridView donde se mostrarán los resultados.</param>
        /// <param name="filtroPorCedula">Cédula del cliente para filtrar.</param>
        /// <param name="filtroPorNombre">Nombre del cliente para filtrar.</param>
        public void BuscarCliente(DataGridView dgvClientes, string filtroPorCedula = "", string filtroPorNombre = "")
        {
            if (string.IsNullOrEmpty(filtroPorCedula) && string.IsNullOrEmpty(filtroPorNombre))
            {
                MessageBox.Show("ERROR: DEBE INGRESAR AL MENOS UN CAMPO PARA LA BÚSQUEDA (CÉDULA O NOMBRE).", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i = 0;
            dgvClientes.Rows.Clear(); // Limpiar filas si las hay 

            foreach (Cliente x in ListaCli)
            {
                bool coincideCedula = string.IsNullOrEmpty(filtroPorCedula) || x.Cedula.IndexOf(filtroPorCedula, StringComparison.OrdinalIgnoreCase) >= 0;
                bool coincideNombre = string.IsNullOrEmpty(filtroPorNombre) || x.Nombre.IndexOf(filtroPorNombre, StringComparison.OrdinalIgnoreCase) >= 0;

                if (coincideCedula && coincideNombre)
                {
                    i = dgvClientes.Rows.Add();
                    dgvClientes.Rows[i].Cells["clmEstado"].Value = x.Estado;
                    dgvClientes.Rows[i].Cells["clmCedula"].Value = x.Cedula;
                    dgvClientes.Rows[i].Cells["clmNombre"].Value = x.Nombre;
                    dgvClientes.Rows[i].Cells["clmApellido"].Value = x.Apellido;
                    dgvClientes.Rows[i].Cells["clmTelefono"].Value = x.Telefono;
                    dgvClientes.Rows[i].Cells["clmDireccion"].Value = x.Direccion;
                    dgvClientes.Rows[i].Cells["clmDate"].Value = x.FechaNacimiento.ToString("d");

                    if (x is ClienteEstudiante clienteEstudiante)
                    {
                        dgvClientes.Rows[i].Cells["clmComprobanteEst"].Value = clienteEstudiante.Comprobante;
                    }
                    else
                    {
                        dgvClientes.Rows[i].Cells["clmComprobanteEst"].Value = ObtenerComprobanteActualizado(x.Cedula); ;
                    }
                }
            }

            if (dgvClientes.Rows.Count == 0)
            {
                MessageBox.Show("ERROR: NO SE ENCONTRARON RESULTADOS CON LOS FILTROS PROPORCIONADOS.", "SIN RESULTADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Inactiva un cliente cambiando su estado a "INACTIVO" y actualiza en la base de datos.
        /// </summary>
        /// <param name="cedula">Cédula del cliente a inactivar.</param>
        /// <param name="dgvCliente">DataGridView donde se muestra la lista de clientes.</param>
        public void InactivarCliente(string cedula, DataGridView dgvCliente)
        {
            DialogResult resultado = MessageBox.Show("¿DESEA INACTIVAR A ESTE CLIENTE?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultado == DialogResult.Yes)
            {
                var cliente = ListaCli.FirstOrDefault(cli => cli.Cedula == cedula);

                if (cliente != null)
                {
                    cliente.Estado = "INACTIVO";
                    EstadoClienteBD(cliente);
                }
            }
        }

        /// <summary>
        /// Inactiva un cliente cambiando su estado a "ACTIVO" y actualiza en la base de datos.
        /// </summary>
        /// <param name="cedula">Cédula del cliente a reactivar.</param>
        /// <param name="dgvCliente">DataGridView donde se muestra la lista de clientes.</param>
        public void ReactivarCliente(string cedula, DataGridView dgvCliente)
        {
            DialogResult resultado = MessageBox.Show("¿DESEA REACTIVAR A ESTE CLIENTE?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                var cliente = ListaCli.FirstOrDefault(cli => cli.Cedula == cedula);

                if (cliente != null)
                {
                    cliente.Estado = "ACTIVO";
                    EstadoClienteBD(cliente);
                }
            }
        }

        /// <summary>
        /// Actualiza el estado de un cliente a "INACTIVO" en la base de datos.
        /// </summary>
        /// <param name="cli">El objeto Cliente cuyo estado se actualizará.</param>
        public void EstadoClienteBD(Cliente cli)
        {
            string msg = string.Empty;
            string msgBD = conn.AbrirConexion();

            if (msgBD[0] == '1')
            {
                msg = dtCliente.UpdateEstadoCliente(cli, conn.Connect);
                if (msg[0] == '0')
                {
                    Log.Error("ERROR INESPERADO: " + msg);
                    MessageBox.Show("ERROR INESPERADO: " + msg);
                }
            }
            else if (msgBD[0] == '0')
            {
                Log.Error("ERROR: " + msgBD);
                MessageBox.Show("ERROR: " + msgBD);
            }

            conn.CerrarConexion();
        }

        /// <summary>
        /// Muestra los datos de un cliente en los controles correspondientes de un formulario.
        /// </summary>
        /// <param name="cedulaCliente">Cédula del cliente cuyo dato se desea mostrar.</param>
        /// <param name="txtCedula">Campo de texto para mostrar la cédula del cliente.</param>
        /// <param name="txtNombre">Campo de texto para mostrar el nombre del cliente.</param>
        /// <param name="txtApellido">Campo de texto para mostrar el apellido del cliente.</param>
        /// <param name="dtpDate">Campo de fecha para mostrar la fecha de nacimiento del cliente.</param>
        /// <param name="txtTelefono">Campo de texto para mostrar el teléfono del cliente.</param>
        /// <param name="txtDireccion">Campo de texto para mostrar la dirección del cliente.</param>
        /// <param name="txtComprobante">Campo de texto para mostrar el comprobante (si es estudiante).</param>
        /// <param name="cmbEstado">ComboBox para mostrar el estado del cliente (activo/inactivo).</param>
        /// <param name="cmbEstudiante">ComboBox para indicar si el cliente es estudiante o no.</param>
        public void MostrarDatosCliente(string cedulaCliente, TextBox txtCedula, TextBox txtNombre, TextBox txtApellido, DateTimePicker dtpDate, TextBox txtTelefono, TextBox txtDireccion, TextBox txtComprobante, ComboBox cmbEstado, ComboBox cmbEstudiante)
        {
            Cliente clienteSeleccionado = ConseguirDatosGrid(cedulaCliente);

            if(clienteSeleccionado != null) 
            {
                txtCedula.Text = clienteSeleccionado.Cedula;
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                dtpDate.Value = clienteSeleccionado.FechaNacimiento;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                txtDireccion.Text = clienteSeleccionado.Direccion;
                cmbEstado.SelectedItem = clienteSeleccionado.Estado;

                if (clienteSeleccionado is ClienteEstudiante clienteEstudiante)
                {
                    txtComprobante.Text = clienteEstudiante.Comprobante;
                    cmbEstudiante.SelectedItem = "SI";                    
                }
                else
                {
                    txtComprobante.Text = ObtenerComprobanteActualizado(clienteSeleccionado.Cedula);
                    cmbEstudiante.SelectedItem = "NO";
                }
            }
        }

        /// <summary>
        /// Busca un cliente en la lista utilizando su cédula.
        /// </summary>
        /// <param name="cedulaCliente">Cédula del cliente a buscar.</param>
        /// <returns>El cliente encontrado o null si no se encuentra.</returns>
        public Cliente ConseguirDatosGrid(string cedulaCliente)
        {
            return ListaCli.Find(cli => cli.Cedula == cedulaCliente);
        }

        /// <summary>
        /// Abre el archivo PDF de reporte de clientes.
        /// </summary>
        public void AbrirPDF()
        {
            if (File.Exists("reporteCliente.pdf"))
            {
                System.Diagnostics.Process.Start("reporteCliente.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera un archivo PDF con los datos de los clientes registrados.
        /// </summary>
        /// <param name="dgvEstudiantes">DataGridView con los datos de los estudiantes.</param>
        public void GenerarPDF(DataGridView dgvEstudiantes)
        {
            FileStream stream = null;
            Document document = null;

            try
            {
                stream = new FileStream("ReporteCliente.pdf", FileMode.Create);
                document = new Document(PageSize.A4, 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                iTextSharp.text.Font titulo = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font contenido = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLUE);

                document.Add(new Paragraph("REPORTE DE CLIENTES REGISTRADOS DEL GYMNASIO GYMRAT"));
                document.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(dgvEstudiantes.ColumnCount);
                tabla.WidthPercentage = 100;

                foreach (DataGridViewColumn column in dgvEstudiantes.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, titulo));
                    cell.BorderWidth = 1;
                    cell.BorderWidthBottom = 0.25f;
                    tabla.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgvEstudiantes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            tabla.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString(), contenido)));
                        }
                    }
                }

                document.Add(tabla);
                document.Close();
                pdf.Close();
                MessageBox.Show("Documento PDF Generado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Log.Error("ERROR AL GENERAR PDF: {ex}", ex);
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                stream?.Close();
            }
        }

    }   
}
