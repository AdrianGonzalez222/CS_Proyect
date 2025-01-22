using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsMembresia : Form
    {
        private CtrMembresia ctrMen = new CtrMembresia();
        private Validacion v = new Validacion();
        private VsRegistrarCliente vscliente = new VsRegistrarCliente();
        private CtrFactura ctrfact = new CtrFactura();
        private bool cambios;

        public bool Cambios { get => cambios; set => cambios = value; }

        public VsMembresia(string cedulaCliente)
        {
            InitializeComponent();
            ctrMen.MostrarDatosClienteMem(cedulaCliente, lblCedulaM, lblNombreM, lblApellidoM, lblEstudianteM, CelularInvisible, ComprobanteInvisible, FechaNacInvisible, DireccionInvisible);
            lblPorcentaje.Visible = false;
            comboBoxP.SelectedItem = "NO";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tienePromocion = (String)comboBoxP.SelectedItem;
            if (tienePromocion.Equals("SI"))
            {
                labelDP.Visible = true;
                txtBoxDP.Visible = true;
                labelD.Visible = true;
                txtBoxD.Visible = true;
                lblPorcentaje.Visible = true;
            }
            else
            {
                labelDP.Visible = false;
                txtBoxDP.Visible = false;
                labelD.Visible = false;
                txtBoxD.Visible = false;
                lblPorcentaje.Visible = false;
            }
        }

        private void txtBoxD_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarNumerosPorcentaje(sender, e);
        }

        private void txtBoxDP_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarLetra(sender, e);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string msj = "";
            string plan = txtBoxM.Text;
            string FI = dateTPFI.Text;
            string FF = dateTPFF.Text;
            string promocion = comboBoxP.Text;
            string descuento = txtBoxD.Text;
            string detallePromocion = txtBoxDP.Text;
            string cedulaCliente = lblCedulaM.Text;
            string precio   = txtBoxPreM.Text;

            msj = ctrMen.IngresarMembresia(plan, FI, FF, promocion, descuento, detallePromocion, cedulaCliente, precio);

            if (msj.Contains("ERROR"))
            {
                MessageBox.Show(msj, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener la ejecución si hay un error
            }

            MessageBox.Show(msj);
            VsFactura vFactura = new VsFactura();
            vFactura.lblCedulaFact.Text = this.lblCedulaM.Text;
            vFactura.lblNombreFact.Text = this.lblNombreM.Text;
            vFactura.lblApellidoFact.Text = this.lblApellidoM.Text;
            vFactura.lblEstudianteFact.Text = this.lblEstudianteM.Text;
            vFactura.lblPlanFact.Text = this.txtBoxM.Text.ToUpper();
            vFactura.lblPromocionFact.Text = this.comboBoxP.Text;
            vFactura.lblTelefonoFact.Text = this.CelularInvisible.Text;
            vFactura.lblComprobanteFact.Text = this.ComprobanteInvisible.Text;
            vFactura.lblFechaNacimientoFact.Text = this.FechaNacInvisible.Text;
            vFactura.lblDireccionFact.Text = this.DireccionInvisible.Text;
            vFactura.lblFechaInicioFact.Text = this.dateTPFI.Text;
            vFactura.lblFechaFinFact.Text = this.dateTPFF.Text;
            vFactura.lblPrecioFact.Text = this.txtBoxPreM.Text;
            vFactura.lblDescuentoFact.Text = this.txtBoxD.Text;
            vFactura.Show();
            this.Close();

            if (msj.Contains("MEMBRESIA REGISTRADA CORRECTAMENTE"))
            {
                DateTime fechaInicio = ctrMen.FechaActual.Date; 
                DateTime fechaFin = ctrMen.FechaActual.Date;
                txtBoxM.Text = "";
                dateTPFI.Value = ctrMen.FechaActual;
                dateTPFF.Value = ctrMen.FechaActual;
                comboBoxP.Text = "";
                txtBoxD.Text = "";
                txtBoxDP.Text = "";
            }
        }     

        private void btnCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxPreM_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarNumeroPrecio(sender, e);
        }

    }
}
