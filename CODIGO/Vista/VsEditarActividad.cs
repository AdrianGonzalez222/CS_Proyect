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
    public partial class VsEditarActividad : Form
    {
        private Validacion val = new Validacion();
        private CtrActividad ctrActividad = new CtrActividad();
        private bool cambiosGuardados;

        public bool CambiosGuardados { get => cambiosGuardados; set => cambiosGuardados = value; }

        public VsEditarActividad(string nombreActividad)
        {
            InitializeComponent();
            ctrActividad.PresentarDatosActividad(textNombre, textDescripcion, dtpFechaInicio, dtpFechaFin, dtpHoraInicio, dtpHoraFin, nombreActividad);
            textNombreOriginal.Text = textNombre.Text;
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string msj = "";
            string sNombreOriginal = textNombreOriginal.Text.Trim();
            string sNombre = textNombre.Text.Trim();
            string sDescripcion = textDescripcion.Text.Trim();
            string sFechaInicio = dtpFechaInicio.Text.Trim();
            string sFechaFin = dtpFechaFin.Text.Trim();
            string sHoraInicio = dtpHoraInicio.Text.Trim();
            string sHoraFin = dtpHoraFin.Text.Trim();

            msj = ctrActividad.EditarActividad(sNombreOriginal, sNombre, sDescripcion, sFechaInicio, sFechaFin, sHoraInicio, sHoraFin);
            MessageBox.Show(msj, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (msj.Contains("ACTIVIDAD EDITADA CORRECTAMENTE"))
            {
                CambiosGuardados = true;
                this.Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        // FIN
    }
}
