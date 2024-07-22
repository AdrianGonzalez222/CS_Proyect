﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dato;
using Modelo;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Control
{
    // GONZALEZ ASTUDILLO ADRIAN
    public class CtrActividad
    {
        Conexion conn = new Conexion();
        DatoActividad dtActividad = new DatoActividad();

        private DateTime fechaActual = DateTime.Now;
        private static List<Actividad> listaActividad = new List<Actividad>();

        public DateTime FechaActual { get => fechaActual; set => fechaActual = value; }
        public static List<Actividad> ListaActividad { get => listaActividad; set => listaActividad = value; }


        //public CtrActividad()
        //{
        //    if (ListaActividad.Count == 0)
        //    {
        //        ListaActividad.Add(new Actividad("ACTIVIDAD 1", "PESAS", DateTime.Now, DateTime.Now.AddDays(1), new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)));
        //        ListaActividad.Add(new Actividad("ACTIVIDAD 2", "MANCUERNAS", DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0)));
        //        ListaActividad.Add(new Actividad("ACTIVIDAD 3", "FLEXIONES", DateTime.Now.AddDays(4), DateTime.Now.AddDays(5), new TimeSpan(11, 0, 0), new TimeSpan(14, 0, 0)));
        //    }
        //}
    

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
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (horaInicio == horaFin)
            {
                return "ERROR: HORA INICIO NO PUEDE SER IGUAL A HORA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
                return "ERROR: FECHA FIN NO PUEDE SER ANTERIOR A FECHA INICIO.";
            }
            else if (ActividadExistente(sNombre))
            {
                return "ERROR: ACTIVIDAD YA REGISTRADA CON ESE NOMBRE.";
            }
            else if (string.IsNullOrEmpty(sNombre) || sNombre.Equals("") && string.IsNullOrEmpty(sDescripcion) || sDescripcion.Equals(""))
            {
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else
            {
                act = new Actividad(sNombre, sDescripcion, fechaInicio, fechaFin, horaInicio, horaFin);
                //ListaActividad.Add(act);              
                IngresarActividadBD(act); // BASE DE DATOS
                msj = "ACTIVIDAD REGISTRADA CORRECTAMENTE" + Environment.NewLine + act.ToString();
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
            ListaActividad = TablaConsultarActividadBD(1); // BASE DE DATOS
            return ListaActividad.Count;
        }

        public int GetTotalInactivas()
        {
            ListaActividad = TablaConsultarActividadBD(2); // BASE DE DATOS
            return ListaActividad.Count(act => act.Estado == 2);
        }

        public List<Actividad> TablaConsultarActividadBD(int estado)
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
            }
            conn.CerrarConexion();
            return actividades;
        }


        //// 1
        //public void TablaConsultarActividadBD(int estado)
        //{
        //    string msjBD = conn.AbrirConexion();

        //    if (msjBD[0] == '1')
        //    {
        //        ListaActividad = dtActividad.SelectActividades(conn.Connect, estado);
        //    }
        //    else if (msjBD[0] == '0')
        //    {
        //        MessageBox.Show("ERROR: " + msjBD);
        //    }
        //    conn.CerrarConexion();
        //}

        //// 2
        //public void TablaConsultarActividadBD()
        //{
        //    string msjBD = conn.AbrirConexion();

        //    if (msjBD[0] == '1')
        //    {
        //        ListaActividad = dtActividad.SelectActividades(conn.Connect);
        //    }
        //    else if (msjBD[0] == '0')
        //    {
        //        MessageBox.Show("ERROR: " + msjBD);
        //    }
        //    conn.CerrarConexion();
        //}


        //
        // CAMBIAR ESTADO - BD
        //
        public void InactivarActividad(DataGridView dgvActividad)
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
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE INACTIVAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RestaurarActividad(DataGridView dgvActividad)
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
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE RESTAURAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
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
                return "ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS.";
            }
            else if (fechaInicio.Date == fechaFin.Date)
            {
                return "ERROR: FECHA INICIO NO PUEDE SER IGUAL A FECHA FIN.";
            }
            else if (horaInicio == horaFin)
            {
                return "ERROR: HORA INICIO NO PUEDE SER IGUAL A HORA FIN.";
            }
            else if (fechaFin < fechaInicio)
            {
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

                    EditarActividadBD(actividadExistente, sNombreOriginal); // BASE DE DATOS
                    msj = "ACTIVIDAD EDITADA CORRECTAMENTE" + Environment.NewLine + actividadExistente.ToString();
                }
                else
                {
                    msj = "ERROR: NO SE PUDO ENCONTRAR LA ACTIVIDAD A EDITAR.";
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
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // REMOVER - BD
        //
        public void RemoverActividad(DataGridView dgvActividad)
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
                            //ListaActividad.Remove(actividad);
                            RemoverActividadBD(actividad); // BASE DE DATOS
                            TablaConsultarActividadPapelera(dgvActividad);

                            for (int i = filaSeleccionada; i < dgvActividad.Rows.Count; i++)
                            {
                                dgvActividad.Rows[i].Cells["ClmNumero"].Value = i + 1;
                            }
                            MessageBox.Show("ACTIVIDAD ELIMINADA CORRECTAMENTE." + Environment.NewLine + actividad.ToString(), "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR  UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                }
            }
            else if (msjBD[0] == '0')
            {
                MessageBox.Show("ERROR: " + msjBD);
            }
            conn.CerrarConexion();
        }

        //
        // FILTROS DE BUSQUEDA
        //
        public void TablaConsultarActividadNombreDescripcion(DataGridView dgvActividad, string filtro = "", bool buscarPorNombre = true)
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
      
        public void TablaConsultarActividadNombreDescripcionPapelera(DataGridView dgvActividad, string filtro = "", bool buscarPorNombre = true)
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
            int i = 0;
            dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY          
            //TablaConsultarActividadBD(1); // BASE DE DATOS
            //TablaConsultarActividadBD();

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

        public void TablaConsultarActividadPapelera(DataGridView dgvActividad)
        {
            int i = 0;
            dgvActividad.Rows.Clear(); // LIMPIA FILAS SI LAS HAY
            //TablaConsultarActividadBD(2); // BASE DE DATOS

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

        public void PresentarDatosActividad(TextBox textNombre, TextBox textDescripcion, DateTimePicker dtpFechaInicio, DateTimePicker dtpFechaFin, DateTimePicker dtpHoraInicio, DateTimePicker dtpHoraFin, string nombreActividad)
        {
            //Actividad actividadSeleccionada = ExtraerNombreActividad(nombreActividad);
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

        //
        // GENERAR PDF
        //
        public void AbrirPDF()
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

        //
        // METODOS SIN USO ACTUAL
        //
        public Actividad ExtraerNombreActividad(string nombreActividad)
        {
            return listaActividad.Find(a => a.Nombre == nombreActividad);
        }

    // FIN
    }
}
