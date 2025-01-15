using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dato;
using Modelo;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Serilog;

namespace Control
{
    public class CtrActividad
    {
        Conexion conn = new Conexion();
        DatoActividad dtActividad = new DatoActividad();

        private DateTime fechaActual = DateTime.Now;
        private static List<Actividad> listaActividad = new List<Actividad>();

        public DateTime FechaActual { get => fechaActual; set => fechaActual = value; }
        public static List<Actividad> ListaActividad { get => listaActividad; set => listaActividad = value; }

        //
        // INGRESAR LIST - BD
        //
        public string IngresarActividad(string sNombre, string sDescripcion, string sFechaInicio, string sFechaFin, string sHoraInicio, string sHoraFin)
        {
            string msj = "ERROR: SE ESPERABA DATOS CORRECTOS.";
            Validacion val = new Validacion();
            Actividad act = null;
            DateTime fechaInicio = val.ConvertirDateTime(sFechaInicio);
            DateTime fechaFin = val.ConvertirDateTime(sFechaFin);
            TimeSpan horaInicio = val.ConvertirTimeSpan(sHoraInicio);
            TimeSpan horaFin = val.ConvertirTimeSpan(sHoraFin);

            if (fechaInicio.Date == fechaFin.Date)
            {
                Log.Warning("FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.");
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (horaInicio == horaFin)
            {
                Log.Warning("HORA INICIO NO PUEDE SER IGUAL A HORA FIN.");
                return "ERROR: HORA INICIO NO PUEDE SER IGUAL A HORA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
                Log.Warning("FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.");
                return "ERROR: FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.";
            }
            else if (ActividadExistente(sNombre))
            {
                Log.Warning("ACTIVIDAD YA REGISTRADA CON ESE NOMBRE.");
                return "ERROR: ACTIVIDAD YA REGISTRADA CON ESE NOMBRE.";
            }
            else if (string.IsNullOrEmpty(sNombre) || sNombre.Equals("") && string.IsNullOrEmpty(sDescripcion) || sDescripcion.Equals(""))
            {
                Log.Warning("NO PUEDEN EXISTIR CAMPOS VACIOS.");
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else
            {
                try 
                { 
                    act = new Actividad(sNombre, sDescripcion, fechaInicio, fechaFin, horaInicio, horaFin);           
                    IngresarActividadBD(act); // BASE DE DATOS
                    msj = "ACTIVIDAD REGISTRADA CORRECTAMENTE" + Environment.NewLine + act.ToString();
                    Log.Information("ACTIVIDAD REGISTRADA CORRECTAMENTE: {act}", act);
                }
                catch (Exception ex)
                {
                    Log.Error("ERROR INESPERADO: {ex}", ex);
                    return "ERROR INESPERADO: " + ex.Message;
                }
            }
            return msj;
        }

        public void IngresarActividadBD(Actividad act)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtActividad.InsertActividad(act, conn.Connect);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                    Log.Error("ERROR INESPERADO: {msj}", msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
                Log.Error("ERROR: {msjBD}", msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // CONSULTAR LIST - BD
        //
        public int GetTotal()
        {
            try 
            { 
                ListaActividad = TablaConsultarActividadBD(1); // BASE DE DATOS
                return ListaActividad.Count;
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
                return 0;
            }

        }

        public int GetTotalInactivas()
        {
            try
            {
                ListaActividad = TablaConsultarActividadBD(2); // BASE DE DATOS
                return ListaActividad.Count(act => act.Estado == 2);
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
                return 0;
            }
        }

        public List<Actividad> TablaConsultarActividadBD(int estado)
        {
            try
            {
                List<Actividad> actividades = new List<Actividad>();
                string msjBD = conn.AbrirConexion();

                if (msjBD[0] == '1')
                {
                    actividades = dtActividad.SelectActividades(conn.Connect, estado);
                }
                else if (msjBD[0] == '0')
                {
                    MessageBox.Show("ERROR: " + msjBD);
                    Log.Error("ERROR: {msjBD}", msjBD);
                }
                conn.CerrarConexion();
                return actividades;
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
                return null;
            }
        }

        //
        // CAMBIAR ESTADO - BD
        //
        public void InactivarActividad(DataGridView dgvActividad)
        {
            try
            {
                if (dgvActividad.SelectedRows.Count > 0)
                {
                    int filaSeleccionada = dgvActividad.SelectedRows[0].Index; // OBTIENE INDICE DE FILA SELECCIONADA

                    if (filaSeleccionada >= 0)
                    {
                        string nombreActividad = dgvActividad.Rows[filaSeleccionada].Cells["ClmNombre"].Value.ToString(); // OBTENER NOMBRE DE ACTIVIDAD
                        Actividad actividad = ListaActividad.FirstOrDefault(a => a.Nombre == nombreActividad); // BUSCA ACTIVIDAD EN LISTA POR NOMBRE

                        if (actividad != null)
                        {
                            DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE INACTIVAR ESTA ACTIVIDAD?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (resultado == DialogResult.Yes)
                            {
                                actividad.Estado = 2; // ESTADO 2 = INACTIVO
                                EstadoActividadBD(actividad); // BASE DE DATOS
                                TablaConsultarActividad(dgvActividad);
                                MessageBox.Show("ACTIVIDAD INACTIVADA EXITOSAMENTE." + Environment.NewLine + actividad.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Information("ACTIVIDAD INACTIVADA EXITOSAMENTE: {actividad}", actividad);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE INACTIVAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("ERROR: SELECCIONA UNA FILA ANTES DE INACTIVAR UNA ACTIVIDAD.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void RestaurarActividad(DataGridView dgvActividad)
        {
            try
            {
                if (dgvActividad.SelectedRows.Count > 0)
                {
                    int filaSeleccionada = dgvActividad.SelectedRows[0].Index; // OBTIENE EL ÍNDICE DE LA FILA SELECCIONADA

                    if (filaSeleccionada >= 0)
                    {
                        string nombreActividad = dgvActividad.Rows[filaSeleccionada].Cells["ClmNombre"].Value.ToString(); // OBTIENE EL NOMBRE DE LA ACTIVIDAD DE LA FILA SELECCIONADA
                        Actividad actividad = ListaActividad.FirstOrDefault(a => a.Nombre == nombreActividad);// BUSCA ACTIVIDAD EN LISTA POR NOMBRE

                        if (actividad != null)
                        {
                            DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE RESTAURAR ESTA ACTIVIDAD?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (resultado == DialogResult.Yes)
                            {
                                actividad.Estado = 1; // CAMBIA EL ESTADO A ACTIVO
                                EstadoActividadBD(actividad); // BASE DE DATOS
                                TablaConsultarActividadPapelera(dgvActividad);
                                MessageBox.Show("ACTIVIDAD RESTAURADA EXITOSAMENTE." + Environment.NewLine + actividad.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Information("ACTIVIDAD RESTAURADA EXITOSAMENTE: {actividad}", actividad);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE RESTAURAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("ERROR: SELECCIONA UNA FILA ANTES DE RESTAURAR UNA ACTIVIDAD.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void EstadoActividadBD(Actividad act)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtActividad.UpdateEstadoActividad(act, conn.Connect);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                    Log.Error("ERROR INESPERADO: {msj}", msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
                Log.Error("ERROR: {msjBD}", msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // EDITAR - BD
        //
        public string EditarActividad(string sNombreOriginal, string sNombre, string sDescripcion, string sFechaInicio, string sFechaFin, string sHoraInicio, string sHoraFin)
        {
            string msj = "ERROR: SE ESPERABA DATOS CORRECTOS.";
            Validacion val = new Validacion();
            DateTime fechaInicio = val.ConvertirDateTime(sFechaInicio);
            DateTime fechaFin = val.ConvertirDateTime(sFechaFin);
            TimeSpan horaInicio = val.ConvertirTimeSpan(sHoraInicio);
            TimeSpan horaFin = val.ConvertirTimeSpan(sHoraFin);

            if (string.IsNullOrEmpty(sNombre) || string.IsNullOrEmpty(sDescripcion))
            {
                Log.Warning("NO PUEDEN EXISTIR CAMPOS VACIOS.");
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else if (fechaInicio.Date == fechaFin.Date)
            {
                Log.Warning("FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.");
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (horaInicio == horaFin)
            {
                Log.Warning("HORA INICIO NO PUEDE SER IGUAL A HORA FIN.");
                return "ERROR: HORA INICIO NO PUEDE SER IGUAL A HORA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
                Log.Warning("FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.");
                return "ERROR: FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.";
            }
            else
            {
                Actividad actividadExistente = ListaActividad.Find(atv => atv.Nombre == sNombreOriginal); // BUSCAR NOMBRE ORIGINAL EN LISTA
                if (actividadExistente != null)
                {
                    if (actividadExistente.Nombre != sNombre) // SI NOMBRE ORIGINAL Y NUEVO SON DIFERENTES
                    {
                        if (ListaActividad.Any(atv => atv.Nombre == sNombre)) // BUSCAR SI NOMBRE NUEVO YA EXISTE
                        {
                            Log.Warning("YA EXISTE UNA ACTIVIDAD CON EL NUEVO NOMBRE.");
                            return "ERROR: YA EXISTE UNA ACTIVIDAD CON EL NUEVO NOMBRE.";
                        }
                        actividadExistente.Nombre = sNombre; // ASIGNAR NOMBRE NUEVO
                    }

                    // ACTUALIZA DATOS ACTIVIDAD
                    actividadExistente.Descripcion = sDescripcion;
                    actividadExistente.FechaInicio = fechaInicio;
                    actividadExistente.FechaFin = fechaFin;
                    actividadExistente.HoraInicio = horaInicio;
                    actividadExistente.HoraFin = horaFin;

                    try
                    {
                        EditarActividadBD(actividadExistente, sNombreOriginal); // BASE DE DATOS
                        msj = "ACTIVIDAD EDITADA CORRECTAMENTE" + Environment.NewLine + actividadExistente.ToString();
                        Log.Information("ACTIVIDAD EDITADA CORRECTAMENTE: {actividadExistente}", actividadExistente);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("ERROR INESPERADO: {ex}", ex);
                    }
                }
                else
                {
                    msj = "ERROR: NO SE PUDO ENCONTRAR LA ACTIVIDAD A EDITAR.";
                    Log.Warning("ERROR: NO SE PUDO ENCONTRAR LA ACTIVIDAD A EDITAR.");
                }
            }
            return msj;
        }

        public void EditarActividadBD(Actividad act, string sNombreOriginal)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtActividad.UpdateCamposActividad(act, conn.Connect, sNombreOriginal);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                    Log.Error("ERROR INESPERADO: {msj}", msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
                Log.Error("ERROR: {msjBD}", msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // REMOVER - BD
        //
        public void RemoverActividad(DataGridView dgvActividad)
        {
            try
            {
                if (dgvActividad.SelectedRows.Count > 0)
                {
                    int filaSeleccionada = dgvActividad.SelectedRows[0].Index; // OBTIENE EL ÍNDICE DE LA FILA SELECCIONADA

                    if (filaSeleccionada >= 0)
                    {
                        string nombreActividad = dgvActividad.Rows[filaSeleccionada].Cells["ClmNombre"].Value.ToString(); // OBTIENE EL NOMBRE DE LA ACTIVIDAD DE LA FILA SELECCIONADA
                        Actividad actividad = ListaActividad.FirstOrDefault(a => a.Nombre == nombreActividad); // BUSCA ACTIVIDAD EN LISTA POR NOMBRE

                        if (actividad != null)
                        {
                            DialogResult resultado = MessageBox.Show("ESTAS SEGURO DE ELIMINAR ESTA ACTIVIDAD?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                            if (resultado == DialogResult.Yes)
                            {
                                RemoverActividadBD(actividad); // BASE DE DATOS
                                TablaConsultarActividadPapelera(dgvActividad);

                                for (int i = filaSeleccionada; i < dgvActividad.Rows.Count; i++)
                                {
                                    dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                                }
                                MessageBox.Show("ACTIVIDAD ELIMINADA CORRECTAMENTE." + Environment.NewLine + actividad.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.Information("ACTIVIDAD ELIMINADA CORRECTAMENTE: {actividad}", actividad);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR  UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR UNA ACTIVIDAD.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }        
        }

        public void RemoverActividadBD(Actividad act)
        {
            string msj = string.Empty;
            string msjBD = conn.AbrirConexion();

            if (msjBD[0] == '1')
            {
                msj = dtActividad.DeleteActividad(act, conn.Connect);
                if (msj[0] == '0')
                {
                    MessageBox.Show("ERROR INESPERADO: " + msj);
                    Log.Error("ERROR INESPERADO: {msj}", msj);
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
                Log.Error("ERROR: {msjBD}", msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // FILTROS DE BUSQUEDA
        //
        public void TablaConsultarActividadNombreDescripcion(DataGridView dgvActividad, string filtro = "", bool buscarPorNombre = true)
        {
            try
            {
                int i = 0;
                dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

                foreach (Actividad x in ListaActividad)
                {
                    if (x.Estado == 1 &&
                        (string.IsNullOrEmpty(filtro) ||
                        (buscarPorNombre && x.Nombre.Contains(filtro)) ||
                        (!buscarPorNombre && x.Descripcion.Contains(filtro))))
                    {
                        i = dgvActividad.Rows.Add();
                        dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                        dgvActividad.Rows[i].Cells["ClmEstado"].Value = x.Estado;
                        dgvActividad.Rows[i].Cells["ClmNombre"].Value = x.Nombre;
                        dgvActividad.Rows[i].Cells["ClmDescripcion"].Value = x.Descripcion;
                        dgvActividad.Rows[i].Cells["ClmFechaInicio"].Value = x.FechaInicio.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmFechaFin"].Value = x.FechaFin.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmHoraInicio"].Value = x.HoraInicio.ToString(@"hh\:mm");
                        dgvActividad.Rows[i].Cells["ClmHoraFin"].Value = x.HoraFin.ToString(@"hh\:mm");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }
      
        public void TablaConsultarActividadNombreDescripcionPapelera(DataGridView dgvActividad, string filtro = "", bool buscarPorNombre = true)
        {
            try
            {
                int i = 0;
                dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY
                foreach (Actividad x in ListaActividad)
                {
                    if (x.Estado == 2 &&
                        (string.IsNullOrEmpty(filtro) ||
                        (buscarPorNombre && x.Nombre.Contains(filtro)) ||
                        (!buscarPorNombre && x.Descripcion.Contains(filtro))))
                    {
                        i = dgvActividad.Rows.Add();
                        dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                        dgvActividad.Rows[i].Cells["ClmEstado"].Value = x.Estado;
                        dgvActividad.Rows[i].Cells["ClmNombre"].Value = x.Nombre;
                        dgvActividad.Rows[i].Cells["ClmDescripcion"].Value = x.Descripcion;
                        dgvActividad.Rows[i].Cells["ClmFechaInicio"].Value = x.FechaInicio.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmFechaFin"].Value = x.FechaFin.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmHoraInicio"].Value = x.HoraInicio.ToString(@"hh\:mm");
                        dgvActividad.Rows[i].Cells["ClmHoraFin"].Value = x.HoraFin.ToString(@"hh\:mm");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        //
        // OTROS METODOS
        //
        public bool ActividadExistente(string nombre)
        {
            foreach (Actividad act in ListaActividad)
            {
                if (act.Nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }

        public void TablaConsultarActividad(DataGridView dgvActividad)
        {
            try
            {
                int i = 0;
                dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY          

                foreach (Actividad x in ListaActividad)
                {
                    if (x.Estado == 1)
                    {
                        i = dgvActividad.Rows.Add();
                        dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                        dgvActividad.Rows[i].Cells["ClmEstado"].Value = x.Estado;
                        dgvActividad.Rows[i].Cells["ClmNombre"].Value = x.Nombre;
                        dgvActividad.Rows[i].Cells["ClmDescripcion"].Value = x.Descripcion;
                        dgvActividad.Rows[i].Cells["ClmFechaInicio"].Value = x.FechaInicio.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmFechaFin"].Value = x.FechaFin.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmHoraInicio"].Value = x.HoraInicio.ToString(@"hh\:mm");
                        dgvActividad.Rows[i].Cells["ClmHoraFin"].Value = x.HoraFin.ToString(@"hh\:mm");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void TablaConsultarActividadPapelera(DataGridView dgvActividad)
        {
            try
            {
                int i = 0;
                dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY

                foreach (Actividad x in ListaActividad)
                {
                    if (x.Estado == 2)
                    {
                        i = dgvActividad.Rows.Add();
                        dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                        dgvActividad.Rows[i].Cells["ClmEstado"].Value = x.Estado;
                        dgvActividad.Rows[i].Cells["ClmNombre"].Value = x.Nombre;
                        dgvActividad.Rows[i].Cells["ClmDescripcion"].Value = x.Descripcion;
                        dgvActividad.Rows[i].Cells["ClmFechaInicio"].Value = x.FechaInicio.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmFechaFin"].Value = x.FechaFin.ToString("d");
                        dgvActividad.Rows[i].Cells["ClmHoraInicio"].Value = x.HoraInicio.ToString(@"hh\:mm");
                        dgvActividad.Rows[i].Cells["ClmHoraFin"].Value = x.HoraFin.ToString(@"hh\:mm");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void PresentarDatosActividad(TextBox textNombre, TextBox textDescripcion, DateTimePicker dtpFechaInicio, DateTimePicker dtpFechaFin, DateTimePicker dtpHoraInicio, DateTimePicker dtpHoraFin, string nombreActividad)
        {
            Actividad actividadSeleccionada = listaActividad.Find(a => a.Nombre == nombreActividad);
            if (actividadSeleccionada != null)
            {
                textNombre.Text = actividadSeleccionada.Nombre;
                textDescripcion.Text = actividadSeleccionada.Descripcion;
                dtpFechaInicio.Value = actividadSeleccionada.FechaInicio;
                dtpFechaFin.Value = actividadSeleccionada.FechaFin;
                dtpHoraInicio.Value = DateTime.Today + actividadSeleccionada.HoraInicio;
                dtpHoraFin.Value = DateTime.Today + actividadSeleccionada.HoraFin;
            }
        }

        public List<Actividad> GetListaActividad()
        {
            return TablaConsultarActividadBD(1);
        }

        public List<Actividad> GetListaActividadPapelera()
        {
            return TablaConsultarActividadBD(2);
        }

        //
        // GENERAR PDF
        //
        public void AbrirPDF()
        {
            try
            {
                if (File.Exists("REPORTE-PDF-ACTIVIDADES.pdf")) // Verificar si el archivo PDF existe antes de intentar abrirlo
                {
                    System.Diagnostics.Process.Start("REPORTE-PDF-ACTIVIDADES.pdf"); // Abrir el archivo PDF con el visor de PDF predeterminado del sistema
                }
                else
                {
                    MessageBox.Show("ARCHIVO PDF NO ENCONTRADO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void GenerarPDF()
        {
            FileStream stream = null;
            Document document = null;
            string[] etiquetas = { "NOMBRE", "DESCRIPCION", "FECHA INICIO", "FECHA FIN", "HORA INICIO", "HORA FIN" };
            int numCol = 6;
            List<Actividad> actividades = GetListaActividad();

            try
            {
                // Crear documento PDF
                stream = new FileStream("REPORTE-PDF-ACTIVIDADES.pdf", FileMode.Create);
                document = new Document(PageSize.A4, 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Crear fuentes
                iTextSharp.text.Font Miletra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font letra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLUE);

                // Agregar contenido al documento PDF
                document.Add(new Paragraph("CONSULTA DE ACTIVIDADES ACTIVAS DEL GIMNASIO GYMRAT."));
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

                foreach (Actividad act in actividades)
                {
                    columnaT[0] = new PdfPCell(new Phrase(act.Nombre, letra));
                    columnaT[0].BorderWidth = 0;

                    columnaT[1] = new PdfPCell(new Phrase(act.Descripcion, letra));
                    columnaT[1].BorderWidth = 0;

                    columnaT[2] = new PdfPCell(new Phrase(act.FechaInicio.ToString("d"), letra));
                    columnaT[2].BorderWidth = 0;

                    columnaT[3] = new PdfPCell(new Phrase(act.FechaFin.ToString("d"), letra));
                    columnaT[3].BorderWidth = 0;

                    columnaT[4] = new PdfPCell(new Phrase(act.HoraInicio.ToString(@"hh\:mm"), letra));
                    columnaT[4].BorderWidth = 0;

                    columnaT[5] = new PdfPCell(new Phrase(act.HoraFin.ToString(@"hh\:mm"), letra));
                    columnaT[5].BorderWidth = 0;

                    table.AddCell(columnaT[0]);
                    table.AddCell(columnaT[1]);
                    table.AddCell(columnaT[2]);
                    table.AddCell(columnaT[3]);
                    table.AddCell(columnaT[4]);
                    table.AddCell(columnaT[5]);
                }
                document.Add(table);
                document.Close();
                pdf.Close();

                MessageBox.Show("PDF GENERADO EXITOSAMENTE.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Information("PDF GENERADO EXITOSAMENTE.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("ERROR AL GENERAR PDF: {ex}", ex);
            }
            finally
            {
                stream?.Close(); // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
            }
        }

        public void AbrirPDF_Off()
        {
            try
            { 
                if (File.Exists("REPORTE-PDF-ACTIVIDADES-OFF.pdf")) // Verificar si el archivo PDF existe antes de intentar abrirlo
                {
                    System.Diagnostics.Process.Start("REPORTE-PDF-ACTIVIDADES-OFF.pdf"); // Abrir el archivo PDF con el visor de PDF predeterminado del sistema
                }
                else
                {
                    MessageBox.Show("ARCHIVO PDF NO ENCONTRADO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error("ERROR INESPERADO: {ex}", ex);
            }
        }

        public void GenerarPDF_Off()
        {
            FileStream stream = null;
            Document document = null;
            string[] etiquetas = { "NOMBRE", "DESCRIPCION", "FECHA INICIO", "FECHA FIN", "HORA INICIO", "HORA FIN" };
            int numCol = 6;
            List<Actividad> actividades = GetListaActividadPapelera();

            try
            {
                // Crear documento PDF
                stream = new FileStream("REPORTE-PDF-ACTIVIDADES-OFF.pdf", FileMode.Create);
                document = new Document(PageSize.A4, 5, 5, 7, 7);
                PdfWriter pdf = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Crear fuentes
                iTextSharp.text.Font Miletra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font letra = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLUE);

                // Agregar contenido al documento PDF
                document.Add(new Paragraph("CONSULTA DE ACTIVIDADES ACTIVAS DEL GIMNASIO GYMRAT."));
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

                foreach (Actividad act in actividades)
                {
                    columnaT[0] = new PdfPCell(new Phrase(act.Nombre, letra));
                    columnaT[0].BorderWidth = 0;

                    columnaT[1] = new PdfPCell(new Phrase(act.Descripcion, letra));
                    columnaT[1].BorderWidth = 0;

                    columnaT[2] = new PdfPCell(new Phrase(act.FechaInicio.ToString("d"), letra));
                    columnaT[2].BorderWidth = 0;

                    columnaT[3] = new PdfPCell(new Phrase(act.FechaFin.ToString("d"), letra));
                    columnaT[3].BorderWidth = 0;

                    columnaT[4] = new PdfPCell(new Phrase(act.HoraInicio.ToString(@"hh\:mm"), letra));
                    columnaT[4].BorderWidth = 0;

                    columnaT[5] = new PdfPCell(new Phrase(act.HoraFin.ToString(@"hh\:mm"), letra));
                    columnaT[5].BorderWidth = 0;

                    table.AddCell(columnaT[0]);
                    table.AddCell(columnaT[1]);
                    table.AddCell(columnaT[2]);
                    table.AddCell(columnaT[3]);
                    table.AddCell(columnaT[4]);
                    table.AddCell(columnaT[5]);
                }
                document.Add(table);
                document.Close();
                pdf.Close();

                MessageBox.Show("PDF GENERADO EXITOSAMENTE.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Information("PDF GENERADO EXITOSAMENTE.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("ERROR AL GENERAR PDF: {ex}", ex);
            }
            finally
            {
                stream?.Close(); // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
            }
        }

    }
}
