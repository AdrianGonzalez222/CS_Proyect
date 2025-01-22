using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsRegistroPrecio : Form
    {
        private CtrFactura ctrfacto = new CtrFactura();

        public VsRegistroPrecio()
        {
            InitializeComponent();

            cmbiNFORME.SelectedItem = "ACTIVO";
            cmbiNFORME.DropDownStyle = ComboBoxStyle.DropDownList;

            txtTotalFacturas.Enabled = false;
            txtTotalConDescuento.Enabled = false;
            txtTotalSinDescuento.Enabled = false;
            txtMontoTotal.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void btnInformePDF_Click(object sender, EventArgs e)
        {
            if (cmbiNFORME.SelectedItem == null)
            {
                MessageBox.Show("SELECCIONA EL ESTADO DE LAS FACTURAS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string estadoSeleccionado = cmbiNFORME.SelectedItem.ToString();
            DialogResult resultado = MessageBox.Show("DESEA GENERAR REPORTE PDF DE FACTURAS?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {            
                DateTime fechaInicio = DateTime.Parse(dtInicoInforme.Text);
                DateTime fechaFin = DateTime.Parse(dtFinInforme.Text);

                ctrfacto.GenerarInformePDF(estadoSeleccionado, fechaInicio, fechaFin);
                ctrfacto.AbrirInformePDF();
            }
        }

        private void btnMostrarInforme_Click(object sender, EventArgs e)
        {
            if (cmbiNFORME.SelectedItem == null)
            {
                MessageBox.Show("POR FAVOR, SELECCIONA UN ESTADO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string estadoSeleccionado = cmbiNFORME.SelectedItem.ToString();
            DateTime inicioInforme = dtInicoInforme.Value;
            DateTime finInforme = dtFinInforme.Value;

            // Limpiar controles
            txtTotalFacturas.Text = string.Empty;
            txtTotalConDescuento.Text = string.Empty;
            txtTotalSinDescuento.Text = string.Empty;
            txtMontoTotal.Text = string.Empty;
            ctrfacto.LlenarRegistroPrecioPorFecha(dgvRegistroPrecio, inicioInforme, finInforme, estadoSeleccionado);

            // Verificar si la columna clmNroFactRegistro tiene filas vacías
            if (dgvRegistroPrecio.Rows.Count == 0 || dgvRegistroPrecio.Rows[0].Cells["clmNroFactRegistro"].Value == null || string.IsNullOrWhiteSpace(dgvRegistroPrecio.Rows[0].Cells["clmNroFactRegistro"].Value.ToString()))
            {
                MessageBox.Show("NO HAY FACTURAS EN EL RANGO SELECCIONADO", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //en caso de que si hayan datos
            {
                ctrfacto.MostrarTotalFacturas(dgvRegistroPrecio, txtTotalFacturas);
                ctrfacto.MostrarTotalFacturasConDescuento(dgvRegistroPrecio, txtTotalConDescuento, txtTotalSinDescuento);
                ctrfacto.MostrarMontoTotalInforme(dgvRegistroPrecio, txtMontoTotal);
            }
        }

    }
}
