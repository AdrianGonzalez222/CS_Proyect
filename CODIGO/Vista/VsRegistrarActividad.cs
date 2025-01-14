using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    // GONZALEZ ASTUDILLO ADRIAN
    public partial class VsRegistrarActividad : Form
    {
        private Validacion val = new Validacion();
        private CtrActividad ctrActividad = new CtrActividad();

        public VsRegistrarActividad()
        {
            InitializeComponent();
            dtpFechaInicio.Value = ctrActividad.FechaActual;
            dtpFechaFin.Value = ctrActividad.FechaActual;
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            string msj = "";
            string sNombre = textNombre.Text.Trim();
            string sDescripcion = textDescripcion.Text.Trim();
            string sFechaInicio = dtpFechaInicio.Text.Trim();
            string sFechaFin = dtpFechaFin.Text.Trim();
            string sHoraInicio = dtpHoraInicio.Text.Trim();
            string sHoraFin = dtpHoraFin.Text.Trim();

            msj = ctrActividad.IngresarActividad(sNombre, sDescripcion, sFechaInicio, sFechaFin, sHoraInicio, sHoraFin);
            MessageBox.Show(msj, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (msj.Contains("ACTIVIDAD REGISTRADA CORRECTAMENTE"))
            {
                DateTime horaDefectoInicio = ctrActividad.FechaActual.Date.AddHours(1).AddMinutes(00);
                DateTime horaDefectoFin = ctrActividad.FechaActual.Date.AddHours(23).AddMinutes(00);
                textNombre.Text = "";
                textDescripcion.Text = "";
                dtpFechaInicio.Value = ctrActividad.FechaActual;
                dtpFechaFin.Value = ctrActividad.FechaActual;
                dtpHoraInicio.Value = horaDefectoInicio;
                dtpHoraFin.Value = horaDefectoFin;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        // FIN    
    }
}
