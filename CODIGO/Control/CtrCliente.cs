using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dato;
using Microsoft.Win32.SafeHandles;
using Modelo;
namespace Control
{
    public class CtrCliente
    {
        private static List<Cliente> listaCli = new List<Cliente>();
        private Conexion conn = new Conexion();
        private DatoCliente dtCliente = new DatoCliente();

        public static List<Cliente> ListaCli { get => listaCli; set => listaCli = value; }
        

        public int GetTotal()
        {
            ListaCli = ConsultarTablaCliBD();
            return listaCli.Count;
        }


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

        public void IngresarClienteBD(Cliente cliente)
        {
            string msg = string.Empty;
            string msgBD = conn.AbrirConexion();
            if (msgBD[0] == '1')
            {
                msg = dtCliente.InsertarCliente(cliente, conn.Connect);
                if (msg[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msg);
                }
                
            }
            else if (msgBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msgBD);
            }
            conn.CerrarConexion();
        }

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
                MessageBox.Show("ERROR: " + msgBD);
            }
            conn.CerrarConexion();
            return clientes;
        }

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

        public string EditarCliente(string aCedulaOrg, string aCedula, string aNombre, string aApellido, string aFechaNacimiento, string aTelefono, string aDireccion, string aEstado, bool esEstudiante, string aComprobante = null)
        {
            string msg = "ERROR: SE ESPERABA DATOS CORRECTOS!!";
            Validacion v = new Validacion();
            DateTime fechaNac = v.ConvertirDateTime(aFechaNacimiento);
            DateTime fechaLimite = new DateTime(2014, 12, 31); // Fecha límite: 1 de enero de 2014
            DateTime fechaActual = DateTime.Now;

            // Validaciones
            if (string.IsNullOrEmpty(aCedula) || string.IsNullOrEmpty(aNombre) || string.IsNullOrEmpty(aApellido) ||
                string.IsNullOrEmpty(aFechaNacimiento) || string.IsNullOrEmpty(aTelefono) || string.IsNullOrEmpty(aDireccion))
            {
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS";
            }
            else if (fechaNac >= fechaActual)
            {
                return "ERROR: INGRESE FECHA DE NACIMIENTO VALIDA";
            }
            else if (fechaNac >= fechaLimite)
            {
                return "ERROR: LA FECHA DE NACIMIENTO INVALIDA";
            }

            Cliente clienteExistente = ListaCli.FirstOrDefault(c => c.Cedula == aCedulaOrg);
            if (clienteExistente == null)
            {
                return "ERROR: NO SE ENCONTRO EL CLIENTE";
            }

            if (ListaCli.Any(cli => cli.Cedula == aCedula && cli.Cedula != aCedulaOrg))
            {
                return "ERROR: YA EXISTE UN CLIENTE CON ESA CEDULA.";
            }

            clienteExistente.Cedula = aCedula;
            clienteExistente.Nombre = aNombre;
            clienteExistente.Apellido = aApellido;
            clienteExistente.FechaNacimiento = fechaNac;
            clienteExistente.Telefono = aTelefono;
            clienteExistente.Direccion = aDireccion;
            clienteExistente.Estado = aEstado;

            // Manejo de tipo y comprobante
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

            EditarCliBD(clienteExistente, aCedulaOrg);
            return "CLIENTE EDITADO CORRECTAMENTE";
        }

        //public string EditarCli(string aCedulaOrg, string aCedula, string aNombre, string aApellido, string aFechaNacimiento, string aTelefono, string aDireccion, string aEstado)
        //{
        //    string msg = "ERROR: SE ESPERABA DATOS CORRECTOS!!";
        //    Validacion v = new Validacion();
        //    DateTime fechaNac = v.ConvertirDateTime(aFechaNacimiento);
        //    DateTime fechaLimite = new DateTime(2014, 12, 31); // Fecha límite: 1 de enero de 2014
        //    DateTime fechaActual = DateTime.Now;

        //    // Validaciones
        //    if (string.IsNullOrEmpty(aCedula) || string.IsNullOrEmpty(aNombre) || string.IsNullOrEmpty(aApellido) ||
        //        string.IsNullOrEmpty(aFechaNacimiento) || string.IsNullOrEmpty(aTelefono) || string.IsNullOrEmpty(aDireccion))
        //    {
        //        return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS";
        //    }
        //    else if (fechaNac >= fechaActual)
        //    {
        //        return "ERROR: INGRESE FECHA DE NACIIENTO VALIDA";
        //    }
        //    else if (fechaNac >= fechaLimite)
        //    {
        //        return "ERROR: LA FECHA DE NACIMIENTO INVALIDA";
        //    }

        //    foreach (Cliente clienteExistente in ListaCli)
        //    {
        //        if (clienteExistente.Cedula == aCedulaOrg)
        //        {
        //            if (clienteExistente.Cedula != aCedula)
        //            {
        //                if (ListaCli.Any(cli => cli.Cedula == aCedula))
        //                {
        //                    return "ERROR: YA EXISTE UN CLIENTE CON ESA CEDULA.";
        //                }
        //                clienteExistente.Cedula = aCedula;
        //            }
        //            clienteExistente.Nombre = aNombre;
        //            clienteExistente.Apellido = aApellido;
        //            clienteExistente.FechaNacimiento = fechaNac;
        //            clienteExistente.Telefono = aTelefono;
        //            clienteExistente.Direccion = aDireccion;
        //            clienteExistente.Estado = aEstado;

        //            EditarCliBD(clienteExistente, aCedulaOrg);
        //            msg = "CLIENTE EDITADO CORRECTAMENTE";
        //            break;
        //        }
        //    }

        //    if (msg == "ERROR: SE ESPERABA DATOS CORRECTOS!!")
        //    {
        //        msg = "ERROR: NO SE ENCONTRO EL CLIENTE";
        //    }

        //    return msg;
        //}

        public void EditarCliBD(Cliente cli, string CedulaOrg)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtCliente.UpdateCliente(cli, conn.Connect, CedulaOrg);
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


        public void InactivarCliente(string cedula, DataGridView dgvCliente)
        {
                DialogResult resultado = MessageBox.Show("¿DESEA INACTIVAR A ESTE CLIENTE?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(resultado == DialogResult.Yes)
                {
                    var cliente = ListaCli.FirstOrDefault(cli => cli.Cedula == cedula);
                    if (cliente != null)
                    {
                        cliente.Estado = "INACTIVO";
                        InactivarClienteBD(cliente);
                    }
            }
        }

        public void InactivarClienteBD(Cliente cli)
        {
            string msg = string.Empty;
            string msgBD = conn.AbrirConexion();

            if (msgBD[0] == '1')
            {
                msg = dtCliente.UpdateEstadoCliente(cli, conn.Connect);
                if (msg[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msg);
                }
            }
            else if (msgBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msgBD);
            }
            conn.CerrarConexion();
        }

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
        public Cliente ConseguirDatosGrid(string cedulaCliente)
        {
            return ListaCli.Find(cli => cli.Cedula == cedulaCliente);
        }



        //
        //CONTROL PDF
        //

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
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                stream?.Close();
            }
        }


    }   
}
