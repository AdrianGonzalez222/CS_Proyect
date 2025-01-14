using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Windows.Forms;
using Dato;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Control
{
    public class CtrMembresia
    {
        Conexion conn = new Conexion();
        DatoMembresia dtMembresia = new DatoMembresia();

        CtrCliente ctrCliente = new CtrCliente();
        private DateTime fechaActual = DateTime.Now;
        private static List<Membresia> listaMembresia = new List<Membresia>();
        private static List<Membresia> listaMembresiaInactivos = new List<Membresia>();
        private static List<Cliente> listaCli = new List<Cliente>();

        public static List<Membresia> ListaMembresia { get => listaMembresia; set => listaMembresia = value; }
        public DateTime FechaActual { get => fechaActual; set => fechaActual = value; }
        public static List<Cliente> ListaCli { get => listaCli; set => listaCli = value; }
        public static List<Membresia> ListaMembresiaInactivos { get => listaMembresiaInactivos; set => listaMembresiaInactivos = value; }


        //public int GetTotal()
        //{
        //    return ListaMembresia.Count;
        //}

        //public CtrMembresia()
        //{
        //    if (ListaMembresia.Count == 0)
        //    {
        //        ListaMembresia.Add(new Membresia("Plan Basico", new DateTime(2021, 1, 1), new DateTime(2021, 12, 31), "NO", 0, "No aplica", "123456789", 100));
        //        ListaMembresia.Add(new Membresia("Plan Premium", new DateTime(2021, 1, 1), new DateTime(2021, 12, 31), "SI", 10, "Promoción estudiante", "987654321", 200));
        //        ListaMembresia.Add(new Membresia("Plan Premium #1", new DateTime(2021, 1, 1), new DateTime(2021, 12, 31), "SI", 20, "Promocion Gym Bro", "123456789", 300));
        //        ListaMembresia.Add(new Membresia("Plan Basico #2", new DateTime(2021, 1, 1), new DateTime(2021, 12, 31), "NO", 0, "No aplica", "987654321", 100));

        //    }
        //}
        public string IngresarMembresia(string plan, string SFInicio, string SFFin, string promocion, string Sdescuento, string detallePromocion, string cedulaCliente, string Sprecio)
        {
            string msj = "ERROR: SE ESPERABA DATOS CORRECTOS.";
            Validacion val = new Validacion();
            Membresia mem = null;
            //CtrMembresia controlMembresia = new CtrMembresia(CtrCliente.ListaCli);
            double precio = val.ConvertirDouble(Sprecio);
            int descuento = val.ConvertirEntero(Sdescuento);
            if (descuento == -1)
            {
                descuento = 0;
            }
            if (detallePromocion.Equals("") || string.IsNullOrEmpty(detallePromocion))
            {
                detallePromocion = "No aplica";
            }

            DateTime fechaInicio = val.ConvertirDateTime(SFInicio);
            DateTime fechaFin = val.ConvertirDateTime(SFFin);

            string idCliente = SelectClienteBD(cedulaCliente);
            Console.WriteLine(idCliente);
            int idCli = val.ConvertirEntero(idCliente);
            Console.WriteLine(idCli);

            if (string.IsNullOrEmpty(plan) || plan.Equals(""))
            {
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else if (fechaInicio.Date == fechaFin.Date)
            {
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
                return "ERROR: FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.";
            }
            else if (MembresiaExistente(idCliente) == true)
            {
                return "ERROR: MEMBRESIA YA REGISTRADA.";
            }
            else if (promocion != "SI" && promocion != "NO")
            {
                return "ERROR: DEBE SELECCIONAR UNA OPCIÓN VÁLIDA PARA PROMOCIÓN (SI O NO).";
            }
            else if (string.IsNullOrEmpty(Sprecio) || precio <= 0)
            {
                return "ERROR: EL PRECIO NO PUEDE ESTAR VACÍO O SER CERO.";
            }
            else if (string.IsNullOrEmpty(plan) || plan.Equals(""))
            {
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else 
            {
                mem = new Membresia(plan, fechaInicio, fechaFin, promocion, detallePromocion, descuento, precio, idCli);
                //ListaMembresia.Add(mem);
                IngresarMembresiaBD(mem);
                msj = mem.ToString() + Environment.NewLine + "MEMBRESIA REGISTRADA CORRECTAMENTE" + Environment.NewLine;
            }
            return msj;
        }
        public void IngresarMembresiaBD(Membresia mem)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtMembresia.InsertMembresia(mem, conn.Connect);
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

        //
        // CONSULTAR LIST - BD
        //
        public int GetTotal()
        {
            ListaMembresia = TablaConsultarMembresiaBD(1); // BASE DE DATOS
            return ListaMembresia.Count;
        }

        public int GetTotalInactivas()
        {
            ListaMembresiaInactivos = TablaConsultarMembresiaBD(2); // BASE DE DATOS
            return ListaMembresiaInactivos.Count(mem => mem.Estado == 2);
        }
        public List<Membresia> GetListaMembresia()
        {
            return TablaConsultarMembresiaBD(1);
        }


        public List<Membresia> TablaConsultarMembresiaBD(int estado)
        {
            List<Membresia> membresias = new List<Membresia>();
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                membresias = dtMembresia.SelectMembresias(conn.Connect, estado);
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
            return membresias;
        }
 
        public bool MembresiaExistente(string idCliente)
        {
            bool existe = false;
            string cedulaCons = SelectCedulaClienteBD(idCliente);
            Console.WriteLine(cedulaCons);
            if (cedulaCons != "Cliente no encontrado.")
            {
                existe=true;
            }
            return existe;
        }


        public string SelectClienteBD(string cedulaCliente)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                try
                {
                    string idCliente = dtMembresia.SelectCliente(conn.Connect, cedulaCliente);
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

        public string SelectCedulaClienteBD(string idCliente)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                try
                {
                    string cedula = dtMembresia.SelectCedulaCliente(conn.Connect, idCliente);
                    if (!string.IsNullOrEmpty(cedula))
                    {
                        msj = cedula;
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

        //public void ExtraerDatosTablaMembresia(DataGridView dgvClientes, out string cedula)
        //{
        //    DataGridViewRow filaSeleccionada = dgvClientes.SelectedRows[0]; 
        //    cedula = filaSeleccionada.Cells["ClmCedula"].Value.ToString();
        //}

        public void LlenarGrid(DataGridView dgvMembresia)
        {
            int i = 0;
            // Limpiar filas si las hay 
            dgvMembresia.Rows.Clear();

            // Iterar sobre la lista de membresías
            foreach (Membresia x in ListaMembresia)
            {
                if (x.Estado == 1)
                {
                    i = dgvMembresia.Rows.Add();
                    dgvMembresia.Rows[i].Cells["clmPREM"].Value = x.Precio.ToString() + "$";
                    //dgvMembresia.Rows[i].Cells["clmCedula"].Value = x.CedulaCliente;
                    dgvMembresia.Rows[i].Cells["clmPM"].Value = x.Plan;
                    dgvMembresia.Rows[i].Cells["clmFIM"].Value = x.FechaInicio.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmFFM"].Value = x.FechaFin.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmP"].Value = x.Promocion;
                    dgvMembresia.Rows[i].Cells["clmDPM"].Value = x.DetallePromocion;
                    dgvMembresia.Rows[i].Cells["clmDM"].Value = x.Descuento.ToString() + "%";

                    dgvMembresia.Rows[i].Cells["clmCedulaCliente"].Value = x.Cliente?.Cedula ?? "N/A"; // Cedula del cliente
                    dgvMembresia.Rows[i].Cells["clmNombreCliente"].Value = x.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
                    dgvMembresia.Rows[i].Cells["clmApellidoCliente"].Value = x.Cliente?.Apellido ?? "N/A"; // Apellido del cliente

                }
            }
        }

        public void LlenarGridInactivos(DataGridView dgvMembresia)
        {
            int i = 0;
            // Limpiar filas si las hay 
            dgvMembresia.Rows.Clear();

            // Iterar sobre la lista de membresías
            foreach (Membresia x in ListaMembresiaInactivos)
            {
                if (x.Estado == 2)
                {
                    i = dgvMembresia.Rows.Add();
                    dgvMembresia.Rows[i].Cells["clmPREM"].Value = x.Precio.ToString() + "$";
                    //dgvMembresia.Rows[i].Cells["clmCedula"].Value = x.CedulaCliente;
                    dgvMembresia.Rows[i].Cells["clmPM"].Value = x.Plan;
                    dgvMembresia.Rows[i].Cells["clmFIM"].Value = x.FechaInicio.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmFFM"].Value = x.FechaFin.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmP"].Value = x.Promocion;
                    dgvMembresia.Rows[i].Cells["clmDPM"].Value = x.DetallePromocion;
                    dgvMembresia.Rows[i].Cells["clmDM"].Value = x.Descuento.ToString() + "%";

                    dgvMembresia.Rows[i].Cells["clmCedulaCliente"].Value = x.Cliente?.Cedula ?? "N/A"; // Cedula del cliente
                    dgvMembresia.Rows[i].Cells["clmNombreCliente"].Value = x.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
                    dgvMembresia.Rows[i].Cells["clmApellidoCliente"].Value = x.Cliente?.Apellido ?? "N/A"; // Apellido del cliente

                }
            }
        }
        public void TablaConsultarMembresiaPapelera(DataGridView dgvMembresia)
        {
            int i = 0;
            dgvMembresia.Rows.Clear(); // LIMPIA FILAS SI LAS HAY
            //TablaConsultarActividadBD(2); // BASE DE DATOS

            foreach (Membresia x in ListaMembresia)
            {
                if (x.Estado == 2)
                {
                    i = dgvMembresia.Rows.Add();
                    dgvMembresia.Rows[i].Cells["clmPREM"].Value = x.Precio.ToString() + "$";
                    //dgvMembresia.Rows[i].Cells["clmCedula"].Value = x.CedulaCliente;
                    dgvMembresia.Rows[i].Cells["clmPM"].Value = x.Plan;
                    dgvMembresia.Rows[i].Cells["clmFIM"].Value = x.FechaInicio.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmFFM"].Value = x.FechaFin.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmP"].Value = x.Promocion;
                    dgvMembresia.Rows[i].Cells["clmDPM"].Value = x.DetallePromocion;
                    dgvMembresia.Rows[i].Cells["clmDM"].Value = x.Descuento.ToString() + "%";

                    dgvMembresia.Rows[i].Cells["clmCedulaCliente"].Value = x.Cliente?.Cedula ?? "N/A"; // Cedula del cliente
                    dgvMembresia.Rows[i].Cells["clmNombreCliente"].Value = x.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
                    dgvMembresia.Rows[i].Cells["clmApellidoCliente"].Value = x.Cliente?.Apellido ?? "N/A"; // Apellido del cliente

                }
            }
        }

        public void TablaConsultarMebresiaFiltro(DataGridView dgvMembresia, string filtro = "", bool buscarPorCedula = true)
        {
            int i = 0;
            dgvMembresia.Rows.Clear(); // LIMPIA FILAS SI LAS HAY
            foreach (Membresia x in ListaMembresia)
            {
                if (x.Estado == 1 &&
                    (string.IsNullOrEmpty(filtro) ||
                    (buscarPorCedula && x.Cliente?.Cedula.Contains(filtro) == true) ||
                    (!buscarPorCedula && x.Plan.Contains(filtro))))
                {
                    i = dgvMembresia.Rows.Add();
                    dgvMembresia.Rows[i].Cells["clmPREM"].Value = x.Precio.ToString() + "$";
                    dgvMembresia.Rows[i].Cells["clmCedulaCliente"].Value = x.Cliente?.Cedula ?? "N/A";
                    dgvMembresia.Rows[i].Cells["clmPM"].Value = x.Plan;
                    dgvMembresia.Rows[i].Cells["clmFIM"].Value = x.FechaInicio.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmFFM"].Value = x.FechaFin.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmP"].Value = x.Promocion;
                    dgvMembresia.Rows[i].Cells["clmDPM"].Value = x.DetallePromocion;
                    dgvMembresia.Rows[i].Cells["clmDM"].Value = x.Descuento.ToString()+ "%";
                    dgvMembresia.Rows[i].Cells["clmNombreCliente"].Value = x.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
                    dgvMembresia.Rows[i].Cells["clmApellidoCliente"].Value = x.Cliente?.Apellido ?? "N/A"; // Apellido del cliente
                }
            }
        }

        public void TablaConsultarMembresiaFiltroPapelera(DataGridView dgvMembresia, string filtro = "", bool buscarPorCedula = true)
        {
            int i = 0;
            dgvMembresia.Rows.Clear(); // LIMPIA FILAS SI LAS HAY
            foreach (Membresia x in ListaMembresia)
            {
                if (x.Estado == 2 &&
                    (string.IsNullOrEmpty(filtro) ||
                    (buscarPorCedula && x.Cliente?.Cedula.Contains(filtro) == true) ||
                    (!buscarPorCedula && x.Plan.Contains(filtro))))
                {
                    i = dgvMembresia.Rows.Add();
                    dgvMembresia.Rows[i].Cells["clmPREM"].Value = x.Precio.ToString() + "$";
                    dgvMembresia.Rows[i].Cells["clmCedulaCliente"].Value = x.Cliente?.Cedula ?? "N/A";
                    dgvMembresia.Rows[i].Cells["clmPM"].Value = x.Plan;
                    dgvMembresia.Rows[i].Cells["clmFIM"].Value = x.FechaInicio.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmFFM"].Value = x.FechaFin.ToString("d");
                    dgvMembresia.Rows[i].Cells["clmP"].Value = x.Promocion;
                    dgvMembresia.Rows[i].Cells["clmDPM"].Value = x.DetallePromocion;
                    dgvMembresia.Rows[i].Cells["clmDM"].Value = x.Descuento.ToString() + "%";
                    dgvMembresia.Rows[i].Cells["clmNombreCliente"].Value = x.Cliente?.Nombre ?? "N/A"; // Nombre del cliente
                    dgvMembresia.Rows[i].Cells["clmApellidoCliente"].Value = x.Cliente?.Apellido ?? "N/A"; // Apellido del cliente
                }
            }
        }

        public string editarMembresia(string nombrePlan, string planE, string SFInicioE, string SFFinE, string promocionE, string SdescuentoE, string detallePromocionE, string SprecioE)
        {
            string msj = "ERROR: SE ESPERABA DATOS CORRECTOS.";
            Validacion val = new Validacion();
            //Membresia mem = null;
            double precio = val.ConvertirDouble(SprecioE);
            int descuento = val.ConvertirEntero(SdescuentoE);
            DateTime fechaInicio = val.ConvertirDateTime(SFInicioE);
            DateTime fechaFin = val.ConvertirDateTime(SFFinE);

            if (string.IsNullOrEmpty(planE) || planE.Equals(""))
            {
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else if (fechaInicio.Date == fechaFin.Date)
            {
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
                return "ERROR: FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.";
            }
            else if (promocionE != "SI" && promocionE != "NO")
            {
                return "ERROR: DEBE SELECCIONAR UNA OPCIÓN VÁLIDA PARA PROMOCIÓN (SI O NO).";
            }
            else if (string.IsNullOrEmpty(SprecioE) || precio <= 0)
            {
                return "ERROR: EL PRECIO NO PUEDE ESTAR VACÍO O SER CERO.";
            }
            else
            {
                Membresia membresiaExistente = ListaMembresia.Find(atv => atv.Plan == nombrePlan); // BUSCAR NOMBRE ORIGINAL EN LISTA
                if (membresiaExistente != null)
                {
                    if (membresiaExistente.Plan != planE) // SI NOMBRE ORIGINAL Y NUEVO SON DIFERENTES
                    {
                        if (ListaMembresia.Any(atv => atv.Plan == planE)) // BUSCAR SI NOMBRE NUEVO YA EXISTE
                        {
                            return "ERROR: YA EXISTE UNA MEMBRESIA CON EL NUEVO NOMBRE.";
                        }
                        membresiaExistente.Plan = planE; // ASIGNAR NOMBRE NUEVO
                    }

                    // ACTUALIZA DATOS 
                    membresiaExistente.FechaInicio = fechaInicio;
                    membresiaExistente.FechaFin = fechaFin;
                    membresiaExistente.Promocion = promocionE;
                    membresiaExistente.DetallePromocion = detallePromocionE;
                    membresiaExistente.Descuento = descuento;
                    membresiaExistente.Precio = precio;

                    EditarMembresiaBD(membresiaExistente, nombrePlan); // BASE DE DATOS
                    msj = "MEMBRESIA EDITADA CORRECTAMENTE" + Environment.NewLine + membresiaExistente.ToString();
                }
                else
                {
                    msj = "ERROR: NO SE PUDO ENCONTRAR LA MEMBRESIA A EDITAR.";
                }
            }
            return msj;
        }

        public void EditarMembresiaBD(Membresia mem, string nombrePlan)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtMembresia.UpdateCamposMembresia(mem, conn.Connect, nombrePlan);
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
        public void PresentarDatosMembresia(TextBox txtBoxME, DateTimePicker dateTPFIE, DateTimePicker dateTPFFE, ComboBox comboBoxPE, TextBox txtBoxDPE, TextBox txtBoxDE, TextBox txtBoxPEM, Label lblCedulaM, string nombrePlan)
        {
            Membresia membresiaSeleccionada = ListaMembresia.Find(a => a.Plan == nombrePlan);
            if (membresiaSeleccionada != null)
            {
                txtBoxME.Text = membresiaSeleccionada.Plan;
                dateTPFIE.Value = membresiaSeleccionada.FechaInicio;
                dateTPFIE.Value = membresiaSeleccionada.FechaFin;
                comboBoxPE.Text = membresiaSeleccionada.Promocion;
                txtBoxDPE.Text = membresiaSeleccionada.DetallePromocion;
                txtBoxDE.Text = membresiaSeleccionada.Descuento.ToString();
                txtBoxPEM.Text = membresiaSeleccionada.Precio.ToString();
                lblCedulaM.Text = membresiaSeleccionada.Cliente?.Cedula ?? "N/A";
            }
        }
        public void InactivarMembresia(DataGridView dgvMembresia)
        {
            if (dgvMembresia.SelectedRows.Count > 0)
            {
                int filaSeleccionada = dgvMembresia.SelectedRows[0].Index; 

                if (filaSeleccionada >= 0)
                {
                    string planMembresia = dgvMembresia.Rows[filaSeleccionada].Cells["ClmPM"].Value.ToString(); 
                    Membresia membresia = ListaMembresia.FirstOrDefault(a => a.Plan == planMembresia); 

                    if (membresia != null)
                    {
                        DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE INACTIVAR ESTA ACTIVIDAD?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            membresia.Estado = 2; // ESTADO 2 = INACTIVO
                            EstadoMembresiaBD(membresia); // BASE DE DATOS
                            LlenarGrid(dgvMembresia);
                            MessageBox.Show("ACTIVIDAD INACTIVADA EXITOSAMENTE." + Environment.NewLine + membresia.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE INACTIVAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RestaurarMembresia(DataGridView dgvMembresia)
        {
            if (dgvMembresia.SelectedRows.Count > 0)
            {
                int filaSeleccionada = dgvMembresia.SelectedRows[0].Index; // OBTIENE EL ÍNDICE DE LA FILA SELECCIONADA

                if (filaSeleccionada >= 0)
                {
                    string planMembresia = dgvMembresia.Rows[filaSeleccionada].Cells["ClmPM"].Value.ToString(); // OBTIENE EL NOMBRE DE LA ACTIVIDAD DE LA FILA SELECCIONADA
                    Membresia membresia = ListaMembresiaInactivos.FirstOrDefault(a => a.Plan == planMembresia);// BUSCA ACTIVIDAD EN LISTA POR NOMBRE

                    if (membresia != null)
                    {
                        DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE RESTAURAR ESTA MEMBRESIA?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            membresia.Estado = 1; // CAMBIA EL ESTADO A ACTIVO
                            EstadoMembresiaBD(membresia); // BASE DE DATOS
                            MessageBox.Show("MEMBRESIA RESTAURADA EXITOSAMENTE." + Environment.NewLine + membresia.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetTotalInactivas();
                            LlenarGridInactivos(dgvMembresia);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE RESTAURAR UNA MEMBRESIA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EstadoMembresiaBD(Membresia mem)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtMembresia.UpdateEstadoMembresia(mem, conn.Connect);
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
        //public void eliminarMembresia(DataGridView dgvMembresia)
        //{
        //    if (dgvMembresia.SelectedRows.Count > 0)
        //    {
        //        int filaSeleccionada = dgvMembresia.SelectedRows[0].Index; // OBTIENE EL ÍNDICE DE LA FILA SELECCIONADA
        //        if (filaSeleccionada >= 0)
        //        {
        //            string nombrePlan = dgvMembresia.Rows[filaSeleccionada].Cells["clmPM"].Value.ToString(); 
        //            Membresia membresia = ListaMembresia.FirstOrDefault(a => a.Plan == nombrePlan); 

        //            if (membresia != null)
        //            {
        //                DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE ELIMINAR PERMANENTEMENTE ESTA MEMBRESIA?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //                if (resultado == DialogResult.Yes)
        //                {
        //                    //ListaMembresia.Remove(membresia);
        //                    RemoverMembresiaBD(membresia);
        //                    dgvMembresia.Rows.RemoveAt(filaSeleccionada);
        //                    LlenarGrid(dgvMembresia);
        //                    MessageBox.Show("MEMBRESIA ELIMINADA CORRECTAMENTE." + Environment.NewLine + membresia.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR DE FORMA PERMANENTE UNA MEMBRESIA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //public void RemoverMembresiaBD(Membresia mem)
        //{
        //    string msj = string.Empty;
        //    string msjBD = conn.AbrirConexion();

        //    if (msjBD[0] == '1')
        //    {
        //        msj = dtMembresia.DeleteMembresia(mem, conn.Connect);
        //        if (msj[0] == '0')
        //        {
        //            MessageBox.Show("ERROR INESPERADO: " + msj);
        //        }
        //    }
        //    else if (msjBD[0] == '0')
        //    {
        //        MessageBox.Show("ERROR: " + msjBD);
        //    }
        //    conn.CerrarConexion();
        //}

        public void MostrarDatosClienteMem(string cedulaCliente, Label lblCedulaM, Label lblNombreM, Label lblApellidoM, Label lblEstudianteM, Label celularInvisible, Label comprobanteInvisible, Label fechaNacInvisible, Label direccionInvisible)
        {
            Cliente clienteSeleccionado = ctrCliente.ConseguirDatosGrid(cedulaCliente);
            if (clienteSeleccionado != null)
            {
                lblCedulaM.Text = clienteSeleccionado.Cedula;
                lblNombreM.Text = clienteSeleccionado.Nombre;
                lblApellidoM.Text = clienteSeleccionado.Apellido;
                celularInvisible.Text = clienteSeleccionado.Telefono;
                fechaNacInvisible.Text = clienteSeleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                direccionInvisible.Text = clienteSeleccionado.Direccion;

                if (clienteSeleccionado is ClienteEstudiante cliEst)
                {
                    lblEstudianteM.Text = "SI";
                    comprobanteInvisible.Text = cliEst.Comprobante;
                }
                else
                {

                    lblEstudianteM.Text = "NO";
                    comprobanteInvisible.Text = ctrCliente.ObtenerComprobanteActualizado(clienteSeleccionado.Cedula);
                }
            }
        }

        public void AbrirPDF()
        {
            if (File.Exists("Reporte-Membresia.pdf")) // Verificar si el archivo PDF existe antes de intentar abrirlo
            {
                System.Diagnostics.Process.Start("Reporte-Membresia.pdf"); // Abrir el archivo PDF con el visor de PDF predeterminado del sistema
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
            string[] etiquetas = { "PLAN DE LA MEMBRESIA", "CEDULA DEL CLIENTE", "NOMBRE DEL CLIENTE", "APELLIDO DEL CLIENTE", "FECHA INICIO", "FECHA FIN", "PROMOCION", "DESCUENTO","DETALLE DE LA PROMOCION","PRECIO"};
            int numCol = 10;
            List<Membresia> membresia = GetListaMembresia();

            try
            {
                // Crear documento PDF
                stream = new FileStream("Reporte-Membresia.pdf", FileMode.Create);
                document = new Document(PageSize.A4.Rotate(), 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Crear fuentes
                iTextSharp.text.Font Miletra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font letra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLUE);

                // Agregar contenido al documento PDF
                document.Add(new Paragraph("CONSULTA DE MEMBRESIAS ACTIVAS DEL GIMNASIO GYMRAT."));
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(numCol);
                table.WidthPercentage = 100;

                PdfPCell[] columnaT = new PdfPCell[etiquetas.Length];
                for (int i = 0; i < etiquetas.Length; i++)
                {
                    columnaT[i] = new PdfPCell(new Phrase(etiquetas[i], Miletra));
                    columnaT[i].BorderWidth = 0;
                    columnaT[i].BorderWidthBottom = 0.25f;
                    table.AddCell(columnaT[i]);
                }

                foreach (Membresia mem in membresia)
                {
                    columnaT[0] = new PdfPCell(new Phrase(mem.Plan, letra));
                    columnaT[0].BorderWidth = 0;

                    columnaT[1] = new PdfPCell(new Phrase(mem.Cliente?.Cedula ?? "N/A", letra));
                    columnaT[1].BorderWidth = 0;

                    columnaT[2] = new PdfPCell(new Phrase(mem.Cliente?.Nombre ?? "N/A", letra));
                    columnaT[2].BorderWidth = 0;

                    columnaT[3] = new PdfPCell(new Phrase(mem.Cliente?.Apellido ?? "N/A", letra));
                    columnaT[3].BorderWidth = 0;

                    columnaT[4] = new PdfPCell(new Phrase(mem.FechaInicio.ToString("d"), letra));
                    columnaT[4].BorderWidth = 0;

                    columnaT[5] = new PdfPCell(new Phrase(mem.FechaFin.ToString("d"), letra));
                    columnaT[5].BorderWidth = 0;

                    columnaT[6] = new PdfPCell(new Phrase(mem.Promocion, letra));
                    columnaT[6].BorderWidth = 0;

                    columnaT[7] = new PdfPCell(new Phrase(mem.Descuento.ToString(), letra)); 
                    columnaT[7].BorderWidth = 0;

                    columnaT[8] = new PdfPCell(new Phrase(mem.DetallePromocion, letra));
                    columnaT[8].BorderWidth = 0;

                    columnaT[9] = new PdfPCell(new Phrase(mem.Precio.ToString(), letra));
                    columnaT[9].BorderWidth = 0;



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
                stream?.Close(); // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
            }
        }
    }
}
