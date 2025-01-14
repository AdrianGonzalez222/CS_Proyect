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
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista
{
    public partial class VsConsultarFactura : Form
    {
        // El original
        CtrFactura ctrfacto = new CtrFactura();
        private Validacion val = new Validacion();


        public VsConsultarFactura()
        {
            InitializeComponent();
            ctrfacto.LlenarDataFact(dgvRegistroFact);
            
            //facturaListi = CtrFactura.GetTotal();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvRegistroFact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            val.ConvertirMayusculaRich(richTextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filtro = txtingresarbuscar.Text.Trim();
            ctrfacto.TablaConsultarNombreDescripcion(dgvRegistroFact, filtro);
        }

        private void btnInactivarFact_Click(object sender, EventArgs e)
        {
            if (dgvRegistroFact.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvRegistroFact.SelectedRows[0];
                var serie = (string)filaSeleccionada.Cells["FacturaRegistroFact"].Value;

                string motivoInactivacion = richTextBox1.Text;

                if (string.IsNullOrWhiteSpace(motivoInactivacion))
                {
                    MessageBox.Show("ERROR: ESCRIBA EL MOTIVO POR EL QUE DESEA INACTIVAR LA FACTURA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                filaSeleccionada.Cells["MotivoDataFact"].Value = motivoInactivacion;

                ctrfacto.InactivarFactura(serie, filaSeleccionada, dgvRegistroFact);

                ctrfacto.LlenarDataFact(dgvRegistroFact);

                richTextBox1.Clear();
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE INACTIVAR.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            richTextBox1.KeyPress += val.ValidarLetra;

        }
    

        private void txtingresarbuscar_TextChanged_1(object sender, EventArgs e)
        {
            val.ConvertirMayuscula(txtingresarbuscar);
        }

        private void btnVolverFact_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VsConsultarFactura_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VsRegistroPrecio vRegistroPrecio = new VsRegistroPrecio();
            vRegistroPrecio.ShowDialog();
        }

        private void btnActivarFact_Click(object sender, EventArgs e)
        {
            
            if (dgvRegistroFact.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvRegistroFact.SelectedRows[0];
                var serie = (string)filaSeleccionada.Cells["FacturaRegistroFact"].Value;

                ctrfacto.ActivarFactura(serie, filaSeleccionada, dgvRegistroFact);

                ctrfacto.LlenarDataFact(dgvRegistroFact);

                richTextBox1.Clear();
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA ANTES DE ACTIVAR.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void buttonGenerarPDF_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("DESEA GENERAR REPORTE PDF DE FACTURAS?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                ctrfacto.GenerarPDF();
                ctrfacto.AbrirPDF();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
