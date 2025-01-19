using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsConsultarFactura : Form
    {
        private CtrFactura ctrfacto = new CtrFactura();
        private Validacion val = new Validacion();

        public VsConsultarFactura()
        {
            InitializeComponent();
            ctrfacto.LlenarDataFact(dgvRegistroFact);
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
    
        private void txtingresarbuscar_TextChanged_1(object sender, EventArgs e)
        {
            val.ConvertirMayuscula(txtingresarbuscar);
        }

        private void btnVolverFact_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VsRegistroPrecio vRegistroPrecio = new VsRegistroPrecio();
            vRegistroPrecio.ShowDialog();
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

    }
}
