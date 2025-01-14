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
    public partial class VsMembresiaConsulta : Form
    {
        private CtrMembresia ctrMem = new CtrMembresia();
        private bool cambiosGuardados;

        public bool CambiosGuardados { get => cambiosGuardados; set => cambiosGuardados = value; }
        public VsMembresiaConsulta()
        {
            InitializeComponent();
            ctrMem.LlenarGrid(dgvMembresia);
        }

        private void dgvMembresia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VsMembresiaConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnBM_Click(object sender, EventArgs e)
        {
            string filtro = txtBoxBM.Text.Trim();
            bool buscarPorCedula = radioBCM.Checked;
            ctrMem.TablaConsultarMebresiaFiltro(dgvMembresia, filtro, buscarPorCedula);
        }

        private void btnEM_Click(object sender, EventArgs e)
        {
            if (dgvMembresia.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvMembresia.SelectedRows[0]; // OBTIENE FILA SELECCIONADA
                string nombrePlan = filaSeleccionada.Cells["clmPM"].Value.ToString(); // EXTRAE NOMBRE DE FILA SELECCIONADA
                VsMembresiaEditar editarMem = new VsMembresiaEditar(nombrePlan); editarMem.ShowDialog();
                if (editarMem.CambiosGuardados)
                {
                    ctrMem.LlenarGrid(dgvMembresia);
                }
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE EDITAR UNA MEMBRESIA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarM_Click(object sender, EventArgs e)
        {
            ctrMem.InactivarMembresia(dgvMembresia); 
            //ctrMem.eliminarMembresia(dgvMembresia);
        }

        private void btnCerrarMembresia_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGenerarMembresiaPDF_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("DESEA GENERAR REPORTE PDF DE MEBRESIA?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ctrMem.GenerarPDF();
                ctrMem.AbrirPDF();
            }
        }

        private void ButtonMPM_Click(object sender, EventArgs e)
        {
            VsPapeleraMembresia vPapeleraMem = null;

            if (ctrMem.GetTotalInactivas() > 0)
            {
                this.Visible=false;
                this.Close();
                vPapeleraMem = new VsPapeleraMembresia(); vPapeleraMem.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: NO EXISTEN MEMBRESIAS ELIMINADAS DENTRO DE LA PAPELERA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
