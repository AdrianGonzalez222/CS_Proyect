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
    public partial class VsConsultarActividad : Form
    {
        private CtrActividad ctrActividad = new CtrActividad();
        private Validacion val = new Validacion();

        public VsConsultarActividad()
        {
            InitializeComponent();
            ctrActividad.TablaConsultarActividad(dgvActividad);
        }

        private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.ValidarCaracterEspecial(sender, e);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string filtro = textBuscar.Text.Trim();
            bool buscarPorNombre = radioButtonNombre.Checked;
            ctrActividad.TablaConsultarActividadNombreDescripcion(dgvActividad, filtro, buscarPorNombre);
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dgvActividad.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvActividad.SelectedRows[0]; // OBTIENE FILA SELECCIONADA
                string nombreActividad = filaSeleccionada.Cells["ClmNombre"].Value.ToString(); // EXTRAE NOMBRE DE FILA SELECCIONADA
                VsEditarActividad editarActividad = new VsEditarActividad(nombreActividad); editarActividad.ShowDialog();
                if (editarActividad.CambiosGuardados)
                {
                    ctrActividad.TablaConsultarActividad(dgvActividad);
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ELIMINAR UNA ACTIVIDAD.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            val.ConvertirMayuscula(textBox);
        }

        private void buttonInactivar_Click(object sender, EventArgs e)
        {
            ctrActividad.InactivarActividad(dgvActividad);
        }

        private void buttonGenerarPDF_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("DESEA GENERAR REPORTE PDF DE ACTIVIDADES?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ctrActividad.GenerarPDF();
                ctrActividad.AbrirPDF();
            }
        }

        // FIN
    }
}
