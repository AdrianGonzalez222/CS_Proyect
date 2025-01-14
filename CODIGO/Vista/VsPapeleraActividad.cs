using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vista
{
    // GONZALEZ ASTUDILLO ADRIAN
    public partial class VsPapeleraActividad : Form
    {
        private CtrActividad ctrActividad = new CtrActividad();
        private Validacion val = new Validacion();

        public VsPapeleraActividad()
        {
            InitializeComponent();
            ctrActividad.TablaConsultarActividadPapelera(dgvActividad);
        }

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            ctrActividad.RestaurarActividad(dgvActividad);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string filtro = textBuscar.Text.Trim();
            bool buscarPorNombre = radioButtonNombre.Checked;
            ctrActividad.TablaConsultarActividadNombreDescripcionPapelera(dgvActividad, filtro, buscarPorNombre);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            ctrActividad.RemoverActividad(dgvActividad);
        }

        private void buttonGenerarPDF_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("DESEA GENERAR REPORTE PDF DE ACTIVIDADES INACTIVAS?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ctrActividad.GenerarPDF_Off();
                ctrActividad.AbrirPDF_Off();
            }
        }

        // FIN
    }
}
